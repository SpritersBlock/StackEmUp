using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creature {

    public string name;
    public float health;
    public float maxHealth;
    public int strength;
    public int magic;
    public int stackNumber;
    public GameObject fieldEnemy;

    public Creature(string name, float maxHealth, int strength, int magic, int stackNumber, GameObject fieldEnemy)
    {
        this.maxHealth = maxHealth;
        this.health = maxHealth;
        this.name = name;
        this.strength = strength;
        this.magic = magic;
        this.stackNumber = stackNumber;
        this.fieldEnemy = fieldEnemy;
    }
}
