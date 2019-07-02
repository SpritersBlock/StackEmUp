using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackHP {

    public float maxHP;
    public float health;

    public StackHP(float health, float maxHP)
    {
        this.maxHP = maxHP;
        this.health = health;
    }
}
