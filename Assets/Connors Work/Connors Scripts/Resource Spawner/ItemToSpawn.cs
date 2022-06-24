using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//creates the menu item to create a scriptabel object
//that holds the list of items the spawner can spawn
[CreateAssetMenu(fileName = "SpawnableItem", menuName = "Game Data/CreateListOfSpawnableItems")]
public class ItemToSpawn : ScriptableObject
{
    public List<GameObject> SpawnableItems;

}
