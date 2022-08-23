using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStateManager : MonoBehaviour
{
    public ItemBaseState currentState;
    public ItemIdleState idleState = new ItemIdleState();
    public ItemShowUpState showUpState = new ItemShowUpState();
    public ItemHideState hideState = new ItemHideState();
    public ItemWaitingState waitingState = new ItemWaitingState();
    public ItemMovingState movingState = new ItemMovingState();
    public ItemPutOnState putOnState = new ItemPutOnState();

    public int itemCount;
    public int itemNumber;
    public int wardrobeNumber;
    public bool movingTrigger;
    public Vector3 startLocalScale;
    public List<Vector2> items;

    Color baseColor;

    void Start()
    {
        startLocalScale = transform.localScale;
        currentState = idleState;

        currentState.EnterState(this);
        MeshRenderer rend = transform.GetComponent<MeshRenderer>();
        baseColor = rend.material.color;
    }

    void Update()
    {
        currentState.UpdateState(this);
    }
    private void FixedUpdate()
    {
        currentState.FixedUpdateState(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnCollisionEnter(this, other);
        if (other.gameObject.name == "line")
        {
            MeshRenderer renderer = transform.GetComponent<MeshRenderer>();
            renderer.material.color = Color.green;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        currentState.OnCollisionExit(this, other); 
        if (other.gameObject.name == "line")
        {
            MeshRenderer renderer = transform.GetComponent<MeshRenderer>();
            renderer.material.color = baseColor;
        }
    }

    public void SwitchState(ItemBaseState state)
    {
        state.ExitState(this);

        currentState = state;
        state.EnterState(this);
    }

}
