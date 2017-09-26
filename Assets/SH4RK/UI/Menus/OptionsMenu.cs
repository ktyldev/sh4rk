using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : Menu {

    public Slider music;
    public Slider sfx;
    public Slider cameraShake;
    public GameObject backMenu;

    private const string CAMERA_SHAKE_KEY = "camera_shake";

    void Awake () {
        if (PlayerPrefs.HasKey(CAMERA_SHAKE_KEY)) {
            cameraShake.value = PlayerPrefs.GetFloat(CAMERA_SHAKE_KEY);
        }
        music.value = MusicManager.volume;
        sfx.value = SFXManager.volume;

        cameraShake.onValueChanged.AddListener(SetCameraShake);
        music.onValueChanged.AddListener(SetMusicVolume);
        sfx.onValueChanged.AddListener(SetSfxVolume);
    }
    
    public void SetSfxVolume(float volume) {
        SFXManager.SetVolume(volume);
    }

    public void SetMusicVolume(float volume) {
        MusicManager.SetVolume(volume);
    }

    private void SetCameraShake(float value) {
        Camera.main.GetComponent<CameraController>().SetShakeAmount(value);
    }
}
