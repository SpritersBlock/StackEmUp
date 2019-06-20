using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Creature {

    float health;
    float maxHealth;
    int strength;
    int magic;

    public Creature(float maxHealth, int strength, int magic)
    {
        this.maxHealth = maxHealth;
        this.health = maxHealth;
    }

    public void Damage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            health = 0;
            Debug.Log("Dead");
        }
    }
}
