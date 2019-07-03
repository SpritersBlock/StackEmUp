using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public List<IMove> EnemyAttacks = new List<IMove>();

    // Update is called once per frame
    public void EnemyMoveChoose() {
        EnemyAttacks.Add(new BasicAttack("Attack1", Random.Range(1,8)));
        EnemyAttacks.Add(new BasicAttack("Attack2", Random.Range(2, 6)));
        EnemyAttacks.Add(new BasicAttack("Attack3", Random.Range(1, 5)));
    }
}
