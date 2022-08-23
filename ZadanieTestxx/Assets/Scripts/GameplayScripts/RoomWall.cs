using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class RoomWall : MonoBehaviour
{
    public int roomID;
    public int wallID;

    int doorID = -1;
    int shootingValue = 0;
    int shots = 0;

    int shotsToComplete = 6;

    bool succesComplete = true;


    void Start()
    {
        EventManager.RoomEvent += RoomEvent;
        EventManager.WallEvent += WallEvent;
        EventManager.CompletedRoomEvent += CompletedRoomEvent;
    }


    private void WallEvent(int roomID, int wallID, int shootingValue)
    {
        if (doorID == this.roomID && this.roomID == roomID && this.wallID == wallID)
        {
            if (this.shootingValue == shootingValue)
            {
                shots++;
                if (shots > 1)
                {
                    EventManager.StartEndingCalcEvent(0, 0, 0, 0, 0, 0, 0, 1);
                    EventManager.StartCompletedRoomEvent(roomID, wallID, false);
                }
                else
                {
                    transform.GetComponent<MeshRenderer>().material.color = Color.green;
                    StartCoroutine(Wait(1.0f));
                    EventManager.StartEndingCalcEvent(0, 0, 0, 0, 0, 0, -1);
                    EventManager.StartCompletedRoomEvent(roomID, wallID, true);
                }
            }
            else
            {
                EventManager.StartCompletedRoomEvent(roomID, wallID, false);
                EventManager.StartEndingCalcEvent(0, 0, 0, 0, 0, 1);
            }
        }

    }
    private void CompletedRoomEvent(int roomID, int wallID, bool succes)
    {
        
        if (this.roomID == roomID)
        {
            if (succes)
            {
                shotsToComplete--;
                if (shotsToComplete == 0 && wallID == this.wallID)
                {
                    EventManager.StartEndingCalcEvent(0, 0, 0, 0, 0, 0, 0, 0, 1);
                    VisualEffect vis = transform.parent.GetComponent<VisualEffect>(); 
                    vis.SetBool("isSuccesfully", false);
                    vis.Play();

                }
                if (shotsToComplete == 0 && wallID == this.wallID && succesComplete)
                {
                    EventManager.StartEndingCalcEvent(0, 1); 
                    VisualEffect vis = transform.parent.GetComponent<VisualEffect>();
                    vis.SetBool("isSuccesfully", true);
                    vis.Play();
                }
            }
            else
            {
                succesComplete = succes;
            }
        }
    }

    private void RoomEvent(int doorID)
    {
        if (roomID == doorID)
        {
            this.doorID = doorID;
        }
    }
    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        transform.GetComponent<MeshRenderer>().material.color = Color.white;
    }
    private void OnDisable()
    {
        EventManager.RoomEvent -= RoomEvent;
        EventManager.WallEvent -= WallEvent;
        EventManager.CompletedRoomEvent -= CompletedRoomEvent;
    }
}
