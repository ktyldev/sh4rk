using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    
    public int scoreValue;

    private Transform _player;
    private Mover _mover;

    void Awake() {
        _mover = GetComponent<Mover>();    
    }
    
    void Start () {
        _player = Player.instance.sharkTransform;
	}
	
	void Update () {
        var dir = _player.transform.position - transform.position;
        _mover.SetDirection(dir.normalized);
	}

    void OnDestroy() {
        Player.instance.AddScore(scoreValue);
    }
}
