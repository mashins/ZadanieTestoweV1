using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWaitingState : ItemBaseState
{
    int wardrobeID;
    bool wardrobeClose;
    int wardrobeID2 = -1;

    bool trigger;
    float xPos;

    public override void EnterState(ItemStateManager item)
    {
        xPos = item.transform.parent.position.x + 2 + (item.itemCount - item.itemNumber) * 2;
        item.transform.position = new Vector3(xPos, item.transform.parent.position.y, item.transform.position.z);
        wardrobeID = -1; wardrobeClose = false; trigger = false;
        EventManager.WardrobeOverEvent += WardrobeHover;
        EventManager.AllItemsWaitingEvent += AllItemsAreWaiting;
    }
    public override void UpdateState(ItemStateManager item)
    {
        if (item.wardrobeNumber != wardrobeID && wardrobeClose && wardrobeID2 != item.wardrobeNumber)
        {
            item.SwitchState(item.hideState);
        }
        if (trigger && Input.GetMouseButtonDown(0))
        {
            item.SwitchState(item.movingState);
        }

    }
    public override void FixedUpdateState(ItemStateManager item)
    {

    }
    public void WardrobeHover(int wardrobeID)
    {
        wardrobeClose = true;
        this.wardrobeID = wardrobeID; 
    }
    public void AllItemsAreWaiting(int wardrobeID)
    {
        wardrobeID2 = wardrobeID; 
        wardrobeClose = false;
    }
    public override void OnCollisionEnter(ItemStateManager item, Collider other)
    {
        if (other.gameObject.name == "line")
        {
            trigger = true;
        }
    }
    public override void OnCollisionExit(ItemStateManager item, Collider other)
    {
        if (other.gameObject.name == "line")
        {
            trigger = false;
        }
    }
    public override void ExitState(ItemStateManager item)
    {
        EventManager.WardrobeOverEvent -= WardrobeHover; 
        EventManager.AllItemsWaitingEvent -= AllItemsAreWaiting;
    }
}
