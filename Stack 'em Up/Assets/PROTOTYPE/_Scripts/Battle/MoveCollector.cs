using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TurnOrder { P1Turn, P2Turn, P3Turn};

public class MoveCollector : MonoBehaviour {

    public TurnOrder CurrentTurnOrder;

    public IAttack[] PlayerAttacks;

    public bool AllMovesChosen = false;

    private void Start()
    {

    }

    private void FixedUpdate()
    {

    }

    public void ChooseMove()
    {
        PlayerAttacks = new IAttack[] { new BasicAttack("Attack1", 20, true), new BasicAttack("Attack2", 10, true), new BasicAttack("Attack 3", 15, true) };
        AllMovesChosen = true;
    }
}
