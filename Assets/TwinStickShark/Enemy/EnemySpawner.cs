using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy;
    public float minDistanceFromPlayer;
    public int numberToSpawn;

    private Transform _playerTransform;
    
	// Use this for initialization
	void Start () {
        _playerTransform = GetComponent<Player>().sharkTransform;

        for (int i = 0; i < numberToSpawn; i++) {
            SpawnEnemy();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void SpawnEnemy() {
        var angle = Random.rotation.eulerAngles.y;
        var dir = new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), 0, Mathf.Cos(Mathf.Deg2Rad * angle));
        var offset = dir * minDistanceFromPlayer;
        var spawnPos = _playerTransform.position + offset;

        Instantiate(enemy, spawnPos, Quaternion.identity, null);
    }
}
