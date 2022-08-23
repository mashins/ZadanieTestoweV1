using System.Collections;
using System.Collections.Generic;
using UnityEngine.VFX;
using UnityEngine;

public class DoorStateManager : MonoBehaviour
{
    public DoorBaseState currentState;
    public DoorIdleState idleState = new DoorIdleState();
    public DoorNeutralizedState neutralizedState = new DoorNeutralizedState();
    public DoorCheckedState checkedState = new DoorCheckedState();
    public DoorBrokenState brokenState = new DoorBrokenState();
    public DoorOpenState openState = new DoorOpenState();

    public int doorID;
    public int doorValue;

    void Start()
    {
        doorValue = Random.Range(1, 9);
        currentState = idleState;

        currentState.EnterState(this);
    }

    void Update()
    {
        currentState.UpdateState(this);

    }

    public void SwitchState(DoorBaseState state)
    {
        state.ExitState(this);

        currentState = state;
        state.EnterState(this);

        ForParticle(brokenState, false); ForParticle(neutralizedState, true);
    }
    public void ForParticle(DoorBaseState state, bool ex)
    {
        if (currentState == state)
        {
            VisualEffect vis = transform.GetComponentInChildren<VisualEffect>();
            vis.SetBool("isNeutralized", ex);
            vis.Play();
            StartCoroutine(Wait(2.0f, vis, ex));
        }
    }
    IEnumerator Wait(float waitTime, VisualEffect vis, bool ex)
    {
        yield return new WaitForSeconds(waitTime);
        if (!ex)
        {
            transform.gameObject.SetActive(false);
        }
        vis.Stop();
    }
}
