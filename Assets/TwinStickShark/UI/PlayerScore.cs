using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour {

    private Player _player;
    private Text _text;

    void Start() {
        _player = Player.instance;
        _text = GetComponent<Text>();
    }

    void OnGUI() {
        _text.text = string.Format("Score: {0}", _player.score);
    }
}
