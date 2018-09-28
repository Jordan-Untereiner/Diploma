using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomId : MonoBehaviour {

    public int id;
    public bool underground;

    public void DropMonster()
    {
        Debug.Log("Monstre dropped on room : " + id);
        if (underground)
        {
            Debug.Log("This is an underground room");
        }
    }
}
