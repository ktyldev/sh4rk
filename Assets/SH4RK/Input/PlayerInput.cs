using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInput : MonoBehaviour, IAgentController {

    public string controlModeName {
        get {
            return CurrentControlMode().controlMode;
        }
    }

    public Vector3 moveDirection {
        get {
            return CurrentControlMode().GetMoveDirection();
        }
    }

    public Vector3 aimDirection {
        get {
            return CurrentControlMode().GetAimDirection();
        }
    }

    public bool attack {
        get {
            return CurrentControlMode().Attack();
        }
    }

    public bool pause {
        get {
            return CurrentControlMode().Pause();
        }
    }

    public GameObject[] controlModes;
    public GameObject pauseMode;

    private IControlMode[] _controlModes;
    private PauseMode _pauseMode;
    private int _controlModeIndex;

    void Awake() {
        if (!PlayerPrefs.HasKey(GameTags.ControlMode)) {
            PlayerPrefs.SetInt(GameTags.ControlMode, 0);
        }
    }

    void Start() {
        _controlModeIndex = PlayerPrefs.GetInt(GameTags.ControlMode);
        _controlModes = controlModes
            .Select(InstatiateControlMode)
            .ToArray();

        _pauseMode = (PauseMode)InstatiateControlMode(pauseMode);
    }

    private IControlMode InstatiateControlMode(GameObject mode) {
        return Instantiate(mode, transform).GetComponent<IControlMode>();
    }

    protected IControlMode CurrentControlMode() {
        return GameManager.paused ? _pauseMode : _controlModes[_controlModeIndex];
    }

    void Update() {
        if (GameManager.paused) {
            _pauseMode.SetPausedMode(_controlModes[_controlModeIndex]);
        } else if (pause) {
            GameManager.TogglePause();
        }

        if (GameManager.gameIsOver && CurrentControlMode().Continue()) {
            GameManager.Reload();
        }
    }
    
    public void ToggleControlMode() {
        var oldIindex = _controlModeIndex;
        var newIndex = oldIindex == _controlModes.Length - 1 ?
            0 :
            oldIindex + 1;

        var oldMode = _controlModes[oldIindex];
        Destroy((MonoBehaviour)oldMode);

        _controlModes[oldIindex] = InstatiateControlMode(controlModes[oldIindex]);
        _controlModeIndex = newIndex;

        PlayerPrefs.SetInt(GameTags.ControlMode, newIndex);
    }
}
