using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    //Menu
    public static event Action<int> WardrobeOverEvent;
    public static event Action<int,int> ItemEvent;
    public static event Action<int> WardrobeEvent; 
    public static event Action<int> AllItemsWaitingEvent;
    public static event Action<string, bool> HighlightPartsEvent;
    public static event Action<int> CountingEvent;
    public static event Action<int> OpenWardrobeEvent;

    //Gameplay
    public static event Action<int, int> DoorEvent;
    public static event Action<int> OpenDoorEvent;
    public static event Action<int> MeasuringEvent;
    public static event Action GetDamageEvent;

    public static event Action<int> RoomEvent;
    public static event Action<int,int,int> WallEvent;

    public static event Action<int, int, int, int, int, int, int, int, int, string> EndingCalcEvent;
    public static event Action<int, int, bool> CompletedRoomEvent;

    public static event Action<int> ChangeSceneEvent;

    public static void StartCheckWaitEvent(int wardrobeID)
    {
        AllItemsWaitingEvent?.Invoke(wardrobeID);
    }
    public static void StartWardroveEvent(int wardrobeID)
    {
        WardrobeEvent?.Invoke(wardrobeID);
    }

    public static void StartWardrobeOverEvent(int wardrobeID)
    {
        WardrobeOverEvent?.Invoke(wardrobeID);
    }

    public static void StartItemMoveEvent(int wardrobeID, int itemID)
    {
        ItemEvent?.Invoke(wardrobeID, itemID);
    }

    public static void StartOpenWardrobeEvent(int wardrobeID)
    {
        OpenWardrobeEvent?.Invoke(wardrobeID);
    }

    public static void StartHighlightEvent(string tagName, bool baseColor)
    {
        HighlightPartsEvent?.Invoke(tagName, baseColor);
    }

    public static void StartCountingEvent(int numberToADD)
    {
        CountingEvent?.Invoke(numberToADD);
    }

    public static void StartDoorEvent(int doorID, int shootValue)
    {
        DoorEvent?.Invoke(doorID, shootValue);
    }
    public static void StartOpenDoorEvent(int doorID)
    {
        OpenDoorEvent?.Invoke(doorID);
    }
    public static void StartMeasuringEvent(int doorID)
    {
        MeasuringEvent?.Invoke(doorID);
    }
    public static void StartGetDamageEvent()
    {
        GetDamageEvent?.Invoke();
    }
    public static void StartRoomEvent(int doorID)
    {
        RoomEvent?.Invoke(doorID);
    }
    public static void StartWallEvent(int roomID, int wallID, int shootingValue)
    {
        WallEvent?.Invoke(roomID, wallID, shootingValue);
    }

    public static void StartEndingCalcEvent(int sucessfulCompletedDoors = 0,
    int sucessfulCompletedRooms = 0,
    int meameasurementLack = 0,
    int exceededDoorValue = 0,
    int notEnoughShootValue = 0,
    int errorShotValueInRoom = 0,
    int skippedWalls = 0,
    int exceededShotsOnWalls = 0,
    int completedRooms = 0,
    string time = " ")
    {
        EndingCalcEvent?.Invoke(sucessfulCompletedDoors, sucessfulCompletedRooms, meameasurementLack, exceededDoorValue, notEnoughShootValue, errorShotValueInRoom, skippedWalls, exceededShotsOnWalls, completedRooms, time);
    }

    public static void StartCompletedRoomEvent(int roomID, int wallID, bool succes)
    {
        CompletedRoomEvent?.Invoke(roomID, wallID, succes);
    }
    public static void StartChangeSceneEvent(int sceneID)
    {
        ChangeSceneEvent?.Invoke(sceneID);
    }
}
