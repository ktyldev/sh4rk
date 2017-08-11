using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var dir = new Vector3(Input.GetAxis("RightV"), 0, Input.GetAxis("RightH"));
        if (dir == Vector3.zero)
            return;
        
        transform.LookAt(transform.position + dir);
	}
}
