using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy;
    public float minDistanceFromPlayer;
    public int waveEnemies;
    public float spawnDelay;

    private Transform _playerTransform;
    private int _enemiesLeft;
    private int _currentWave = 0;

    public int currentWave { get { return _currentWave; } }
    
    void Start () {
        _playerTransform = GetComponent<Player>().sharkTransform;
	}

    void Update() {
        if (_enemiesLeft == 0 && !IsInvoking("SpawnWave")) {
            Debug.Log("Cleared wave " + _currentWave);
            _currentWave++;
            StartCoroutine(SpawnWave(_currentWave));
        }
    }

    private IEnumerator SpawnWave(int waveNumber) {
        Debug.Log("Starting wave " + waveNumber);
        for (int i = 0; i < waveNumber * waveEnemies; i++) {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnDelay);
        }

        Debug.Log("Finished spawning wave " + waveNumber);
    }

    private void SpawnEnemy() {
        var angle = Random.rotation.eulerAngles.y;
        var dir = new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), 0, Mathf.Cos(Mathf.Deg2Rad * angle));
        var offset = dir * minDistanceFromPlayer;
        var spawnPos = _playerTransform.position + offset;

        var newEnemy = Instantiate(enemy, spawnPos, Quaternion.identity, null).GetComponent<Enemy>();
        newEnemy.onDeath.AddListener(() => _enemiesLeft--);
        _enemiesLeft++;
    }
}
