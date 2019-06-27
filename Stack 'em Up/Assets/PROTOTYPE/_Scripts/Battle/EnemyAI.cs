using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public IAttack[] EnemyAttacks;

    // Update is called once per frame
    void FixedUpdate () {
        EnemyAttacks = new IAttack[] { new BasicAttack("Attack1", 21, true), new BasicAttack("Attack2", 15, true), new BasicAttack("Attack 3", 18, true) };
    }
}
