using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public int health;
    public int level;
    public Sprite icon;

    protected Player player;
    protected UIManager ui;
    protected Dungeon dungeon;

    // Use this for initialization
    void Start ()
    {
        player = FindObjectOfType<Player>();
        ui = FindObjectOfType<UIManager>();
        dungeon = FindObjectOfType<Dungeon>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
