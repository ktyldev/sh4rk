using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IAgent {

    public GameObject behaviour;
    public int level;
    public int scoreValue;
    public int engagementDistance;

    private Transform _trackTarget;
    private ExplosionManager _explosions;

    public UnityEvent onDeath { get; private set; }

    public IAgentController controller {
        get {
            return _controller;
        }
    }
    private EnemyController _controller;

    void Awake() {
        _explosions = GameObject.FindGameObjectWithTag("GameController").GetComponent<ExplosionManager>();

        onDeath = new UnityEvent();
    }

    void Start() {
        _controller = Instantiate(behaviour, transform).GetComponent<EnemyController>();
    }
    
    void OnDestroy() {
        onDeath.Invoke();
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
