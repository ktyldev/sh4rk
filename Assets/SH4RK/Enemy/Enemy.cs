using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour {

    public int level;
    public int scoreValue;

    private Transform _player;
    private Mover _mover;
    private ExplosionManager _explosions;

    public UnityEvent onDeath { get; private set; }

    void Awake() {
        _mover = GetComponent<Mover>();
        _explosions = GameObject.FindGameObjectWithTag("GameController").GetComponent<ExplosionManager>();

        onDeath = new UnityEvent();
    }

    void Start() {
        _player = Player.instance.sharkTransform;
    }

    void Update() {
        var dir = _player.transform.position - transform.position;
        _mover.SetDirection(dir.normalized);
    }

    void OnDestroy() {
        onDeath.Invoke();
        Player.instance.AddScore(scoreValue);

        if (_explosions == null)
            return;

        _explosions.MakeExplosion(transform.position);
    }
    
    private void OnTriggerEnter(Collider other) {
        var shark = other.gameObject.GetComponent<Shark>();
        if (shark == null)
            return;

        GameManager.GameOver();
    }
}
