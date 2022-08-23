using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BodyBehaviour : MonoBehaviour
{
    MeshRenderer rend;
    Color baseColor;

    void Start()
    {
        Rigidbody rb = transform.GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;
        EventManager.HighlightPartsEvent += HighlighPart;
        rend = transform.GetComponent<MeshRenderer>();
        baseColor = rend.material.color;
    }

    public void HighlighPart(string tagName, bool isBaseColor)
    {
        if (transform.gameObject.CompareTag(tagName))
        {
            if (!isBaseColor)
            {
                rend.material.color = Color.yellow;
            }
            else
            {
                rend.material.color = baseColor;
            }
        }
    }
    private void OnDisable()
    {
        EventManager.HighlightPartsEvent -= HighlighPart;
    }
}
