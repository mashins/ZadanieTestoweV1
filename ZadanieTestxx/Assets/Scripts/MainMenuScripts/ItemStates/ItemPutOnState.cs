using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPutOnState : ItemBaseState
{
    bool trigger;
    int wardrobeID;
    public override void EnterState(ItemStateManager item)
    {
        trigger = true;
        wardrobeID = item.wardrobeNumber;
        EventManager.OpenWardrobeEvent += LastWardrobeNumber;
        EventManager.StartCountingEvent(1);
    }
    public override void UpdateState(ItemStateManager item)
    {
        if (Input.GetMouseButtonDown(0) && trigger)
        {
            item.transform.localScale = item.startLocalScale;
            item.items.Add(new Vector2(item.wardrobeNumber, item.itemNumber));
            EventManager.StartCountingEvent(-1);
            item.SwitchState(item.movingState);
        }
        if (Input.GetMouseButtonDown(1) && trigger)
        {
            item.transform.localScale = item.startLocalScale;
            item.movingTrigger = false;
            item.items.Add(new Vector2(item.wardrobeNumber, item.itemNumber));
            EventManager.StartCountingEvent(-1);
            if (item.wardrobeNumber != wardrobeID)
            {
                item.SwitchState(item.idleState);
            }
            else
            {
                item.SwitchState(item.waitingState);
            }
        }
    }

    public void LastWardrobeNumber(int wardrobeID)
    {
        this.wardrobeID = wardrobeID;
    }

    public override void FixedUpdateState(ItemStateManager item)
    {

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
        EventManager.OpenWardrobeEvent -= LastWardrobeNumber;
    }
}
