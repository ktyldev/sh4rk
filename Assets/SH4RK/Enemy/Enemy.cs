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
    
    private ExplosionManager _explosions;
    private Health _health;

    public UnityEvent OnDeath { get { return _health.OnEmpty; } }

    public IAgentController controller {
        get {
            return _controller;
        }
    }
    private EnemyController _controller;

    void Awake() {
        _health = GetComponent<Health>();
        _explosions = GameObject.FindGameObjectWithTag(GameTags.GameController).GetComponent<ExplosionManager>();
    }

    void Start() {
        _controller = Instantiate(behaviour, transform).GetComponent<EnemyController>();

        _health.OnEmpty.AddListener(Die);
    }

    private void Die() {
        // onDeath.Invoke();
        Player.instance.AddScore(scoreValue);

        if (_explosions == null)
            return;

        _explosions.MakeExplosion(transform.position);
        Destroy(gameObject);
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
