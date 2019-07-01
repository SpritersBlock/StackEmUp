using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : IAttack {

    public int damage;
    public IEnumerable<ComboAttack> components;

    public TowerAttack(IEnumerable<ComboAttack> components)
    {
        this.components = components;
    }

    public int GetDamage()
    {
        return damage;
    }

    public string GetName()
    {
        return "Combination";
    }

    public void Resolve()
    {
        foreach(var component in components)
        {
            component.AddEffect(this);
        }
    }
}
