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

    public int PlayerCombinedDmg;
    public int PlayerHP;
    public int EnemyCombinedDmg;
    public int EnemyHP;

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
                EnemyHP -= attack.GetDamage();
                Debug.Log(attack.GetDamage());
                CheckHP();
            }
            foreach (var enemyAttack in EnemyMoveHolder.EnemyAttacks.Where(b => b is BasicAttack).Select(b => b as BasicAttack).ToArray())
            {
                PlayerHP -= enemyAttack.GetDamage();
                Debug.Log(enemyAttack.GetDamage());
                CheckHP();
            }

            EnemyHP -= PlayerCombinedDmg;
            PlayerHP -= EnemyCombinedDmg;

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
            if (PlayerHP <= 0)
            {
                CombatOver = true;
                PlayerHP = 0;
                EnemyHP = 1;
                Lose();
            }
            if (EnemyHP <= 0)
            {
                CombatOver = true;
                EnemyHP = 0;
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
