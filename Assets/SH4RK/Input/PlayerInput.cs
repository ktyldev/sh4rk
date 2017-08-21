using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInput : MonoBehaviour, IAgentController {

    public static PlayerInput instance { get; private set; }

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

    private ControlMode[] _controlModes;
    private PauseMode _pauseMode;
    private int _controlModeIndex;
    
    void Awake() {
        if (instance != null && instance != this) {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        _controlModeIndex = PlayerPrefs.GetInt("control_mode");
        _controlModes = controlModes
            .Select(InstatiateControlMode)
            .ToArray();

        _pauseMode = (PauseMode)InstatiateControlMode(pauseMode);
    }

    private ControlMode InstatiateControlMode(GameObject mode) {
        return Instantiate(mode, transform).GetComponent<ControlMode>();
    }

    protected ControlMode CurrentControlMode() {
        return GameManager.paused ? _pauseMode : _controlModes[_controlModeIndex];
    }

    void Update() {
        if (GameManager.paused) {
            _pauseMode.SetPausedMode(_controlModes[_controlModeIndex]);
        } else if (pause) {
            GameManager.TogglePause();
        }
    }
    
    public static void ToggleControlMode() {
        instance.IterateControlMode();
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
