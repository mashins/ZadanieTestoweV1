using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DoorBaseState
{
    public abstract void EnterState(DoorStateManager item);
    public abstract void UpdateState(DoorStateManager item);
    public abstract void ExitState(DoorStateManager item);
}
