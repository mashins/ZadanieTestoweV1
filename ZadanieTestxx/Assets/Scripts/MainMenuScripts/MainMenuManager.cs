using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public List<ItemStateManager> allItems = new List<ItemStateManager>();
    void Start()
    {
        EventManager.WardrobeOverEvent += WardrobeAllItemsAreEvent;
    }

    public void WardrobeAllItemsAreEvent(int wardrobeID)
    {
        bool isAllIdle = true;
        for (int i = 0; i < allItems.Count; i++)
        {
            if (!(allItems[i].currentState == allItems[i].idleState || allItems[i].currentState == allItems[i].putOnState))
            {
                isAllIdle = false;
                break;
            }
        }
        if (isAllIdle)
        {
            EventManager.StartWardroveEvent(wardrobeID);

            EventManager.StartOpenWardrobeEvent(wardrobeID);
        }
    }

    private void OnDisable()
    {
        EventManager.WardrobeOverEvent -= WardrobeAllItemsAreEvent;
    }
}
