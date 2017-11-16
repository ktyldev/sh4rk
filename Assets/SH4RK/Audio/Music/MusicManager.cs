using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : AudioManager {
    
    protected override string _VolumeKey
    {
        get
        {
            return GameTags.MusicVolume;
        }
    }

    public GameObject intro;
    public GameObject loop;

    private AudioSource _intro;
    private AudioSource _loop;
    private bool _looping;
    
    void Start() {
        _intro = Instantiate(intro, transform).GetComponent<AudioSource>();
        _intro.volume = Volume;

        var introLength = _intro.clip.length;
        Destroy(_intro, introLength);
        
        _loop = Instantiate(loop, transform).GetComponent<AudioSource>();
        _loop.PlayDelayed(introLength);
        StartCoroutine(SwitchToLoop(introLength));
    }

    void OnGUI() {
        (_looping ? _loop : _intro).volume = Volume;
    }

    public IEnumerator SwitchToLoop(float delay) {
        yield return new WaitForSecondsRealtime(delay);
        _looping = true;
    }
}
