using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionManager : MonoBehaviour {

    public GameObject explosion;
    
    public void MakeExplosion(Vector3 position) {
        Instantiate(explosion, position, Quaternion.identity, transform);
    }
}
