using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlModeManager : MonoBehaviour {

    private Text _text;

    void Awake() {
        _text = GetComponentInChildren<Text>();    
    }

    void OnGUI() {
        _text.text = "Control Mode: " + InputManager.controlMode.controlMode;    
    }

    public void ToggleMode() {
        InputManager.ToggleControlMode();
    }
}
