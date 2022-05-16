using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //Variable declaration
    //public GameObject objPrefab;
    private GameObject spawnableObject;
    private float timer;
    public ItemToSpawn itemScirtableObject;
    //private string prefabName;
    public float timeToWait;
    private GameObject ObjectToSpawn;
    private int randomNum;
    //public int numOfItems;
    //public string scriptableObjectName;

    // Start is called before the first frame update
    void Start()
    {
        // itemScirtableObject = (ItemToSpawn)Resources.Load("Scriptable Objects/" + scriptableObjectName, typeof(ItemToSpawn));
    }

    //spawn the object 
    public void SpawnObject()
    {
        //GameObject ObjectToSpawn = (GameObject)Resources.Load("Prefabs/" + prefabName, typeof(GameObject));
        if(itemScirtableObject.SpawnableItems.Count == -1)
        {
            Debug.Log("No Items are in the spawn list, please add at least one item in the scriptable object.");
        }
        else
        {
            randomNum = Random.Range(0, itemScirtableObject.SpawnableItems.Count);
            ObjectToSpawn = itemScirtableObject.SpawnableItems[randomNum];
            spawnableObject = (GameObject)Instantiate(ObjectToSpawn, this.transform.position, this.transform.rotation);
        }
    }

    //If the object has not already been spawned, spawn it after a set amount of time has been reached
    public void SpawnerLogicUpdate()
    {
        if (spawnableObject == null)
        {
            timer = timer + Time.deltaTime;
            if (timer >= timeToWait)
            {
                SpawnObject();
                timer = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        SpawnerLogicUpdate();
    }
}
