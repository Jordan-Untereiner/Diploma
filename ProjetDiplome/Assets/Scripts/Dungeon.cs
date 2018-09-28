using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon : MonoBehaviour {

    public List<GameObject> dungeon;

    public List<GameObject> underground;

    private int undergroundIndex;

    public Material[] materials;

    private Player player;

	// Use this for initialization
	void Start ()
    {
        player = FindObjectOfType<Player>();
        CheckRoomAvailable();
        foreach(GameObject g in underground)
        {
            g.SetActive(false);
        }
        undergroundIndex = 0;
	}
	

    void CheckRoomAvailable() // Vérifie que chaque pièce est disponible ou non (par rapport à la limite de tour)
    {
        for(int i=0; i < dungeon.Count; i++)
        {
            if (i < player.GetTowerCapacity())
            {
                dungeon[i].GetComponent<MeshRenderer>().material = materials[0];
            }
            else
            {
                dungeon[i].GetComponent<MeshRenderer>().material = materials[1];
            }
                    
        }
    }

    public void UpdateDungeon() //Affiche les salles dans la tour
    {
        CheckRoomAvailable();
        Tower t = FindObjectOfType<Tower>();

        if(t.RoomsNumber() > 0)
        {
            int i = 0;
            while (i < t.RoomsNumber())
            {
                if (t.CurrentTower()[i].StillInConstruction())
                {
                    dungeon[i].GetComponent<MeshRenderer>().material = materials[4];
                }
                else if (t.CurrentTower()[i].testGeneration)
                {
                    dungeon[i].GetComponent<MeshRenderer>().material = materials[3];
                }
                else
                {
                    dungeon[i].GetComponent<MeshRenderer>().material = materials[2];
                }
                i++;
            }
        }

        if (t.UndergroundNumber() > 0)
        {
            int j = 0;
            while (j < t.UndergroundNumber())
            {
                if (t.CurrentUnderground()[j].StillInConstruction())
                {
                    underground[j].GetComponent<MeshRenderer>().material = materials[4];
                }
                else if (t.CurrentUnderground()[j].testGeneration)
                {
                    underground[j].GetComponent<MeshRenderer>().material = materials[3];
                }
                else
                {
                    underground[j].GetComponent<MeshRenderer>().material = materials[2];
                }
                j++;
            }
        }
    }

    public void UndergroundRoom()
    {
        underground[undergroundIndex].SetActive(true);
        undergroundIndex++;
    }
}
