using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Players : MonoBehaviour {

    public static Players instance { get; private set; }

    public GameObject localPlayer;

    public List<Player> players { get; private set; }
    
    void Awake() {
        if (instance != null)
            throw new Exception();

        players = new List<Player>();
        var local = Instantiate(localPlayer, transform).GetComponent<Player>();
        local.id = 0;
        players.Add(local);

        instance = this;
    }
    
    public Player GetLocalPlayer() {
        return players.Single(p => p.id == 0);
    }

    public Shark GetLocalShark() {
        return GetLocalPlayer().currentShark;
    }
    
    public Shark GetClosestShark(Vector3 position) {
        return players
            .OrderBy(p => {
                return Vector3.Distance(position, p.transform.position);
            })
            .First()
            .currentShark;
    }
}
