using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitchen : Room {

    public int foodGen;
    public int foodPillage;

    public override void Effect()
    {
        player.IncreaseFoodGeneration(foodGen);
        level = 1;
    }

    public override void Pillage()
    {
        //Regen aventuriers
        player.LoseFood(foodPillage);
    }
}
