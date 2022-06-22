using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PredatorBaseState
{
    //Bllueprint for other states


    //void Start
    public abstract void EnterState(Predator predator);
    //void Update
    public abstract void UpdateState(Predator predator);
    //void FixedUpdate
    public abstract void FixedUpdateState(Predator predator);
}
