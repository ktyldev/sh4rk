using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public GameObject intro;
    public GameObject loop;

    private AudioSource _audio;

    // Use this for initialization
    void Start () {
        var introAudio = Instantiate(intro).GetComponent<AudioSource>();

        _audio = Instantiate(loop).GetComponent<AudioSource>();
        _audio.PlayDelayed(introAudio.clip.length);
	}
}
