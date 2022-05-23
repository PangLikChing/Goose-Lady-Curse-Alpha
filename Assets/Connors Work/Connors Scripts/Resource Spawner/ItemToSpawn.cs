using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnableItem", menuName = "Game Data/CreateListOfSpawnableItems")]
public class ItemToSpawn : ScriptableObject
{
    public List<GameObject> SpawnableItems;

}
