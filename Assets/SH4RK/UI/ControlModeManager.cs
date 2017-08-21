using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlModeManager : MonoBehaviour {

    private const string _key = "control_mode";

    private Text _text;

    void Awake() {
        if (!PlayerPrefs.HasKey(_key)) {
            PlayerPrefs.SetInt(_key, 0);
        }

        _text = GetComponentInChildren<Text>();
    }

    void OnGUI() {
        _text.text = "Control Mode: " + PlayerInput.instance.controlModeName;
    }

    public void ToggleMode() {
        PlayerPrefs.SetInt(_key, PlayerPrefs.GetInt(_key) == 0 ? 1 : 0);

        PlayerInput.ToggleControlMode();
    }
}
