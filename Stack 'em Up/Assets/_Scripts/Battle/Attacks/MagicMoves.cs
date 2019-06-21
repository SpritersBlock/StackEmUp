using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMoves : MonoBehaviour {

    public string Name;
    public int Power;
    public AttackBase.MoveType MoveType;
    private Magic self;

    private void Start()
    {
        self = new Magic(Name, Power, MoveType);
    }
}
