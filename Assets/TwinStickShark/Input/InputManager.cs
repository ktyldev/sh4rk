using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    private static InputManager _instance;

    public ControlMode controlMode;

    private static Vector3 _move;
    private static Vector3 _aim;

    void Awake() {
        if (_instance != null) 
            throw new System.Exception();

        _instance = this;
        _move = new Vector3();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) ||  Input.GetKeyDown(KeyCode.Joystick1Button7)) {
            GameManager.TogglePause();
            UIManager.TogglePause();
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            ToggleControlMode();
        }    
    }

    public static ControlMode currentControlMode {
        get {
            return _instance.controlMode;
        }
    }
    
    public static void ToggleControlMode() {
        if (_instance.controlMode == ControlMode.Gamepad) {
            _instance.controlMode = ControlMode.MouseKeyboard;
        } else {
            _instance.controlMode = ControlMode.Gamepad;
        }
    }

    public static Vector3 GetMoveDirection() {
        switch (_instance.controlMode) {
            case ControlMode.MouseKeyboard:
                _move = Vector3.zero;

                if (Input.GetKey(KeyCode.A)) {
                    _move.x = -1;
                }
                if (Input.GetKey(KeyCode.D)) {
                    _move.x = 1;
                }
                if (Input.GetKey(KeyCode.W)) {
                    _move.z = 1;
                }
                if (Input.GetKey(KeyCode.S)) {
                    _move.z = -1;
                }

                break;
            case ControlMode.Gamepad:
                _move.x = Input.GetAxis("Horizontal");
                _move.z = Input.GetAxis("Vertical");
                break;
        }

        return _move;
    }

    public static Vector3 GetAimDirection() {
        switch (_instance.controlMode) {
            case ControlMode.MouseKeyboard:
                var mousePos = Input.mousePosition;
                
                mousePos.x -= Screen.width / 2;
                mousePos.y -= Screen.height / 2;

                _aim.x = -mousePos.y;
                _aim.z = mousePos.x;
                _aim.Normalize();
                break;
                
            case ControlMode.Gamepad:
                _aim.x = Input.GetAxis("RightV");
                _aim.z = Input.GetAxis("RightH");

                break;
        }

        return _aim;
    }

    public static bool Attack() {
        switch (_instance.controlMode) {
            case ControlMode.MouseKeyboard:
                return Input.GetMouseButton(0);
                
            case ControlMode.Gamepad:
                return Input.GetAxis("Attack") == 1;

            default:
                throw new System.Exception();
        }
    }
}
