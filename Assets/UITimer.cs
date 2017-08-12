using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour {

    public int seconds;

    private Text _text;
    
	void Start () {
        _text = GetComponent<Text>();
        StartCoroutine(Countdown());	
	}
	
    private IEnumerator Countdown() {
        for (int i = seconds; i > 0; i--) {
            _text.text = i.ToString();
            yield return new WaitForSecondsRealtime(1);
        }
    }
}
