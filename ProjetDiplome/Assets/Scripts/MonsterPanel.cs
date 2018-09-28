using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterPanel : MonoBehaviour {

    public Player player;
    public List<Monster> monsters;

    public Image[] monsterIcons;
    public Text[] goldTexts;
    public Text[] foodTexts;
    public Text[] magicTexts;
    public Text[] humanTexts;
    public Text[] sizes;
    public Text[] activeEffects;
    public Text[] passiveEffects;
    public Button[] purchases;

    private int id;

	// Use this for initialization
	void Start ()
    {
        id = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DisplayMonsters()
    {
        for(int i=0; i < 4; i++)
        {
            monsterIcons[i].sprite = monsters[id + i].icon;
            goldTexts[i].text = monsters[id + i].goldCost.ToString("n0");
            foodTexts[i].text = monsters[id + i].foodCost.ToString("n0");
            magicTexts[i].text = monsters[id + i].magicCost.ToString("n0");
            humanTexts[i].text = monsters[id + i].humanCost.ToString("n0");
            sizes[i].text = monsters[id + i].size.ToString("n0");
            activeEffects[i].text = monsters[id + i].activeEffect;
            passiveEffects[i].text = monsters[id + i].passiveEffect;

            if (player.GetGold() >= monsters[id + i].goldCost && player.GetFood() >= monsters[id + i].foodCost && player.GetMagic() >= monsters[id + i].magicCost && player.GetHuman() >= monsters[id + i].humanCost)
            {
                purchases[i].interactable = true;
            }
            else
            {
                purchases[i].interactable = false;
            }
        }
    }

    public void Purchase(int i)
    {
        monsters[id + i].PurchaseMonster();
    }
}
