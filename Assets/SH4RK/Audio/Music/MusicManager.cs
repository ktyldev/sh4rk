using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    private const string _key = "music_volume";

    private static MusicManager _instance;
    
    public GameObject intro;
    public GameObject loop;

    private AudioSource _intro;
    private AudioSource _loop;

    public static float volume { get { return PlayerPrefs.GetFloat(_key); } }

    private bool _looping;
    
    void Awake() {
        if (!PlayerPrefs.HasKey(_key)) {
            PlayerPrefs.SetFloat(_key, 0.5f);
        }
        
        _instance = this;
    }
    
    void OnGUI() {
        (_looping ? _loop : _intro).volume = volume;
    }

    void Start() {
        

        _intro = Instantiate(intro, transform).GetComponent<AudioSource>();
        _intro.volume = volume;
        var introLength = _intro.clip.length;
        Destroy(_intro, introLength);
        
        _loop = Instantiate(loop, transform).GetComponent<AudioSource>();
        _loop.PlayDelayed(introLength);
        StartCoroutine(SwitchToLoop(introLength));
    }

    public IEnumerator SwitchToLoop(float delay) {
        yield return new WaitForSecondsRealtime(delay);
        _looping = true;
    }
    
    public static void SetVolume(float value) {
        PlayerPrefs.SetFloat(_key, value);
    }
}
