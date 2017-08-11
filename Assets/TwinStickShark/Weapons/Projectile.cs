using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    
	// Use this for initialization
	void Start () {
        Destroy(gameObject, 5);
    }
	
	// Update is called once per frame
	void Update () {
        // transform.Translate(transform.forward * speed * Time.deltaTime);
        var dir = transform.right;
        transform.Translate(dir * speed * Time.deltaTime, Space.World);
	}
}
