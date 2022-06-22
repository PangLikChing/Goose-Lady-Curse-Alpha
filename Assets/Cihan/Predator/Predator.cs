using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Predator : MonoBehaviour
{
    [Header("Current State")]
    public PredatorBaseState currentState;

    [Header("States")]

    public PredatorIdleState predatorIdleState = new PredatorIdleState();
    public PredatorPatrollingState predatorPatrollingState = new PredatorPatrollingState();
    public PredatorAttackState predatorAttackState = new PredatorAttackState();

    [Header("Waypoints")]

    public WaypointCollector waypoints;


    [Header("Start Point")]

    public Transform position;

    // Start is called before the first frame update
    void Start()
    {
        currentState = predatorPatrollingState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    void FixedUpdate()
    {
        currentState.FixedUpdateState(this);
    }

    //Method for when states swtiched, setting current state and calling EnterState
    public void SwitchState(PredatorBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
