using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : Spawner {
    
    public int waveEnemies;
    
    private int _enemiesLeft;
    private int _currentWave = 1;

    public int currentWave { get { return _currentWave; } }
    public int remaining { get { return _enemiesLeft; } }
    
    void Update() {
        if (_enemiesLeft == 0 && !IsInvoking("SpawnWave")) {
            Debug.Log("Cleared wave " + _currentWave);
            StartCoroutine(SpawnWave(_currentWave));
        }
    }

    private IEnumerator SpawnWave(int waveNumber) {
        Debug.Log("Starting wave " + waveNumber);
        for (int i = 0; i < waveNumber * waveEnemies; i++) {
            Spawn();
            yield return new WaitForSeconds(spawnDelay);
        }
        
        Debug.Log("Finished spawning wave " + waveNumber);
        _currentWave++;
    }
    
    protected override GameObject Spawn() {
        var enemy = base.Spawn().GetComponent<Enemy>();
        enemy.onDeath.AddListener(() => _enemiesLeft--);
        _enemiesLeft++;

        return enemy.gameObject;
    }

    protected override bool CanSpawn(GameObject template) {
        return template.GetComponent<Enemy>().level <= _currentWave;
    }
}
