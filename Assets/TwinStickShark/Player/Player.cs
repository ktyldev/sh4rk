using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject shark;

    private Shark _shark;

	// Use this for initialization
	void Start () {
        _shark = Instantiate(shark).GetComponent<Shark>();
        Camera.main.GetComponent<CameraController>().trackedObject = _shark.transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
