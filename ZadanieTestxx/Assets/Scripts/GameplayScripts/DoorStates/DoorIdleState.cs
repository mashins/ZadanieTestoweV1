using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorIdleState : DoorBaseState
{
    int doorID = -1;
    int shootValue = -1;

    int doorToOpenID = -1;

    public override void EnterState(DoorStateManager item)
    {
        doorID = -1; shootValue = -1; doorToOpenID = -1;
        EventManager.DoorEvent += ShootingEvent;
        EventManager.OpenDoorEvent += OpenDoorEvent;
    }

    public override void UpdateState(DoorStateManager item)
    {
        if (item.doorID == doorID)
        {
            if (item.doorValue == shootValue)
            {
                item.SwitchState(item.neutralizedState);
            }
            else if (item.doorValue > shootValue)
            {
                EventManager.StartEndingCalcEvent(0, 0, 0, 0, 1);
                doorID = -1;
            }
            else 
            {
                EventManager.StartEndingCalcEvent(0, 0, 0, 1);
                doorID = -1;
            }
        }
        if (item.doorID == doorToOpenID)
        {
            item.SwitchState(item.brokenState);
        }
    }

    public void ShootingEvent(int doorID, int shootValue)
    {
        this.doorID = doorID;
        this.shootValue = shootValue;
    }
    private void OpenDoorEvent(int doorID)
    {
        doorToOpenID = doorID;
    }
    public override void ExitState(DoorStateManager item)
    {
        EventManager.DoorEvent -= ShootingEvent;
        EventManager.OpenDoorEvent -= OpenDoorEvent;
    }
}
