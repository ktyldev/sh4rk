using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : Spawner {
    
    public int enemiesPerLevel;
    public GameObject indicator;
    public int showIndicatorAt;

    private Enemy[] _waveEnemies;
    private int _currentWave = 1;
    private Indicator _indicator;
    private bool _showIndicator;

    public int currentWave { get { return _currentWave; } }
    public int remaining { get { return _waveEnemies == null ? 0 : _waveEnemies.Where(e => e != null).Count(); } }

    public UnityEvent waveStart { get; private set; }
    public UnityEvent waveComplete { get; private set; }

    void Awake() {
        waveStart = new UnityEvent();
        waveComplete = new UnityEvent();
    }

    private void Start() {
        StartCoroutine(SpawnWave(_currentWave));
    }

    void Update() {
        if (!_showIndicator) {
            Destroy(_indicator);
            _indicator = null;
        }

        if (!IsInvoking("SpawnWave")) {
            if (remaining == 0) {
                Debug.Log("Cleared wave " + _currentWave);
                waveComplete.Invoke();

                StartCoroutine(SpawnWave(_currentWave));
            }

            if (_showIndicator && remaining <= showIndicatorAt && _indicator == null) {
                InstantiateIndicator();
            }
        }

    }

    private void InstantiateIndicator() {
        var total = _waveEnemies.Length;

        _indicator = Instantiate(indicator, Player.instance.sharkTransform).GetComponent<Indicator>();
        _indicator.FollowEnemies(_waveEnemies
            .Where(e => e != null)
            .ToArray());

        waveComplete.AddListener(() => _showIndicator = false);
    }

    private IEnumerator SpawnWave(int waveNumber) {
        Debug.Log("Starting wave " + waveNumber);
        waveStart.Invoke();

        var waveEnemies = waveNumber * enemiesPerLevel;
        _waveEnemies = new Enemy[waveEnemies];

        for (int i = 0; i < waveEnemies; i++) {
            Spawn(i);
            yield return new WaitForSeconds(spawnDelay);
        }

        Debug.Log("Finished spawning wave " + waveNumber);
        _showIndicator = true;
        _currentWave = waveNumber + 1;
    }

    private void Spawn(int index) {
        var enemy = base.Spawn().GetComponent<Enemy>();
        enemy.OnDeath.AddListener(() => _waveEnemies[index] = null);
        _waveEnemies[index] = enemy;
    }

    protected override bool CanSpawn(GameObject template) {
        return template.GetComponent<Enemy>().level <= _currentWave;
    }
}
