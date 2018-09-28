using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : Room {

    public int goldGen;

    void Start()
    {
        player = FindObjectOfType<Player>();
        population = 0;
        traps = 0;
        AddUndergroundRoom();
        Dungeon d = FindObjectOfType<Dungeon>();
        d.UpdateDungeon();
    }

    public override void Effect()
    {
        player.IncreaseGoldGeneration(goldGen);
        level = 1;
    }

    public override void Pillage()
    {

    }
}
