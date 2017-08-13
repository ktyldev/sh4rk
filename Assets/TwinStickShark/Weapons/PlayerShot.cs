using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : Shot {
    protected override bool ValidateHit(GameObject obj) {
        return obj.GetComponent<Enemy>() != null;
    }
}
