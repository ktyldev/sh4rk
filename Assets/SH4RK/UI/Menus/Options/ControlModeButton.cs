using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlModeButton : MonoBehaviour {

    public Sprite console;
    public Sprite keyboard;
    
    private PlayerInput _input;
    private Image _image;
    private Dictionary<string, Sprite> _controlModeSprites;

    void Awake() {
        _image = GetComponentInChildren<Image>();
        _controlModeSprites = new Dictionary<string, Sprite>();
    }

    void Start() {
        _input = GameObject.FindGameObjectWithTag(GameTags.Input).GetComponent<PlayerInput>();
        _controlModeSprites[GameTags.Gamepad] = console;
        _controlModeSprites[GameTags.MouseKeyboard] = keyboard;
    }

    void OnGUI() {
        var currentSprite = _controlModeSprites[_input.controlModeName];

        if (_image.sprite != currentSprite) {
            _image.sprite = currentSprite;
        }
    }

    public void ToggleMode() {
        _input.ToggleControlMode();
    }
}
