using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class BattleRunner : MonoBehaviour {

    public static BattleRunner instance = null;

    public GameObject MoveCollector;
    public MoveCollector MoveHolder;
    public GameObject EnemyAI;
    public EnemyAI EnemyMoveHolder;

    public GameObject button;
    public GameObject button2;

    public Animator PlayerStackAnim;
    public Animator EnemyStackAnim;

    public TMP_Text WinLoss;

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
        button.SetActive(true);
        button2.SetActive(true);
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (MoveCollector.GetComponent<MoveCollector>().AllMovesChosen)
        {
            PlayerCombinedDmg = 0;
            EnemyCombinedDmg = 0;
            button.SetActive(false);
            button2.SetActive(false);
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

            DoJoust();

            BattleStarter.instance.enemyStack[0].health -= PlayerCombinedDmg;
            BattleStarter.instance.playerStack[0].health -= EnemyCombinedDmg;

            Debug.Log(PlayerCombinedDmg);
            Debug.Log(EnemyCombinedDmg);

            CheckHP();
           
            MoveHolder.PlayerAttacks.Clear();
            EnemyMoveHolder.EnemyAttacks.Clear();
        }
	}

    private void DoJoust()
    {
        PlayerStackAnim.SetTrigger("Joust");
        EnemyStackAnim.SetTrigger("Joust");

        var JoustAttack = MoveHolder.PlayerAttacks.Where(a => a is TowerAttack).Select(a => a as TowerAttack).FirstOrDefault();
        JoustAttack.Resolve();

        PlayerCombinedDmg = JoustAttack.GetDamage();
        Invoke("ButtonsOn", 2f);
    }

    private void ButtonsOn()
    {
        button.SetActive(true);
        button2.SetActive(true);
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
                WinLoss.text = "You Lose";
                button.SetActive(false);
                button2.SetActive(false);
                Invoke("Lose", 2f);
            }
            if (BattleStarter.instance.enemyStack[0].health <= 0)
            {
                CombatOver = true;
                BattleStarter.instance.enemyStack[0].health = 0;
                WinLoss.text = "You Win";
                button.SetActive(false);
                button2.SetActive(false);
                Invoke("Win", 2f);
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
