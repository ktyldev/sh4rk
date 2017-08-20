using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {

    public Slider music;
    public Slider sfx;
    public GameObject backMenu;
    
    void Awake () {
        music.value = MusicManager.volume;
        sfx.value = SFXManager.volume;

        music.onValueChanged.AddListener(SetMusicVolume);
        sfx.onValueChanged.AddListener(SetSfxVolume);
    }
	
    public void SetSfxVolume(float volume) {
        SFXManager.SetVolume(volume);
    }

    public void SetMusicVolume(float volume) {
        MusicManager.SetVolume(volume);
    }

    public void Back() {
        UIManager.instance.OpenMenu(gameObject, backMenu);
    }
}
