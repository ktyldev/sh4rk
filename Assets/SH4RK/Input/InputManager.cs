using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InputManager : MonoBehaviour {

    private static InputManager _instance;
    public static ControlMode controlMode { get { return _instance.CurrentControlMode(); } }
    
    public GameObject[] controlModes;
    public GameObject pauseMode;

    private ControlMode[] _controlModes;
    private Pause _pauseMode;
    private int _controlModeIndex;
    private bool _paused;
    
    void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        _controlModes = controlModes
            .Select(InstatiateControlMode)
            .ToArray();

        _pauseMode = (Pause)InstatiateControlMode(pauseMode);
    }

    private ControlMode InstatiateControlMode(GameObject mode) {
        return Instantiate(mode, transform).GetComponent<ControlMode>();
    }

    protected ControlMode CurrentControlMode() {
        return _paused ? _pauseMode : _controlModes[_controlModeIndex];
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) ||  Input.GetKeyDown(KeyCode.Joystick1Button7)) {
            _paused = !_paused;
            GameManager.TogglePause();
            UIManager.TogglePause();
        }

        if (_paused) {
            _pauseMode.SetPausedMode(_controlModes[_controlModeIndex]);
        }
    }
    
    public static void ToggleControlMode() {
        _instance.IterateControlMode();
    }

    protected void IterateControlMode() {
        var oldIindex = _controlModeIndex;
        var newIndex = oldIindex == _controlModes.Length - 1 ? 
            0 : 
            oldIindex + 1;

        var oldMode = _controlModes[oldIindex];
        Destroy(oldMode);

        _controlModes[oldIindex] = InstatiateControlMode(controlModes[oldIindex]);
        _controlModeIndex = newIndex;
    }
}
