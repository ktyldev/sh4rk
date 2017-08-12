using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionManager : MonoBehaviour {

    public GameObject explosion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MakeExplosion(Vector3 position) {
        Instantiate(explosion, position, Quaternion.identity, transform);
    }
}
