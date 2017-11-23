using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : Menu {

    public Slider musicSlider;
    public Slider sfxSlider;
    public Slider cameraShake;
    public GameObject backMenu;

    private SFXManager _sfx;
    private MusicManager _music;

    void Awake() {
        if (PlayerPrefs.HasKey(GameTags.CameraShake)) {
            cameraShake.value = PlayerPrefs.GetFloat(GameTags.CameraShake);
        }
    }

    void Start() {
        var audio = GameObject.FindGameObjectWithTag(GameTags.Audio);
        _sfx = audio.GetComponent<SFXManager>();
        _music = audio.GetComponent<MusicManager>();

        musicSlider.value = _music.Volume;
        sfxSlider.value = _sfx.Volume;

        cameraShake.onValueChanged.AddListener(v => PlayerPrefs.SetFloat(GameTags.CameraShake, v));
        musicSlider.onValueChanged.AddListener(v => _music.Volume = v);
        sfxSlider.onValueChanged.AddListener(v => _sfx.Volume = v);
    }
}
