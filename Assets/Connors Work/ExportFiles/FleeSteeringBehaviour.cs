using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeSteeringBehaviour : SteeringBehaviourBase
{
    private Vector3 desiredForce;
    public GameObject Player;
    public GameObject Bunny;
    public GameObject arriveBehavior;
    public Vector3 pointToGoTo;
    public float Timer;
    public float NumberTimerWillStopAt;

    public void Awake()
    {
        //pointToGoTo.Set(Player.transform.position.x * -1, 0, Player.transform.position.z * -1);
        pointToGoTo.Set(35, 0, 17);
        target = pointToGoTo;
        Timer = 0;
    }

    public void Update()
    {
        if (Timer >= NumberTimerWillStopAt)
        {
            float distance = Vector3.Distance(Bunny.transform.position, Player.transform.position);

            if (distance > 4)
            {
                arriveBehavior.SetActive(true);
                this.gameObject.SetActive(false);
            }
            else
            {
                pointToGoTo.Set(35, 0, 17);
                target = pointToGoTo;
            }

            Timer = 0;
        }
        else
        {
            Timer += Time.deltaTime;
        }
    }

    public override Vector3 CalculateForce()
    {
        //CheckMouseInput();

        desiredForce = (transform.position - target).normalized;
        desiredForce = desiredForce * steeringAgent.maxForce;
        desiredForce = desiredForce - steeringAgent.velocity;

        return desiredForce;
    }

    private void OnDrawGizmos()
    {
        if (steeringAgent != null)
        {
            DebugExtension.DebugArrow(transform.position, desiredForce, Color.red);
            DebugExtension.DebugArrow(transform.position, steeringAgent.velocity, Color.blue);
            DebugExtension.DebugArrow(transform.position, (target - transform.position), Color.green);
            DebugExtension.DebugPoint(target, Color.green);
        }
    }
}
