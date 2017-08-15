using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    private static MusicManager _instance;

    public float defaultVolume;
    public GameObject intro;
    public GameObject loop;
    
    private AudioSource _intro;
    private AudioSource _loop;

    public static float volume { get; protected set; }

    private bool _looping;

    void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(gameObject);
            return;
        }
        
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    void OnGUI() {
        (_looping ? _loop : _intro).volume = volume;
    }

    void Start() {
        volume = defaultVolume;

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
        print(volume);
        volume = value;    
    }
}
