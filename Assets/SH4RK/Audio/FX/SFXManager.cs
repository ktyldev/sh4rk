using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : AudioManager {

    protected override string _VolumeKey
    {
        get
        {
            return "fx_volume";
        }
    }

    public void PlaySound(GameObject sound) {
        var audio = Instantiate(sound, transform)
            .GetComponent<AudioSource>();

        audio.volume *= Volume;
        audio.Play();
    }
}
