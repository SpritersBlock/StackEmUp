using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Creature {

    public Enemy(string name, float maxHealth, int strength, int magic, int stackNo, GameObject fieldEnemy) : base(name, maxHealth, strength, magic, stackNo, fieldEnemy)
    {

    }

}
