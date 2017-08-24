using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LocalPlayer : Player {
    //private const string high_score = "high_score";
    //public int highScore { get; private set; }

    protected override IAgentController sharkController {
        get {
            return PlayerInput.instance;
        }
    }

    protected override void OnAwake() {
        base.OnAwake();


        //if (!PlayerPrefs.HasKey(high_score)) {
        //    PlayerPrefs.SetInt(high_score, 0);
        //}

        //highScore = PlayerPrefs.GetInt(high_score);
    }

    void Start() {
        Camera.main.GetComponent<CameraController>().trackedObject = currentShark.transform;

        //GameManager.gameOver.AddListener(() => {
        //    if (score > highScore) {
        //        PlayerPrefs.SetInt(high_score, score);
        //    }
        //});
    }
}
