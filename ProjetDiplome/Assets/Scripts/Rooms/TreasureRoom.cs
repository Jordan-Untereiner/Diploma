using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureRoom : Room {

    void Start()
    {
        player = FindObjectOfType<Player>();
        population = 0;
        traps = 0;
        AddRoom();
    }

    public override void Effect()
    {
        Tower t = FindObjectOfType<Tower>();
        t.ChangeTop(this);
        level = 1;
    }

    public override void Pillage()
    {
        player.LoseReputation(50);
        player.LoseGold(500);
        player.LoseFood(500);
        player.LoseMagic(100);
        player.LoseHuman(20);
    }
}
