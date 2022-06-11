using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Condition", menuName = "Character/Condition")]
public class Condition : ScriptableObject
{
    public SurvivalStat stat;
    public float threshold;
    public enum Operator
    {
        Greater,
        Less,
        Equal,
        GreaterEqual,
        LessEqual
    }
    public Operator @operator;
    public virtual bool Evaluate()
    {
        switch (@operator)
        {
            case Operator.Equal:
                if (stat.currentValue == threshold)
                {
                    return true;
                }
                break;
            case Operator.Greater:
                if (stat.currentValue > threshold)
                {
                    return true;
                }
                break;
            case Operator.Less:
                if (stat.currentValue < threshold)
                {
                    return true;
                }
                break;
            case Operator.GreaterEqual:
                if (stat.currentValue >= threshold)
                {
                    return true;
                }
                break;
            case Operator.LessEqual:
                if (stat.currentValue <= threshold)
                {
                    return true;
                }
                break;
        }
        return false;
    }
}
