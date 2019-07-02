using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleRunner : MonoBehaviour {

    public static BattleRunner instance = null;

    public GameObject MoveCollector;
    public MoveCollector MoveHolder;
    public GameObject EnemyAI;
    public EnemyAI EnemyMoveHolder;

    public GameObject button;

    public float PlayerHP;
    public float EnemyHP;
    public int PlayerCombinedDmg;
    public int EnemyCombinedDmg;

    public bool CombatOver = false;

	// Use this for initialization
	void Awake () {
		if(instance == null)
        {
            instance = this;
        }
        if(instance != this)
        {
            Destroy(this);
        }
        MoveHolder = MoveCollector.GetComponent<MoveCollector>();
        EnemyMoveHolder = EnemyAI.GetComponent<EnemyAI>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        PlayerHP = BattleStarter.instance.playerStack[0].health;
        EnemyHP = BattleStarter.instance.enemyStack[0].health;

        button.SetActive(true);
        if (MoveCollector.GetComponent<MoveCollector>().AllMovesChosen)
        {
            PlayerCombinedDmg = 0;
            EnemyCombinedDmg = 0;
            button.SetActive(false);
            MoveCollector.GetComponent<MoveCollector>().AllMovesChosen = false;
            EnemyMoveHolder.EnemyMoveChoose();

            foreach (var attack in MoveHolder.PlayerAttacks.Where(a => a is BasicAttack).Select(a => a as BasicAttack).ToArray())
            {
                BattleStarter.instance.enemyStack[0].health -= attack.GetDamage();
                Debug.Log(attack.GetDamage());
                CheckHP();
            }
            foreach (var enemyAttack in EnemyMoveHolder.EnemyAttacks.Where(a => a is BasicAttack).Select(a => a as BasicAttack).ToArray())
            {
                BattleStarter.instance.playerStack[0].health -= enemyAttack.GetDamage();
                Debug.Log(enemyAttack.GetDamage());
                CheckHP();
            }

            var JoustAttack = MoveHolder.PlayerAttacks.Where(a => a is TowerAttack).Select(a => a as TowerAttack).FirstOrDefault();
            JoustAttack.Resolve();

            PlayerCombinedDmg = JoustAttack.GetDamage();

            BattleStarter.instance.enemyStack[0].health -= PlayerCombinedDmg;
            BattleStarter.instance.playerStack[0].health -= EnemyCombinedDmg;

            Debug.Log(PlayerCombinedDmg);
            Debug.Log(EnemyCombinedDmg);

            CheckHP();
           
            MoveHolder.PlayerAttacks.Clear();
            EnemyMoveHolder.EnemyAttacks.Clear();
        }
	}

    public void CheckHP()
    {
        if(CombatOver == false)
        {
            if (BattleStarter.instance.playerStack[0].health <= 0)
            {
                CombatOver = true;
                BattleStarter.instance.playerStack[0].health = 0;
                BattleStarter.instance.enemyStack[0].health = 1;
                Lose();
            }
            if (BattleStarter.instance.enemyStack[0].health <= 0)
            {
                CombatOver = true;
                BattleStarter.instance.enemyStack[0].health = 0;
                Win();
            }
        }
    }

    private void Lose()
    {
        Debug.Log("Lose");
        SceneManagers.instance.ToOverWorld();
    }

    void Win()
    {
        Debug.Log("Win");
        SceneManagers.instance.ToOverWorld();
    }
}
