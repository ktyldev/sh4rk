using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponMount : MonoBehaviour {

    public Transform[] hardPoints;

    public GameObject weapon;

    private Weapon[] _weapons;
    
	// Use this for initialization
	void Start () {
        _weapons = hardPoints
            .Select(h => Instantiate(weapon, h).GetComponent<Weapon>())
            .ToArray();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
