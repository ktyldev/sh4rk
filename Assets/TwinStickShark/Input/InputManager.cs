using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    private static InputManager _instance;

    public ControlMode controlMode;

    private static Vector3 _direction;

    void Awake() {
        if (_instance != null) 
            throw new System.Exception();

        _instance = this;
        _direction = new Vector3();
    }

    public static Vector3 GetMoveDirection() {
        switch (_instance.controlMode) {
            case ControlMode.MouseKeyboard:
                _direction = Vector3.zero;

                if (Input.GetKey(KeyCode.A)) {
                    _direction.x = -1;
                }
                if (Input.GetKey(KeyCode.D)) {
                    _direction.x = 1;
                }
                if (Input.GetKey(KeyCode.W)) {
                    _direction.z = 1;
                }
                if (Input.GetKey(KeyCode.S)) {
                    _direction.z = -1;
                }

                break;
            case ControlMode.Gamepad:
                _direction.x = Input.GetAxis("Horizontal");
                _direction.z = Input.GetAxis("Vertical");
                break;

            default:
                break;
        }

        return _direction;
    }
}
