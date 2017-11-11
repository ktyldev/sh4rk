using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour {
    public void Reload() {
        print("Reload!");
        GameManager.Reload();
    }
}
