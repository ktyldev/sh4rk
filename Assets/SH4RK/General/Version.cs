using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Version : MonoBehaviour {

    public TextAsset versionFile;

    void Start() {
        GetComponent<Text>().text = versionFile.text;
    }
}
