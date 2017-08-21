using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour {
    
    private const string _key = "fx_volume";

    private static SFXManager _instance;
    public static float volume { get { return PlayerPrefs.GetFloat(_key); } }
    
    void Awake() {
        if (!PlayerPrefs.HasKey(_key)) {
            PlayerPrefs.SetFloat(_key, 0.5f);
        }

        if (_instance != null && _instance != this) {
            Destroy(gameObject);
            return;
        }
        
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    public static void PlaySound(GameObject sound) {
        var audio = Instantiate(sound, _instance.transform)
            .GetComponent<AudioSource>();

        audio.volume *= volume;
        audio.Play();
    }

    public static void SetVolume(float value) {
        PlayerPrefs.SetFloat(_key, value);
    }
}
