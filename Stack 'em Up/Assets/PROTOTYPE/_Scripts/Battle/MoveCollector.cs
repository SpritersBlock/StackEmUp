using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MoveCollector : MonoBehaviour {


    public List<IMove> PlayerAttacks = new List<IMove>();

    public bool AllMovesChosen = false;

    private void Start()
    {

    }

    private void FixedUpdate()
    {

    }

    public void AddBasicAttack()
    {
        PlayerAttacks.Add(new BasicAttack("Attack1", 20));
        Debug.Log("Basic Added");
        CheckTurnOver();
    }

    public void AddComboAttack()
    {
        PlayerAttacks.Add(new AddDamage());
        Debug.Log("Combo Added");
        CheckTurnOver();
    }

    public void CheckTurnOver()
    {
        if(PlayerAttacks.Count >= 3)
        {
            AllMovesChosen = true;
            var Tower = new TowerAttack(PlayerAttacks.Where(a => a is ComboAttack).Select(a => a as ComboAttack).ToArray());
            Debug.Log(Tower);
            PlayerAttacks.Add(Tower);
            Debug.Log(PlayerAttacks.Count);
        }
    }
}
