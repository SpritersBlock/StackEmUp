using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : AttackBase {

    public Magic(string name, int power, MoveType moveType) : base(name, power, moveType)
    {
        moveType = MoveType.Magic;
    }
}
