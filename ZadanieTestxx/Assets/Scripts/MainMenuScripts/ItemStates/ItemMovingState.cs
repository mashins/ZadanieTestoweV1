using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMovingState : ItemBaseState
{
    Transform bodyPart;
    Methods methods = new Methods();
    int wardrobeID = -1;
    //bool trigger;
    public override void EnterState(ItemStateManager item)
    {
        EventManager.StartHighlightEvent(item.tag, false);
        EventManager.OpenWardrobeEvent += LastWardrobeNumber;
        if (!item.movingTrigger)
        {
            EventManager.StartOpenWardrobeEvent(item.wardrobeNumber);
        }
    }
    public override void UpdateState(ItemStateManager item)
    {
        item.transform.position = methods.GetMousePos(); 
        EventManager.StartCheckWaitEvent(item.wardrobeNumber);
        if (Input.GetMouseButtonDown(0))
        {
            EventManager.StartCheckWaitEvent(-1);
            if (item.movingTrigger)
            {
                EventManager.StartHighlightEvent(item.tag, true);
                item.items.Remove(new Vector2(item.wardrobeNumber, item.itemNumber));
                item.transform.position = bodyPart.transform.position;
                float x = bodyPart.transform.lossyScale.x / item.transform.parent.localScale.x;
                float y = bodyPart.transform.lossyScale.y / item.transform.parent.localScale.y;
                float z = bodyPart.transform.lossyScale.z / item.transform.parent.localScale.z;
                Vector3 newScale = new Vector3(x * 1.1f,y,z * 1.1f);
                item.transform.localScale = newScale;
                item.SwitchState(item.putOnState);
            }
            else
            {
                EventManager.StartHighlightEvent(item.tag, true);
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
        if (item.gameObject.CompareTag(other.gameObject.tag) && other.gameObject.layer != 8)
        {
            bodyPart = other.transform;
            item.movingTrigger = true;
        }
    }
    public override void OnCollisionExit(ItemStateManager item, Collider other)
    {
        if (item.gameObject.CompareTag(other.gameObject.tag) && other.gameObject.layer != 8)
        {
            item.movingTrigger = false;
        }
    }
    public override void ExitState(ItemStateManager item)
    {
        EventManager.OpenWardrobeEvent -= LastWardrobeNumber;
    }
}
