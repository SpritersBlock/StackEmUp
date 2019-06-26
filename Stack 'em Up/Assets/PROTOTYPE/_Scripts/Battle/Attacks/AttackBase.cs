using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackBase {

    string name;
    int power;
    MoveType moveType;

    public enum MoveType
    {
        Melee,
        Magic,
        Utility
    }

    public AttackBase(string name, int power, MoveType movetype)
    {

    }
}
