using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : IAttack {

    public TowerAttack(IEnumerable<ComboAttack> components)
    {

    }

    public int GetDamage()
    {
        return 1;
    }

    public string GetName()
    {
        return "Combination";
    }
}
