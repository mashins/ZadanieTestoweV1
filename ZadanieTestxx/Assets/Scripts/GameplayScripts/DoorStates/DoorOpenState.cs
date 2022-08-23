using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenState : DoorBaseState
{
    public override void EnterState(DoorStateManager item)
    {
        EventManager.StartEndingCalcEvent(0, 0, 0, 0, 0, 0, 6);
        EventManager.StartRoomEvent(item.doorID);
    }
    public override void UpdateState(DoorStateManager item)
    {
        if (item.transform.localRotation.y >= -0.6f)
        {
            item.transform.RotateAround(item.transform.parent.position, item.transform.up, -40f * Time.deltaTime);
        }
    }
    public override void ExitState(DoorStateManager item)
    {

    }
}
