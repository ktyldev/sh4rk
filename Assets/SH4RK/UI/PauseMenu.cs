using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public GameObject musicVolume;
    public GameObject fxVolume;

    private Slider _music;
    private Slider _fx;
    
	void Awake () {
        _music = musicVolume.GetComponent<Slider>();
        _music.value = MusicManager.volume;
        _music.onValueChanged.AddListener(MusicManager.SetVolume);

        _fx = fxVolume.GetComponent<Slider>();
        _fx.value = SFXManager.volume;
        _fx.onValueChanged.AddListener(SFXManager.SetVolume);
	}

    public void Quit() {
        print("Quit");
        Application.Quit();
    }
}
