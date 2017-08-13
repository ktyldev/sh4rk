using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : Shot {
    protected override bool ValidateHit(GameObject obj) {
        return obj.GetComponent<Shark>() != null;
    }
}
