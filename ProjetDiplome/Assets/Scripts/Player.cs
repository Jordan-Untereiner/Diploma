using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Tower tower;
    private UIManager ui;
    private Dungeon dungeon;

    private List<Monster> monsters;

    private int gold;
    private int food;
    private int magic;
    private int human;
    private int reputation;


    private int monsterCapacity;
    private int towerCapacity;

    private int maxGold;
    private int maxFood;
    private int maxMagic;
    private int maxHuman;
    private int maxReputation;

    private int day;
    private int month;
    private int year;

    private int goldGeneration;
    private int foodGeneration;
    private int magicGeneration;
    private int humanGeneration;

	// Use this for initialization
	void Start ()
    {
        tower = FindObjectOfType<Tower>();
        ui = FindObjectOfType<UIManager>();
        dungeon = FindObjectOfType<Dungeon>();
        monsters = new List<Monster>();

        //Initialisation des ressources
        monsterCapacity = 10;
        towerCapacity = 4;
        gold = 1000;
        food = 500;
        magic = 100;
        human = 0;
        reputation = 20;

        //Initialisation des ressources max
        maxGold = 5000;
        maxFood = 2000;
        maxMagic = 500;
        maxHuman = 0;
        maxReputation = 10000;

        //Initialisation date
        day = 21;
        month = 5;
        year = 1287;

        //Initialisation de l'income
        goldGeneration = 0;
        foodGeneration = 0;
        magicGeneration = 0;
        humanGeneration = 0;
	}
	


    //Accesseurs


    public void GainGold(int g)
    {
        gold += g;
        if (gold > maxGold)
        {
            gold = maxGold;
        }

    }

    public void GainFood(int f)
    {
        food += f;
        if (food > maxFood)
        {
            food = maxFood;
        }
    }

    public void GainMagic(int m)
    {
        magic += m;
        if (magic > maxMagic)
        {
            magic = maxMagic;
        }
    }

    public void GainHuman(int h)
    {
        human += h;
        if(human > maxHuman)
        {
            human = maxHuman;
        }
    }

    public void LoseGold(int g)
    {
        gold -= g;
        if (gold < 0)
        {
            gold = 0;
        }

    }

    public void LoseFood(int f)
    {
        food -= f;
        if (food < 0)
        {
            food = 0;
        }
    }

    public void LoseMagic(int m)
    {
        magic -= m;
        if (magic < 0)
        {
            magic = 0;
        }
    }

    public void LoseHuman(int h)
    {
        human -= h;
        if (human < 0)
        {
            human = 0;
        }
    }

    public int GetGold()
    {
        return gold;
    }

    public int GetFood()
    {
        return food;
    }

    public int GetMagic()
    {
        return magic;
    }

    public int GetHuman()
    {
        return human;
    }

    public void IncreaseTowerCapacity(int t)
    {
        towerCapacity += t;
    }

    public void IncreaseMonsterCapacity(int m)
    {
        monsterCapacity += m;
    }

    public int GetTowerCapacity()
    {
        return towerCapacity;
    }

    public int GetMonsterCapacity()
    {
        return monsterCapacity;
    }

    public Tower GetTower()
    {
        return tower;
    }

    public List<Monster> GetMonsters()
    {
        return monsters;
    }

    public int[] GetDate()
    {
        int[] date = new int[3];
        date[0] = day;
        date[1] = month;
        date[2] = year;
        return date;
    }

    public void GainReputation(int r)
    {
        reputation += r;
        if (reputation > maxReputation)
        {
            reputation = maxReputation;
        }
    }

    public void LoseReputation(int r)
    {
        reputation -= r;
        if (reputation < 0)
        {
            reputation = 0;
        }
    }

    public int GetReputation()
    {
        return reputation;
    }

    public void IncreaseGoldGeneration(int g)
    {
        goldGeneration += g;
    }

    public void DecreaseGoldGeneration(int g)
    {
        goldGeneration -= g;
    }

    public void IncreaseFoodGeneration(int g)
    {
        foodGeneration += g;
    }

    public void DecreaseFoodGeneration(int g)
    {
        foodGeneration -= g;
    }

    public void IncreaseMagicGeneration(int g)
    {
        magicGeneration += g;
    }

    public void DecreaseMagicGeneration(int g)
    {
        magicGeneration -= g;
    }

    public void IncreaseHumanGeneration(int g)
    {
        humanGeneration += g;
    }

    public void DecreaseHumanGeneration(int g)
    {
        humanGeneration -= g;
    }

    // Fin accesseurs

    public void AddDay() //Ajoute un jour
    {
        day++;
        if(month==2 && day > 28)
        {
            day = 1;
            month++;
        }
        else if((month==4 || month==6 || month==9 || month==11) && day > 30)
        {
            day = 1;
            month++;
        }
        else if ((month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12) && day > 31)
        {
            day = 1;
            month++;
            if (month > 12)
            {
                month = 1;
                year++;
            }
        }

        ui.UpdateDate();

        GenerateRessources();
        Construction();
    }

    public void GenerateRessources() //Génère les ressources quotidiennes
    {
        GainGold(goldGeneration);
        GainFood(foodGeneration);
        GainMagic(magicGeneration);
        GainHuman(humanGeneration);
        ui.UpdateRessources();
    }

    public void Construction() //Avance les constructions
    {
        if (tower.RoomsNumber() != 0)
        {
            foreach(Room r in tower.CurrentTower())
            {
                if (r.StillInConstruction())
                {
                    r.Construct();
                }
            }
        }
        dungeon.UpdateDungeon();
    }

    public void RecruitMonster(Monster m)
    {
        monsters.Add(m);
        ui.DisplayMonsterList();
    }
}
