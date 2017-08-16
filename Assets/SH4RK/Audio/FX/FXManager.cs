using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour {

    private static FXManager _instance;
    public static float volume { get; private set; }

    public float defaultVolume;
    
    void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        volume = defaultVolume;
        DontDestroyOnLoad(gameObject);
    }
    
    public static void PlaySound(GameObject sound) {
        var audio = Instantiate(sound, _instance.transform)
            .GetComponent<AudioSource>();

        audio.volume *= volume;
        audio.Play();
    }

    public static void SetVolume(float value) {
        volume = value;
    }
}
