using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {

    public int goldCost;
    public int foodCost;
    public int magicCost;
    public int humanCost;

    public int populationLimit;
    public int trapLimit;

    public int constructionTime;

    public Sprite icon;
    public string roomName;

    public int levelMax;

    public bool testGeneration;  //Booléen test

    public string textEffect;
    public string textPillage;

    protected int population; //Liste Monstre
    protected int traps;  // Liste pièges
    protected int constructionLeft;

    protected int level;

    protected Player player;
    protected UIManager ui;
    protected Dungeon dungeon;


	// Use this for initialization
	void Start ()
    {
        player = FindObjectOfType<Player>();
        ui = FindObjectOfType<UIManager>();
        dungeon = FindObjectOfType<Dungeon>();
        population = 0;
        traps = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PurchaseRoom() // Dépense les ressources pour la construction d'une salle
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
        AddRoom();
        ui.UpdateRessources();
        dungeon.UpdateDungeon();
        ui.EscapeAll();
    }

    public void AddRoom() // Ajoute la salle à la tour
    {
        player.GetTower().AddTower(this);
        if(constructionTime < 1)
        {
            Effect();
        }
        else
        {
            constructionLeft = constructionTime;
        }
    }

    public void AddUndergroundRoom()
    {
        Dungeon d = FindObjectOfType<Dungeon>();
        d.UndergroundRoom();
        player.GetTower().AddUnderground(this);
        if (constructionTime < 1)
        {
            Effect();
        }
        else
        {
            constructionLeft = constructionTime;
        }
    }

    public bool StillInConstruction() //Vérifie si la salle est construite ou pas
    {
        return constructionLeft > 0;
    }

    public void Construct() //Avance la construction et déclenche l'effet si la salle est terminée
    {
        constructionLeft--;
        if(constructionLeft <= 0)
        {
            Effect();
        }
    }

    public int GetConstructionLeft()
    {
        return constructionLeft;
    }

    public virtual void Effect() { } //Fonction utilisée à la création de la salle

    public virtual void Pillage() { } //Fonction utilisée lors du pillage de la salle
}
