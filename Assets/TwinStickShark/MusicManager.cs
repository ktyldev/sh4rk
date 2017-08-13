using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    private static MusicManager _instance;

    public GameObject intro;
    public GameObject loop;

    private AudioSource _audio;

    void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start() {
        var introAudio = Instantiate(intro, transform).GetComponent<AudioSource>();

        _audio = Instantiate(loop, transform).GetComponent<AudioSource>();
        _audio.PlayDelayed(introAudio.clip.length);
    }
}
