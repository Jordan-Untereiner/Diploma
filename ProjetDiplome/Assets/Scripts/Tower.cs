using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    private List<Room> tower;
    private List<Room> undergroundTower;

    private Room top;

	// Use this for initialization
	void Start ()
    {
        tower = new List<Room>();
        undergroundTower = new List<Room>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Accesseurs

    public int RoomsNumber()
    {
        return tower.Count;
    }

    public int UndergroundNumber()
    {
        return undergroundTower.Count;
    }

    public List<Room> CurrentTower()
    {
        return tower;
    }

    public List<Room> CurrentUnderground()
    {
        return undergroundTower;
    }


    //Fin accesseurs

    public void ChangeTop(Room t) // Change le toit
    {
        top = t;
    }

    public void AddTower(Room r) // Ajoute une pièce à la tour, sous le toit
    {
        if (top!=null)
        {
            tower.Insert(tower.IndexOf(top), r);
        }
        else
        {
            tower.Add(r);
        }

    }

    public void AddUnderground(Room r) // Ajoute une pièce au sous-sol
    {
        undergroundTower.Add(r);
    }
}
