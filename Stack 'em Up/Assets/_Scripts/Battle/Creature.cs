using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Creature {

    string name;
    float health;
    float maxHealth;
    int strength;
    int magic;
    int stackNumber;

    public Creature(string name, float maxHealth, int strength, int magic, int stackNumber)
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
