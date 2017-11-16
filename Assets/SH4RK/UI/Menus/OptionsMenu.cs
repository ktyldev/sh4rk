using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : Menu {

    public Slider music;
    public Slider sfxSlider;
    public Slider cameraShake;
    public GameObject backMenu;

    private const string CAMERA_SHAKE_KEY = "camera_shake";

    private SFXManager _sfx;

    void Awake() {
        if (PlayerPrefs.HasKey(CAMERA_SHAKE_KEY)) {
            cameraShake.value = PlayerPrefs.GetFloat(CAMERA_SHAKE_KEY);
        }
    }

    void Start() {
        _sfx = GameObject.FindGameObjectWithTag(GameTags.Audio).GetComponent<SFXManager>();

        music.value = MusicManager.volume;
        sfxSlider.value = _sfx.Volume;

        cameraShake.onValueChanged.AddListener(SetCameraShake);
        music.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSfxVolume);
    }

    public void SetSfxVolume(float volume) {
        _sfx.Volume = volume;
    }

    public void SetMusicVolume(float volume) {
        MusicManager.SetVolume(volume);
    }

    private void SetCameraShake(float value) {
        PlayerPrefs.SetFloat("camera_shake", value);
    }
}
