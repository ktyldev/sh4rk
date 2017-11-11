using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    private Health _health;
    private Image _image;
    
	void Start () {
        _image = GetComponentInChildren<Image>();
        _health = GetComponentInParent<Health>();

        _health.OnChange.AddListener(() => _image.fillAmount = _health.Current);
	}

    void OnGUI() {
        transform.LookAt(transform.position + Camera.main.transform.forward);        
    }
}
