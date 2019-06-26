using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : AttackBase {

    public Melee(string name, int power, MoveType moveType) : base(name, power, moveType)
    {
        moveType = MoveType.Melee;
    }
}
