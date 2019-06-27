using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : IAttack {

    string name;
    int damage;
    bool combo;

    public BasicAttack(string name, int damage, bool combo)
    {
        this.name = name;
        this.damage = damage;
    }

    public int GetDamage()
    {
        return damage;
    }

    public string GetName()
    {
        return name;
    }

    public bool IsCombo()
    {
        return combo;
    }
}
