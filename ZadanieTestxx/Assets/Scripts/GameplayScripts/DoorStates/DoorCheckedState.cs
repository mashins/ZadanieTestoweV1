using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCheckedState : DoorBaseState
{
    int doorID;
    public override void EnterState(DoorStateManager item)
    {
        doorID = -1;
        EventManager.OpenDoorEvent += OpenDoorEvent;
    }


    public override void UpdateState(DoorStateManager item)
    {
        if (doorID == item.doorID)
        {
            item.SwitchState(item.openState);
        }
    }
    private void OpenDoorEvent(int doorID)
    {
        this.doorID = doorID;
    }

    public override void ExitState(DoorStateManager item)
    {
        EventManager.OpenDoorEvent -= OpenDoorEvent;
    }
}
