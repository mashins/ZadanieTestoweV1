using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    int maxEQ = 7;
    int eqNow = 0;

    bool trigger;
    bool isReadyToStart = false;

    MeshRenderer redn;

    Color baseColor;
    void Start()
    {
        MeshRenderer renderer = transform.GetComponent<MeshRenderer>();
        baseColor = renderer.material.color;

        EventManager.CountingEvent += CountingEvent;
        redn = transform.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && trigger)
        {
            SceneManager.LoadScene(1);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "line" && isReadyToStart)
        {
            trigger = true;
            redn.material.color = Color.green;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "line" && isReadyToStart)
        {
            trigger = false;
            redn.material.color = Color.yellow;
        }
    }
    public void CountingEvent(int numberToAdd)
    {
        eqNow += numberToAdd;
        if (eqNow == maxEQ)
        {
            isReadyToStart = true; 
            redn.material.color = Color.yellow;
        }
        else
        {
            redn.material.color = baseColor;
            isReadyToStart = false;
        }
    }

    private void OnDisable()
    {
        EventManager.CountingEvent -= CountingEvent;
    }
}
