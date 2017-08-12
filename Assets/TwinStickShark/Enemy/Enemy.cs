using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 10;

    private Transform _player;

	// Use this for initialization
	void Start () {
        _player = Player.instance.sharkTransform;
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(_player);

        var dir = _player.transform.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
	}
}
