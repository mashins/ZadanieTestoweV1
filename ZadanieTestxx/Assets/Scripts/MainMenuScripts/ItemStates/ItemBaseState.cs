using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBaseState
{
    public abstract void EnterState(ItemStateManager item);
    public abstract void UpdateState(ItemStateManager item);
    public abstract void FixedUpdateState(ItemStateManager item);
    public abstract void OnCollisionEnter(ItemStateManager item, Collider other);
    public abstract void OnCollisionExit(ItemStateManager item, Collider other);
    public abstract void ExitState(ItemStateManager item);
}
