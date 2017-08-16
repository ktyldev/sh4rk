using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PowerupSpawner : Spawner {

    void Start() {
        StartCoroutine(SpawnPowerups());
    }

    private IEnumerator SpawnPowerups() {
        while (true) {
            yield return new WaitForSeconds(spawnDelay);
            print("Spawning powerup");
            Spawn();
        }
    }

    protected override bool CanSpawn(GameObject template) {
        return true;
    }
}
