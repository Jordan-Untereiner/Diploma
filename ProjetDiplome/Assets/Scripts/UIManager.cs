using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text goldAmount;
    public Text foodAmount;
    public Text magicAmount;
    public Text humanAmount;
    public Text reputationAmount;

    public Text days;
    public Text months;
    public Text years;

    public GameObject roomUI;
    public GameObject monsterUI;

    public MonsterIcons[] monsterIcons;

    private int monsterIconId;

    private Player player;

	// Use this for initialization
	void Start ()
    {
        player = FindObjectOfType<Player>();
        UpdateRessources();
        UpdateDate();
        EscapeAll();
        monsterIconId = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EscapeAll();
        }
	}

    public void UpdateRessources() //Affiche les nouvelles valeurs de ressources
    {
        goldAmount.text = player.GetGold().ToString("n0");
        foodAmount.text = player.GetFood().ToString("n0");
        magicAmount.text = player.GetMagic().ToString("n0");
        humanAmount.text = player.GetHuman().ToString("n0");
        reputationAmount.text = player.GetReputation().ToString("n0");
    }

    public void UpdateDate() //Affiche la nouvelle date
    {
        days.text = player.GetDate()[0].ToString();

        if (player.GetDate()[1] < 10)
        {
            months.text = "0"+player.GetDate()[1].ToString();
        }
        else
        {
            months.text = player.GetDate()[1].ToString();
        }

        years.text = player.GetDate()[2].ToString();
    }

    public void EscapeAll() // Ferme toutes les fenêtres pop-up
    {
        EscapeRoomUI();
        EscapeMonsterUI();
    }

    public void EscapeRoomUI() //Ferme la fenêtre de l'achat de salles
    {
        roomUI.SetActive(false);
    }

    public void RoomUI() // Affiche la fenêtre de l'achat de salles
    {
        roomUI.SetActive(true);
        roomUI.GetComponent<RoomPanel>().DisplayRooms();
    }

    public void EscapeMonsterUI()
    {
        monsterUI.SetActive(false);
    }

    public void MonsterUI()
    {
        monsterUI.SetActive(true);
        monsterUI.GetComponent<MonsterPanel>().DisplayMonsters();
    }

    public void DisplayMonsterList()
    {
        for(int i=0; i<4; i++)
        {
            if(monsterIconId + i < player.GetMonsters().Count)
            {
                monsterIcons[i].GetNewMonster(player.GetMonsters()[monsterIconId + i]);
            }
        }
    }




}
