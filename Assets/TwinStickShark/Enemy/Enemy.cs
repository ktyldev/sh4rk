using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int scoreValue;

    private Transform _player;
    private Mover _mover;
    private ExplosionManager _explosions;

    void Awake() {
        _mover = GetComponent<Mover>();
        _explosions = GameObject.FindGameObjectWithTag("GameController").GetComponent<ExplosionManager>();
    }

    void Start() {
        _player = Player.instance.sharkTransform;
    }

    void Update() {
        var dir = _player.transform.position - transform.position;
        _mover.SetDirection(dir.normalized);
    }

    void OnDestroy() {
        Player.instance.AddScore(scoreValue);

        if (_explosions == null)
            return;
        
        _explosions.MakeExplosion(transform.position);
    }

    void OnCollisionEnter(Collision collision) {
        var shark = collision.gameObject.GetComponent<Shark>();
        if (shark == null)
            return;

        Debug.Log("Game over!");
        Time.timeScale = 0;
    }
}
