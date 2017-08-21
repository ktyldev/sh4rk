using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaveAnnouncer : MonoBehaviour {
    
    public GameObject enemySpawner;
    public GameObject waveText;
    
	void Start () {
        enemySpawner
            .GetComponent<EnemySpawner>()
            .waveComplete
            .AddListener(() => {
                var waveAnnouncment = Instantiate(waveText, transform);
                Destroy(waveAnnouncment, 3);
            });
	}
}
