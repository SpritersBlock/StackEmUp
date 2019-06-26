using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityMoves : MonoBehaviour {

    public string Name;
    public int Power;
    public AttackBase.MoveType MoveType;
    private Utility self;

    private void Start()
    {
        self = new Utility(Name, Power, MoveType);
    }
}
