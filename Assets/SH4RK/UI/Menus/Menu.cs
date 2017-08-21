using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Menu : MonoBehaviour {
    public GameObject opener { get; set; }

    public void Back() {
        if (opener == null)
            throw new Exception();

        opener.SetActive(true);
        Destroy(gameObject);
    }
}
