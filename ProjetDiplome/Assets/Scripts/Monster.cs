using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Monster : Character {

    public int goldCost;
    public int foodCost;
    public int magicCost;
    public int humanCost;

    public int goldSalary;
    public int foodSalary;
    public int magicSalary;
    public int humanSalary;

    public int size;

    public string activeEffect;
    public string passiveEffect;



    public void PurchaseMonster()
    {
        if (player == null)
        {
            player = FindObjectOfType<Player>();
        }

        if (ui == null)
        {
            ui = FindObjectOfType<UIManager>();
        }

        if (dungeon == null)
        {
            dungeon = FindObjectOfType<Dungeon>();
        }

        player.LoseGold(goldCost);
        player.LoseFood(foodCost);
        player.LoseMagic(magicCost);
        player.LoseHuman(humanCost);
        player.RecruitMonster(this);
        ui.UpdateRessources();
        //dungeon.UpdateDungeon();
        ui.EscapeAll();
    }

}
