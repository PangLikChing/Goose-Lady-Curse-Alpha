using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewArriveSteeringBehavior : SeekSteeringBehaviour
{
    public float SlowdownDistance = 1.0f;
    public float Deceleration = 2.5f;
    public float StoppingDistance = 0.1f;
    public Vector3 pointToGoTo1;
    public Vector3 pointToGoTo2;
    public Vector3 pointToGoTo3;
    public Vector3 pointToGoTo4;
    public Vector3 pointToGoToFlee;
    public float Timer;
    public int counter;
    public int MaxRandNum;
    public int NumTimmerWillStopAt;
    public GameObject Player;
    public GameObject Bunny;
    //public GameObject fleeBehavior;
    public float DistanceToStayAway;


    public override Vector3 CalculateForce()
    {
        //pointToGoTo.Set(5, 0, 1);
        //target.Set(5, 1, 0);
        // CheckMouseInput();
        return DetermineDesiredArriveForce();
    }

    private void Update()
    {
        float distance = Vector3.Distance(Bunny.transform.position, Player.transform.position);

        if(distance <= DistanceToStayAway)
        {
            float x;
            float z;
            //fleeBehavior.SetActive(true);
            //this.gameObject.SetActive(false);
            if(Player.transform.position.x > 0)
            {
                x = Bunny.transform.position.x - 3;
            }
            else
            {
                x = Bunny.transform.position.x + 3;
            }

            if (Player.transform.position.z > 0)
            {
                z = Bunny.transform.position.z + 3;
            }
            else
            {
                z = Bunny.transform.position.z - 3;
            }
            pointToGoToFlee.Set(x, 0, z);
            target = pointToGoToFlee;
            Timer = 0;
        }
        else
        {

        }

        Timer += Time.deltaTime;
        if (Timer >= NumTimmerWillStopAt && counter == 1)
        {
            target = pointToGoTo1;
            Timer = 0;
            counter = 2;
        }
        else if (Timer >= NumTimmerWillStopAt && counter == 2)
        {
            target = pointToGoTo2;
            Timer = 0;
            counter = 3;
        }
        else if (Timer >= NumTimmerWillStopAt && counter == 3)
        {
            target = pointToGoTo3;
            Timer = 0;
            counter = 4;
        }
        else if (Timer >= NumTimmerWillStopAt && counter == 4)
        {
            target = pointToGoTo4;
            Timer = 0;
            counter = 1;

            float x;
            float z;
            float d;

            x = Random.Range(1, MaxRandNum);
            z = Random.Range(1, MaxRandNum);

            d = Random.Range(1, 3);

            if (d == 1)
            {

            }
            else
            {
                x = x * -1;
                z = z * -1;
            }

            pointToGoTo1.Set(x, 0, z);

            x = Random.Range(1, MaxRandNum);
            z = Random.Range(1, MaxRandNum);

            d = Random.Range(1, 3);

            if (d == 1)
            {

            }
            else
            {
                x = x * -1;
                z = z * -1;
            }

            pointToGoTo2.Set(x, 0, z);

            x = Random.Range(1, MaxRandNum);
            z = Random.Range(1, MaxRandNum);

            d = Random.Range(1, 3);

            if (d == 1)
            {

            }
            else
            {
                x = x * -1;
                z = z * -1;
            }

            pointToGoTo3.Set(x, 0, z);

            x = Random.Range(1, MaxRandNum);
            z = Random.Range(1, MaxRandNum);

            d = Random.Range(1, 3);

            if (d == 1)
            {

            }
            else
            {
                x = x * -1;
                z = z * -1;
            }

            pointToGoTo4.Set(x, 0, z);
        }
    }

    private void Awake()
    {
        float x;
        float z;
        float d;

        x = Random.Range(1, MaxRandNum);
        z = Random.Range(1, MaxRandNum);

        d = Random.Range(1, 3);

        if(d == 1)
        {

        }
        else
        {
            x = x * -1;
            z = z * -1;
        }

        pointToGoTo1.Set(x, 0, z);

        x = Random.Range(1, MaxRandNum);
        z = Random.Range(1, MaxRandNum);

        d = Random.Range(1, 3);

        if (d == 1)
        {

        }
        else
        {
            x = x * -1;
            z = z * -1;
        }

        pointToGoTo2.Set(x, 0, z);

        x = Random.Range(1, MaxRandNum);
        z = Random.Range(1, MaxRandNum);

        d = Random.Range(1, 3);

        if (d == 1)
        {

        }
        else
        {
            x = x * -1;
            z = z * -1;
        }

        pointToGoTo3.Set(x, 0, z);

        x = Random.Range(1, MaxRandNum);
        z = Random.Range(1, MaxRandNum);

        d = Random.Range(1, 3);

        if (d == 1)
        {

        }
        else
        {
            x = x * -1;
            z = z * -1;
        }

        pointToGoTo4.Set(x, 0, z);

        // this.transform.position.

        //pointToGoTo1.Set(0.688f, 0, 5.971f);
        //pointToGoTo2.Set(-6.883f, 0, -6.2f);
        //pointToGoTo3.Set(6.3f, 0, -4.8f);
        //pointToGoTo4.Set(0.82f, 0, 4.105f);
        Timer = 0;
        counter = 1;
    }

    protected Vector3 DetermineDesiredArriveForce()
    {
        Vector3 toTarget = target - transform.position;
        float distance = toTarget.magnitude;

        steeringAgent.reachedGoal = false;
        if (distance > SlowdownDistance)
        {
            return base.DetermineDesiredSeekForce();
        }
        else if (distance > StoppingDistance && distance <= SlowdownDistance)
        {
            toTarget.Normalize();

            float speed = distance / Deceleration;
            speed = (speed < steeringAgent.maxSpeed ? speed : steeringAgent.maxSpeed);

            speed = speed / distance;
            desiredForce = toTarget * speed;
            return desiredForce - steeringAgent.velocity;
        }

        steeringAgent.reachedGoal = true;
        return Vector3.zero;
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        DebugExtension.DebugCircle(target, Vector3.up, Color.red, SlowdownDistance);
        DebugExtension.DebugCircle(target, Vector3.up, Color.blue, StoppingDistance);
    }

}
