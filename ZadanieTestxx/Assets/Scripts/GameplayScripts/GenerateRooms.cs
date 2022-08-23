using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRooms : MonoBehaviour
{
    public GameObject room;

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject room2 = Instantiate(room, Vector3.zero, Quaternion.Euler(new Vector3(0,90 * i,0)));
            room2.GetComponentInChildren<DoorStateManager>().doorID = i;
            RoomWall[] walls = room2.GetComponentsInChildren<RoomWall>();
            for (int x = 0; x < walls.Length; x++)
            {
                walls[x].roomID = i;
                walls[x].wallID = x;
            }
        }    
    }

}
