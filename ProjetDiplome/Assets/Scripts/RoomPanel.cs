using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomPanel : MonoBehaviour {

    public Player player;

    public List<Room> rooms;
    public Image[] roomImages;
    public Text[] goldTexts;
    public Text[] foodTexts;
    public Text[] magicTexts;
    public Text[] humanTexts;
    public Text[] effects;
    public Text[] pillages;
    public Button[] purchases;

    private int id;


	// Use this for initialization
	void Start ()
    {
        id = 0;
	}
	
    public void DisplayRooms()
    {
        roomImages[0].sprite = rooms[id].icon;
        roomImages[1].sprite = rooms[id + 1].icon;
        roomImages[2].sprite = rooms[id + 2].icon;
        roomImages[3].sprite = rooms[id + 3].icon;

        goldTexts[0].text = rooms[id].goldCost.ToString("n0");
        goldTexts[1].text = rooms[id + 1].goldCost.ToString("n0");
        goldTexts[2].text = rooms[id + 2].goldCost.ToString("n0");
        goldTexts[3].text = rooms[id + 3].goldCost.ToString("n0");

        foodTexts[0].text = rooms[id].foodCost.ToString("n0");
        foodTexts[1].text = rooms[id + 1].foodCost.ToString("n0");
        foodTexts[2].text = rooms[id + 2].foodCost.ToString("n0");
        foodTexts[3].text = rooms[id + 3].foodCost.ToString("n0");

        magicTexts[0].text = rooms[id].magicCost.ToString("n0");
        magicTexts[1].text = rooms[id + 1].magicCost.ToString("n0");
        magicTexts[2].text = rooms[id + 2].magicCost.ToString("n0");
        magicTexts[3].text = rooms[id + 3].magicCost.ToString("n0");

        humanTexts[0].text = rooms[id].humanCost.ToString("n0");
        humanTexts[1].text = rooms[id + 1].humanCost.ToString("n0");
        humanTexts[2].text = rooms[id + 2].humanCost.ToString("n0");
        humanTexts[3].text = rooms[id + 3].humanCost.ToString("n0");

        effects[0].text = rooms[id].textEffect;
        effects[1].text = rooms[id + 1].textEffect;
        effects[2].text = rooms[id + 2].textEffect;
        effects[3].text = rooms[id + 3].textEffect;

        pillages[0].text = rooms[id].textPillage;
        pillages[1].text = rooms[id + 1].textPillage;
        pillages[2].text = rooms[id + 2].textPillage;
        pillages[3].text = rooms[id + 3].textPillage;

        if(player.GetGold() >= rooms[id].goldCost && player.GetFood() >= rooms[id].foodCost && player.GetMagic() >= rooms[id].magicCost && player.GetHuman() >= rooms[id].humanCost)
        {
            purchases[0].interactable = true;
        }
        else
        {
            purchases[0].interactable = false;
        }

        if (player.GetGold() >= rooms[id + 1].goldCost && player.GetFood() >= rooms[id + 1].foodCost && player.GetMagic() >= rooms[id + 1].magicCost && player.GetHuman() >= rooms[id + 1].humanCost)
        {
            purchases[1].interactable = true;
        }
        else
        {
            purchases[1].interactable = false;
        }

        if (player.GetGold() >= rooms[id + 2].goldCost && player.GetFood() >= rooms[id + 2].foodCost && player.GetMagic() >= rooms[id + 2].magicCost && player.GetHuman() >= rooms[id + 2].humanCost)
        {
            purchases[2].interactable = true;
        }
        else
        {
            purchases[2].interactable = false;
        }

        if (player.GetGold() >= rooms[id + 3].goldCost && player.GetFood() >= rooms[id + 3].foodCost && player.GetMagic() >= rooms[id + 3].magicCost && player.GetHuman() >= rooms[id + 3].humanCost)
        {
            purchases[3].interactable = true;
        }
        else
        {
            purchases[3].interactable = false;
        }
    }

    public void Purchase(int i)
    {
        rooms[id + i].PurchaseRoom();
    }



}
