using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorNeutralizedState : DoorBaseState
{
    int doorID;
    int doorToOpenID;
    public override void EnterState(DoorStateManager item)
    {
        doorID = -1; doorToOpenID = -1;
        item.doorValue = 0;
        EventManager.MeasuringEvent += MeasuringEvent;
        EventManager.OpenDoorEvent += OpenDoorEvent;
        EventManager.StartEndingCalcEvent(1);
    }

    public override void UpdateState(DoorStateManager item)
    {
        if (doorID == item.doorID)
        {
            item.SwitchState(item.checkedState);
        }
        if (doorToOpenID == item.doorID)
        {
            EventManager.StartEndingCalcEvent(0, 0, 1);
            item.SwitchState(item.brokenState);
        }
    }
    private void MeasuringEvent(int doorID)
    {
        this.doorID = doorID;
    }
    private void OpenDoorEvent(int doorID)
    {
        doorToOpenID = doorID;
    }
    public override void ExitState(DoorStateManager item)
    {
        EventManager.MeasuringEvent -= MeasuringEvent;
        EventManager.OpenDoorEvent -= OpenDoorEvent;
    }
}
