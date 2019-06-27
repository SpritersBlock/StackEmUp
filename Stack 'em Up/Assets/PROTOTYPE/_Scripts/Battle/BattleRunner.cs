using System;
using System.Collections;
using System.Collections.Generic;
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

            for (int i = 0; i < MoveHolder.PlayerAttacks.Length; i++)
            {
                PlayerCombinedDmg += MoveHolder.PlayerAttacks[i].GetDamage();
            }
            for (int i = 0; i < EnemyMoveHolder.EnemyAttacks.Length; i++)
            {
                EnemyCombinedDmg += EnemyMoveHolder.EnemyAttacks[i].GetDamage();
            }

            EnemyHP -= PlayerCombinedDmg;
            PlayerHP -= EnemyCombinedDmg;
            if(PlayerHP <= 0)
            {
                PlayerHP = 0;
                EnemyHP = 1;
                Lose();
            }
            if (EnemyHP <= 0)
            {
                EnemyHP = 0;
                Win();
            }
            MoveCollector.GetComponent<MoveCollector>().AllMovesChosen = false;
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
