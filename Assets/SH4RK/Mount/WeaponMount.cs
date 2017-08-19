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
    private int _powerUpShotsRemaining = 0;
    private IAgentController _weaponController;

    void Awake() {
        _weaponController = GetComponentInParent<IAgent>().controller;
        _mainWeapons = InstantiateWeapons(mainWeapon);
        _weapons = _mainWeapons;
    }

    void Update() {
        if (_powerUpWeapons == null || !_powerUpWeapons.Any())
            return;

        if (_powerUpShotsRemaining <= 0) {
            SetMainWeapon();
        }
    }

    public void SetPowerupWeapon(GameObject powerupWeapon, int shots) {
        if (_mainWeapons != null) {
            foreach (var wep in _mainWeapons) {
                Destroy(wep.gameObject);
            }
            _powerUpWeapons = InstantiateWeapons(powerupWeapon);
            _weapons = _powerUpWeapons;
        }

        _powerUpShotsRemaining += shots;

        _powerUpWeapons
            .First()
            .onFire
            .AddListener(() => _powerUpShotsRemaining--);

        _mainWeapons = null;
    }

    private void SetMainWeapon() {
        if (_powerUpWeapons != null) {
            foreach (var wep in _powerUpWeapons) {
                Destroy(wep.gameObject);
            }
        }
        
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
