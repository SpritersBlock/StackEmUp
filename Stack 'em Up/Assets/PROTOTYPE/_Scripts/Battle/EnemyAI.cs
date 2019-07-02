using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public List<IMove> EnemyAttacks = new List<IMove>();

    // Update is called once per frame
    public void EnemyMoveChoose() {
        EnemyAttacks.Add(new BasicAttack("Attack1", 21));
        EnemyAttacks.Add(new BasicAttack("Attack2", 15));
        EnemyAttacks.Add(new BasicAttack("Attack3", 10));
    }
}
