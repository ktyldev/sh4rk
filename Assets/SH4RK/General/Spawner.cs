using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class Spawner : MonoBehaviour {

    public GameObject[] templates;
    public float minDistanceFromPlayer;
    public float spawnDelay;
    
    protected abstract bool CanSpawn(GameObject template);

    protected virtual GameObject Spawn() {
        var playerTransform = GameObject.FindGameObjectWithTag(GameTags.Player)
            .GetComponent<Player>()
            .Shark
            .transform;

        var angle = UnityEngine.Random.rotation.eulerAngles.y;
        var dir = new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), 0, Mathf.Cos(Mathf.Deg2Rad * angle));
        var offset = dir * minDistanceFromPlayer;
        var spawnPos = playerTransform.position + offset;

        var options = templates
            .Where(CanSpawn)
            .ToArray();

        return Instantiate(
            options[UnityEngine.Random.Range(0, options.Count())],
            spawnPos,
            Quaternion.identity,
            null);
    }
}