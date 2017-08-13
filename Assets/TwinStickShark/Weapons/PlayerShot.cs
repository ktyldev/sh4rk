using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : Shot {
    protected override void OnHit(GameObject hitObject) {
        Destroy(hitObject);
    }

    protected override bool ValidateHit(GameObject obj) {
        return obj.GetComponent<Enemy>() != null;
    }
}
