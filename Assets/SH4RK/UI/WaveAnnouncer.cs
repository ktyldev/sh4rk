using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WaveAnnouncer : MonoBehaviour {
    
    public GameObject enemySpawner;
    public GameObject waveText;
    
	void Start () {
        var spawner = enemySpawner.GetComponent<EnemySpawner>();

        spawner
            .waveStart
            .AddListener(() => {
                var waveAnnouncment = Instantiate(waveText, transform);
                Destroy(waveAnnouncment, 3);

                var text = waveAnnouncment.GetComponentInChildren<Text>();
                text.text = string.Format("Wave {0}!", spawner.currentWave);
            });
	}
}
