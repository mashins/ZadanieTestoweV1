using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    //public Camera cam
    // Start is called before the first frame update
    Methods methods = new Methods();
    BoxCollider boxCollider;
    LineRenderer line;
    void Start()
    {
        line = GetComponent<LineRenderer>();
        boxCollider = GetComponent<BoxCollider>();
        Vector3 newPos = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - 1, Camera.main.transform.position.z + 1);
        line.SetPosition(0, newPos);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = methods.GetMousePos();
        line.SetPosition(1, pos);
        boxCollider.center = pos;
        //Debug.DrawRay(Camera.main.ScreenPointToRay(Input.mousePosition));
       // Hitting();

    }

}
