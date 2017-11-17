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
    private Player _player;

    public UnityEvent OnDeath { get { return _health.OnEmpty; } }

    public IAgentController controller { get; private set; }

    void Awake() {
        _health = GetComponent<Health>();
        _explosions = GameObject.FindGameObjectWithTag(GameTags.GameController).GetComponent<ExplosionManager>();
        controller = Instantiate(behaviour, transform).GetComponent<IAgentController>();
        _player = GameObject.FindGameObjectWithTag(GameTags.Player).GetComponent<Player>();
    }

    void Start() {
        _health.OnEmpty.AddListener(Die);
    }

    private void Die() {
        _player.AddScore(scoreValue);

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
