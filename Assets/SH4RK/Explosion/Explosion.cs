using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public GameObject[] frames;
    public float frameDelay;
    public GameObject splodeSound;
    
    private GameObject[] _frames;

    void Awake() {
        _frames = new GameObject[frames.Length];    
    }

    void Start() {
        StartCoroutine(Explode());
    }

    private IEnumerator Explode() {
        FXManager.PlaySound(splodeSound);

        for (int i = 0; i < frames.Length; i++) {
            _frames[i] = Instantiate(frames[i], transform);

            if (i > 0) {
                Destroy(_frames[i - 1]);
            }

            yield return new WaitForSeconds(frameDelay);
        }

        _frames
            .Where(f => f != null)
            .ToList()
            .ForEach(Destroy);
    }
}
