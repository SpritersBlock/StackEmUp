using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Creature {

    private int Level;
    private int ExpRequired;

    public Player(string name, int level, float maxHealth, int strength, int magic, int expRequired, int stackNo) : base(name, maxHealth, strength, magic, stackNo)
    {
        level = Level;
        expRequired = ExpRequired;
    }
}
