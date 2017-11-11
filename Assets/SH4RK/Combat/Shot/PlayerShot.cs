using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : Shot {
    protected override void OnHit(GameObject hitObject) {
        var health = hitObject.GetComponent<Health>();
        if (health == null)
            throw new Exception();

        health.TakeDamage(1);
    }

    protected override bool ValidateHit(GameObject obj) {
        return obj.GetComponent<Enemy>() != null && obj.GetComponent<Health>() != null;
    }
}
