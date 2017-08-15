using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {
    
    private Slider _slider;
    
	void Awake () {
        _slider = GetComponentInChildren<Slider>();

        _slider.value = MusicManager.volume;
        _slider.onValueChanged.AddListener(MusicManager.SetVolume);
	}

    public void Quit() {
        print("Quit");
        Application.Quit();
    }
}
