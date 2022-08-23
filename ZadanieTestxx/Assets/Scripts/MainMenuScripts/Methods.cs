using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Methods
{
    public Vector3 GetMousePos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
