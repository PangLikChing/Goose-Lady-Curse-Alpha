using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PredatorAttackState : PredatorBaseState
{

    [Header("Components")]

    NavMeshAgent agent;
    AvatarNormalMotion avatar;

    Predator predatorScript;
    

    public override void EnterState(Predator predator)
    {
        //Getting Components
        agent = predator.GetComponent<NavMeshAgent>();
        avatar = GameObject.FindObjectOfType<AvatarNormalMotion>();
        predatorScript = predator.GetComponent<Predator>();

        Debug.Log("Attack State");

    }

    public override void UpdateState(Predator predator)
    {
        RangeCheck(predator);
        
    }

    public override void FixedUpdateState(Predator predator)
    {
        
    }

    void RangeCheck (Predator predator)
    {
        float howClose = 8f;
        float dist;
        float distPosition;

        bool isPlayerNear = false;


        dist = Vector3.Distance(avatar.transform.position, predator.transform.position);
        distPosition = Vector3.Distance(predatorScript.position.transform.position, predator.transform.position);


        if (dist <= howClose)
        {
            predator.transform.LookAt(avatar.transform);

            agent.SetDestination(avatar.transform.position);

            isPlayerNear = true;

            if (dist <= 1f)
            {
                predator.transform.LookAt(avatar.transform);
                agent.SetDestination(predator.transform.position);
                
            }

            if (distPosition >= 12f && isPlayerNear)
            {

                agent.SetDestination(predatorScript.position.transform.position);
                predator.SwitchState(predator.predatorPatrollingState);

            }



        }
    }
}
