using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BunnyController : MonoBehaviour
{
    //Variable declaration
    private NavMeshAgent agent;
    private Animator animator;
    public Vector3 StartingPoint;
    public Vector3 pointToGoTo1;
    public Vector3 pointToGoTo2;
    public Vector3 pointToGoTo3;
    public Vector3 pointToGoTo4;
    public Vector3 pointToGoToFlee;
    public float Timer;
    public int counter;
    public int MaxRandNum;
    public int MinRandNum;
    public int NumTimmerWillStopAt;
    private GameObject Player;
    private GameObject Bunny;
    public float DistanceToStayAway;


    void Start()
    {
        //Get the starting point to go to, and get the components of the nav mesh and animator
        //Then get 4 random new points to go to. With the min and max set by the user in the 
        //view menu.
        Bunny = this.gameObject;
        Player = GameObject.FindGameObjectWithTag("Player");
        agent = this.GetComponent<NavMeshAgent>();
        animator = this.GetComponent<Animator>();
        agent.SetDestination(StartingPoint);


        float x;
        float z;
        //float d;

        x = Random.Range(MinRandNum, MaxRandNum);
        z = Random.Range(MinRandNum, MaxRandNum);

        //d = Random.Range(1, 3);

        //if(d == 1)
        //{

        //}
        //else
        //{
        //    x = x * -1;
        //    z = z * -1;
        //}

        pointToGoTo1.Set(x, 0, z);

        x = Random.Range(MinRandNum, MaxRandNum);
        z = Random.Range(MinRandNum, MaxRandNum);

        //d = Random.Range(1, 3);

        //if (d == 1)
        //{

        //}
        //else
        //{
        //    x = x * -1;
        //    z = z * -1;
        //}

        pointToGoTo2.Set(x, 0, z);

        x = Random.Range(MinRandNum, MaxRandNum);
        z = Random.Range(MinRandNum, MaxRandNum);

        //d = Random.Range(1, 3);

        //if (d == 1)
        //{

        //}
        //else
        //{
        //    x = x * -1;
        //    z = z * -1;
        //}

        pointToGoTo3.Set(x, 0, z);

        x = Random.Range(MinRandNum, MaxRandNum);
        z = Random.Range(MinRandNum, MaxRandNum);

        //d = Random.Range(1, 3);

        //if (d == 1)
        //{

        //}
        //else
        //{
        //    x = x * -1;
        //    z = z * -1;
        //}

        pointToGoTo4.Set(x, 0, z);

        // this.transform.position.

        //pointToGoTo1.Set(0.688f, 0, 5.971f);
        //pointToGoTo2.Set(-6.883f, 0, -6.2f);
        //pointToGoTo3.Set(6.3f, 0, -4.8f);
        //pointToGoTo4.Set(0.82f, 0, 4.105f);
        Timer = 0;
        counter = 1;
    }

    
    void Update()
    {
        //Checks the distance of the player to the bunny, if they are closer then the set amount, 
        //run away.
        float distance = Vector3.Distance(Bunny.transform.position, Player.transform.position);

        if (distance <= DistanceToStayAway)
        {
            float x;
            float z;
            //fleeBehavior.SetActive(true);
            //this.gameObject.SetActive(false);
            if (Player.transform.position.x > 0)
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
            agent.SetDestination(pointToGoToFlee);
            //target = pointToGoToFlee;
            //agent.SetDestination(pointToGoToFlee);
            Timer = 0;
        }
        else
        {

        }

        //for the amount of time set, move toward one of the points until the timer runs out. 
        //then move to the next point. After the fourth point has been reached, generate
        //new points.
        Timer += Time.deltaTime;
        if (Timer >= NumTimmerWillStopAt && counter == 1)
        {
            //target = pointToGoTo1;
            //agent.SetDestination(target);
            agent.SetDestination(pointToGoTo1);
            Timer = 0;
            counter = 2;
        }
        else if (Timer >= NumTimmerWillStopAt && counter == 2)
        {
            //target = pointToGoTo2;
            //agent.SetDestination(target);
            agent.SetDestination(pointToGoTo2);
            Timer = 0;
            counter = 3;
        }
        else if (Timer >= NumTimmerWillStopAt && counter == 3)
        {
            //target = pointToGoTo3;
            //agent.SetDestination(target);
            agent.SetDestination(pointToGoTo3);
            Timer = 0;
            counter = 4;
        }
        else if (Timer >= NumTimmerWillStopAt && counter == 4)
        {
            //target = pointToGoTo4;
            //agent.SetDestination(target);
            agent.SetDestination(pointToGoTo4);
            Timer = 0;
            counter = 1;

            float x;
            float z;
            //float d;

            x = Random.Range(MinRandNum, MaxRandNum);
            z = Random.Range(MinRandNum, MaxRandNum);

            //d = Random.Range(1, 3);

            //if (d == 1)
            //{

            //}
            //else
            //{
            //    x = x * -1;
            //    z = z * -1;
            //}

            pointToGoTo1.Set(x, 0, z);

            x = Random.Range(MinRandNum, MaxRandNum);
            z = Random.Range(MinRandNum, MaxRandNum);

            //d = Random.Range(1, 3);

            //if (d == 1)
            //{

            //}
            //else
            //{
            //    x = x * -1;
            //    z = z * -1;
            //}

            pointToGoTo2.Set(x, 0, z);

            x = Random.Range(MinRandNum, MaxRandNum);
            z = Random.Range(MinRandNum, MaxRandNum);

            //d = Random.Range(1, 3);

            //if (d == 1)
            //{

            //}
            //else
            //{
            //    x = x * -1;
            //    z = z * -1;
            //}

            pointToGoTo3.Set(x, 0, z);

            x = Random.Range(MinRandNum, MaxRandNum);
            z = Random.Range(MinRandNum, MaxRandNum);

            //d = Random.Range(1, 3);

            //if (d == 1)
            //{

            //}
            //else
            //{
            //    x = x * -1;
            //    z = z * -1;
            //}

            pointToGoTo4.Set(x, 0, z);
        }
    }
}
