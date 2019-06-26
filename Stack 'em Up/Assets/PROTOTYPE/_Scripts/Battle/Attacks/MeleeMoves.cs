using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeMoves : MonoBehaviour {

    public string Name;
    public int Power;
    public AttackBase.MoveType MoveType;
    private Melee self;

    private void Start()
    {
        self = new Melee(Name, Power, MoveType);
    }
}
