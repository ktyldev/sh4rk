using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class UrchinController : EnemyController {
    protected override bool GetAttack() {
        if (base.GetAttack()) {
            Destroy(transform.parent.gameObject);
            return true;
        }

        return false;
    }
}
