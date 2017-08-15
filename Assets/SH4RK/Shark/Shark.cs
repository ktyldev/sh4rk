using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour {

    public GameObject mount;

    private Mover _mover;
    private WeaponMount _mount;
    
    public Weapon weapon {
        get {
            return _mount.currentWeapon;
        }
    }

    void Awake() {
        _mover = GetComponent<Mover>();
    }
    
    void Start() {
        _mount = Instantiate(mount, transform).GetComponent<WeaponMount>();
    }
    
    void Update() {
        Move();
    }

    public void PowerupWeapon(GameObject weapon) {
        _mount.SetPowerupWeapon(weapon);
    }

    private void Move() {
        _mover.SetDirection(InputManager.controlMode.GetMoveDirection());
    }
}
