using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ComboAttack : IMove{

    public abstract void AddEffect(TowerAttack baseAttack);
}
