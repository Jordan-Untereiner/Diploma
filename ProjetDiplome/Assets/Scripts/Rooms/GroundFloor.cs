using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFloor : Room {

    void Start()
    {
        player = FindObjectOfType<Player>();
        population = 0;
        traps = 0;
        AddRoom();
    }

    public override void Effect()
    {
        level = 1;
    }

    public override void Pillage()
    {

    }
}
