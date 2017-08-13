using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlModeManager : MonoBehaviour {

    private Text _text;

    void Awake() {
        _text = GetComponent<Text>();    
    }

    void OnGUI() {
        _text.text = "Space to toggle control mode! Current: " + InputManager.currentControlMode;    
    }
}
