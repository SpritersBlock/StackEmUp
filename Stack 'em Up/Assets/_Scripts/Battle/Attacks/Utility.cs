using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : AttackBase {

    public Utility(string name, int power, MoveType moveType) : base(name, power, moveType)
    {
        moveType = MoveType.Utility;
    }
}
