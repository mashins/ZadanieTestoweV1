using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHideState : ItemBaseState
{
    int wardrobeID;
    public override void EnterState(ItemStateManager item)
    {
        wardrobeID = -1;
        EventManager.WardrobeOverEvent += WardrobeOver;
    }
    public override void UpdateState(ItemStateManager item)
    {
        if (item.transform.position.x < item.transform.parent.position.x)
        {
            EventManager.StartOpenWardrobeEvent(-1);
            item.SwitchState(item.idleState);
        }
        if (item.wardrobeNumber == wardrobeID)
        {
            item.SwitchState(item.showUpState);
        }
    }
    public override void FixedUpdateState(ItemStateManager item)
    {
        item.transform.position += 30 * Time.deltaTime * Vector3.left;
    }
    public void WardrobeOver(int wardrobeID)
    {
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
        EventManager.WardrobeOverEvent -= WardrobeOver;
    }


}
