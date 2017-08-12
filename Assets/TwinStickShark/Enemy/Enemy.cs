using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    
    private Transform _player;
    private Mover _mover;

    void Awake() {
        _mover = GetComponent<Mover>();    
    }

    // Use this for initialization
    void Start () {
        _player = Player.instance.sharkTransform;
	}
	
	// Update is called once per frame
	void Update () {
        var dir = _player.transform.position - transform.position;
        _mover.SetDirection(dir.normalized);
	}
}
