using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBrokenState : DoorBaseState
{
    public override void EnterState(DoorStateManager item)
    {
        EventManager.StartEndingCalcEvent(0, 0, 0, 0, 0, 0, 6);
        EventManager.StartGetDamageEvent();
        EventManager.StartRoomEvent(item.doorID);
       
    }
    public override void UpdateState(DoorStateManager item)
    {

    }
    public override void ExitState(DoorStateManager item)
    {

    }


}
