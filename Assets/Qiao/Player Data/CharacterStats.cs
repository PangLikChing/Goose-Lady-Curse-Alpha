using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CharacterStats", menuName = "Character/CharacterStats")]
public class CharacterStats : SerializableScriptableObject
{
    [SerializeField]
    public List<NumericalStat> statsList;
}
