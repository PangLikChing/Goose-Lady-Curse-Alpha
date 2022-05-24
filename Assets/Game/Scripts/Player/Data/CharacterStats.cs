using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CharacterStats", menuName = "Character/CharacterStats")]
public class CharacterStats : ScriptableObject
{
    [SerializeField]
    public List<NumericalStat> statsList;
}
