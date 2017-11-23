using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlModeManager : MonoBehaviour {

    public Sprite console;
    public Sprite keyboard;

    private const string _key = "control_mode";
    private PlayerInput _input;

    private Image _image;

    void Awake() {
        if (!PlayerPrefs.HasKey(_key)) {
            PlayerPrefs.SetInt(_key, 0);
        }

        _image = GetComponentInChildren<Image>();
    }

    void Start() {
        _input = GameObject.FindGameObjectWithTag(GameTags.Input).GetComponent<PlayerInput>();
    }

    void OnGUI() {
        if (_input.controlModeName == "Gamepad")
            _image.sprite = console;
        else
            _image.sprite = keyboard;
    }

    public void ToggleMode() {
        PlayerPrefs.SetInt(_key, PlayerPrefs.GetInt(_key) == 0 ? 1 : 0);
        _input.ToggleControlMode();
    }
}
