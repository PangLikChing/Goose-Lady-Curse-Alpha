using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredatorIdleState : PredatorBaseState
{

    float waitTimer = 5f;

    AvatarNormalMotion avatar;

    public override void EnterState(Predator predator)
    {

        avatar = GameObject.FindObjectOfType<AvatarNormalMotion>();

        waitTimer = 5f;

        Debug.Log("Idle State");
        

    }

    public override void UpdateState(Predator predator)
    {
        RangeCheck(predator);
    }

    public override void FixedUpdateState(Predator predator)
    {

        //Timer for staying Idle for 5 seconds after entering idleState
        if (waitTimer >= 0)
        {
            waitTimer -= Time.fixedDeltaTime;
        }

        //After 5 seconds go back to Patrolling
        else
        {
            waitTimer = 5f;
            predator.SwitchState(predator.predatorPatrollingState);
        }

        
    }

    //Checking the range for Player range
    void RangeCheck(Predator predator)
    {
        if (Vector3.Distance(avatar.transform.position, predator.transform.position) < 8f)
        {
            
            predator.SwitchState(predator.predatorAttackState);
        }
    }
}
