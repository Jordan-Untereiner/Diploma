using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Library : Room {

    public int magicGen;
    public int magicPillage;

    public override void Effect()
    {
        player.IncreaseMagicGeneration(magicGen);
        level = 1;
    }

    public override void Pillage()
    {
        //Regen aventuriers mana
        player.LoseFood(magicPillage);
    }
}
