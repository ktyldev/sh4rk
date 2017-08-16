using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : Shot {
    protected override void OnHit(GameObject hitObject) {
        GameManager.GameOver();
    }

    protected override bool ValidateHit(GameObject obj) {
        var root = obj.transform.root;

        do {
            var shark = obj.GetComponent<Shark>();
            if (shark != null) {
                if (shark.isShielded) {
                    Destroy(gameObject);
                    shark.DestroyShield();
                    return false;
                }

                return true;
            }

            if (obj.transform == root)
                return false;

            obj = obj.transform.parent.gameObject;
        } while (obj.transform != root);

        return false;
    }
}