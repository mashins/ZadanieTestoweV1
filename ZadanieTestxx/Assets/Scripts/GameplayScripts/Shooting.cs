using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;



public class Shooting : MonoBehaviour
{
    public TextMesh textMesh;
    VisualEffect vis;
    
    void Start()
    {
       vis = transform.GetComponentInChildren<VisualEffect>();
    }
    public int selectedNumber = 0;
    private KeyCode[] keyCodes = {
         KeyCode.Alpha0,
         KeyCode.Alpha1,
         KeyCode.Alpha2,
         KeyCode.Alpha3,
         KeyCode.Alpha4,
         KeyCode.Alpha5,
         KeyCode.Alpha6,
         KeyCode.Alpha7,
         KeyCode.Alpha8,
         KeyCode.Alpha9,
    };
    void Update()
    {
        for (int i = 0; i < keyCodes.Length; i++)
        {
            if (Input.GetKeyDown(keyCodes[i]))
            {
                selectedNumber = i;
                textMesh.text = i.ToString();
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            vis.Play();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Door"))
                {
                    Debug.Log("Shot"); 
                    DoorStateManager door = hit.transform.GetComponent<DoorStateManager>();
                    EventManager.StartDoorEvent(door.doorID, selectedNumber);

                }
                if (hit.transform.CompareTag("RoomWall"))
                {
                    RoomWall roomWall = hit.transform.GetComponent<RoomWall>();
                    EventManager.StartWallEvent(roomWall.roomID, roomWall.wallID, selectedNumber);
                }
            }

        }
    }
}
