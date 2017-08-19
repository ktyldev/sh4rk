using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour {
    
    private Mover _mover;
    private WeaponMount _mount;
    
    public Weapon weapon {
        get {
            return _mount.currentWeapon;
        }
    }

    public bool isShielded { get { return _shield != null; } }
    private Shield _shield;

    void Awake() {
        _mover = GetComponent<Mover>();
        _mount = GetComponentInChildren<WeaponMount>();
    }
    
    void Update() {
        Move();
    }

    public void PowerupWeapon(GameObject weapon, int shots) {
        _mount.SetPowerupWeapon(weapon, shots);
    }

    public void SetShield(Shield shield) {
        _shield = shield;
    }

    public void DestroyShield() {
        Destroy(_shield.gameObject);
        _shield = null;
    }

    private void Move() {
        _mover.SetDirection(InputManager.controlMode.GetMoveDirection());
    }
}
