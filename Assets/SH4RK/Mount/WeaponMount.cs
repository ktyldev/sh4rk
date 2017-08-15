using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponMount : MonoBehaviour {

    public Transform[] hardPoints;

    public GameObject mainWeapon;
    public Weapon currentWeapon {
        get {
            return _weapons.First();
        }
    }

    private Weapon[] _weapons;

    private Weapon[] _mainWeapons;
    private Weapon[] _powerUpWeapons;
    private int _powerUpShots = 10;
    private int _powerUpShotsRemaining = 0;
    
    void Awake() {
        _mainWeapons = InstantiateWeapons(mainWeapon);
        _weapons = _mainWeapons;
    }

    void Update() {
        if (_powerUpWeapons == null)
            return;
        
        if (_powerUpShotsRemaining == 0) {
            SetMainWeapon();
        }

        print(_powerUpShotsRemaining / hardPoints.Length);
    }

    public void SetPowerupWeapon(GameObject powerupWeapon) {
        foreach (var wep in _mainWeapons) {
            print("disable main");
            Destroy(wep.gameObject);
        }

        _powerUpWeapons = InstantiateWeapons(powerupWeapon);
        _weapons = _powerUpWeapons;
        _powerUpShotsRemaining = _powerUpShots * hardPoints.Length;

        _powerUpWeapons
            .ToList()
            .ForEach(w => w.onFire.AddListener(() => _powerUpShotsRemaining--));

        _mainWeapons = null;
    }

    private void SetMainWeapon() {
        if (_powerUpWeapons != null) {
            foreach (var wep in _powerUpWeapons) {
                Destroy(wep.gameObject);
            }
        }

        print(mainWeapon);

        _mainWeapons = InstantiateWeapons(mainWeapon);
        _weapons = _mainWeapons;
        
        _powerUpWeapons = null;
    }

    private Weapon[] InstantiateWeapons(GameObject template) {
        return hardPoints
            .Select(h => Instantiate(template, h).GetComponent<Weapon>())
            .ToArray();
    }
}
