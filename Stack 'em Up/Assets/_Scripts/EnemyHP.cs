using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyHP : MonoBehaviour {

    public int health;
    public TMP_Text healthText;
    
    // Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKeyDown(KeyCode.Z) && health > 0 && BattlePhases.instance.playerTurn == phases.P1)
        {
            Damage();
            BattlePhases.instance.playerTurn = phases.P2;
        }
        if (Input.GetKeyDown(KeyCode.X) && health > 0 && BattlePhases.instance.playerTurn == phases.P2)
        {
            Damage();
            BattlePhases.instance.playerTurn = phases.P3;
        }
        if (Input.GetKeyDown(KeyCode.L) && health > 0 && BattlePhases.instance.playerTurn == phases.P3)
        {
            Damage();
            BattlePhases.instance.playerTurn = phases.P1;
        }
    }

    void Damage()
    {
        health--;
        Debug.Log(health);
        healthText.text = health.ToString();
        if (health <= 0)
        {
            GameObject.Find("GameObject").GetComponent<Controls>().WinText();
        }
        Debug.Log(BattlePhases.instance.playerTurn);
    }
}
