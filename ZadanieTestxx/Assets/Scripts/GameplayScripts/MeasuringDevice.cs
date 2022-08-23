using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeasuringDevice : MonoBehaviour
{
    public TextMesh textMesh;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Door"))
                {
                    DoorStateManager door = hit.transform.GetComponent<DoorStateManager>();
                    textMesh.text = door.doorValue.ToString();
                    EventManager.StartMeasuringEvent(door.doorID);
                    Debug.Log(door.doorValue);
                }
            }
        }
    }
}
