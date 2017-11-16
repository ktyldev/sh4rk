using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AudioManager : MonoBehaviour {

    protected abstract string _VolumeKey { get; }
    public float Volume {
        get {
            return PlayerPrefs.GetFloat(_VolumeKey);
        }
        set
        {
            PlayerPrefs.SetFloat(_VolumeKey, value);
        }
    }

    void Awake() {
        if (!PlayerPrefs.HasKey(_VolumeKey)) {
            PlayerPrefs.SetFloat(_VolumeKey, 0.5f);
        }
    }
}
