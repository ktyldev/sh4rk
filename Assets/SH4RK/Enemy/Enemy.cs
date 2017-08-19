using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IAgent {

    public int level;
    public int scoreValue;
    public int engagementDistance;

    private Transform _player;
    private Mover _mover;
    private ExplosionManager _explosions;

    public UnityEvent onDeath { get; private set; }

    public IAgentController controller {
        get {
            return _controller;
        }
    }
    private EnemyController _controller;

    void Awake() {
        _mover = GetComponent<Mover>();
        _explosions = GameObject.FindGameObjectWithTag("GameController").GetComponent<ExplosionManager>();

        onDeath = new UnityEvent();
    }

    void Start() {
        _player = Player.instance.sharkTransform;
        _controller = new EnemyController(transform, _player, engagementDistance);
    }
    
    void OnDestroy() {
        onDeath.Invoke();
        Player.instance.AddScore(scoreValue);

        if (_explosions == null)
            return;

        _explosions.MakeExplosion(transform.position);
    }

    void OnCollisionEnter(Collision collision) {
        var shark = collision.gameObject.GetComponent<Shark>();
        if (shark == null)
            return;

        if (shark.isShielded) {
            Destroy(gameObject);
            shark.DestroyShield();
            return;
        }

        GameManager.GameOver();
    }
}
