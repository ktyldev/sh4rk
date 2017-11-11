using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour {

    public int max;

    private int _current;

    public float Current { get { return (float)_current / max; } }
    public UnityEvent OnChange { get; private set; }
    public UnityEvent OnEmpty { get; private set; }

    private void Awake() {
        OnChange = new UnityEvent();
        OnEmpty = new UnityEvent();
    }

    void Start () {
        _current = max;
	}
	
    public void TakeDamage(int amount) {
        _current -= amount;
        OnChange.Invoke();
        if (_current <= 0) {
            OnEmpty.Invoke();
        }
    }
}

