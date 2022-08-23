using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShowUpState : ItemBaseState
{
    bool test;
    int wardrobeID;
    bool wardrobeClose;
    public override void EnterState(ItemStateManager item)
    {
        test = false; wardrobeID = -1; wardrobeClose = false;
        EventManager.WardrobeOverEvent += WardrobeHover;
    }

    public override void UpdateState(ItemStateManager item)
    {
        
        float xPos = item.transform.parent.position.x + 2 + (item.itemCount - item.itemNumber) * 2;
        if (item.transform.position.x > xPos)
        {
            item.SwitchState(item.waitingState);
        }
        if (item.transform.position.x > item.transform.parent.position.x + 2 && !test)
        {
            for (int i = 1; i <= item.itemCount; i++)
            {
                if (item.items.Contains(new Vector2(item.wardrobeNumber, item.itemNumber + i)))
                {
                    EventManager.StartItemMoveEvent(item.wardrobeNumber, item.itemNumber + i - 1);
                    break;
                }
            }
            test = true;
        }
        if (item.wardrobeNumber != wardrobeID && wardrobeClose)
        {
            item.SwitchState(item.hideState);
        }
    }
    public override void FixedUpdateState(ItemStateManager item)
    {
        item.transform.position += 30 * Time.deltaTime * Vector3.right;
    }

    public void WardrobeHover(int wardrobeID)
    {
        wardrobeClose = true;
        this.wardrobeID = wardrobeID;
    }
    public override void OnCollisionEnter(ItemStateManager item, Collider other)
    {

    }
    public override void OnCollisionExit(ItemStateManager item, Collider other)
    {

    }

    public override void ExitState(ItemStateManager item)
    {
        EventManager.WardrobeOverEvent -= WardrobeHover;
    }
}
