using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyHP : MonoBehaviour {

    public int health;
    public TMP_Text healthText;
   

    public void Damage(int damage)
    {
        health -= damage;
        Debug.Log(health);
        healthText.text = health.ToString();
        BattlePhases.instance.playerTurn++;
        if (BattlePhases.instance.playerTurn == (phases)3)
        {
            StartCoroutine("Joust");
        }
        if (health <= 0)
        {
            GameObject.Find("GameObject").GetComponent<Controls>().WinText();
        }
        Debug.Log(BattlePhases.instance.playerTurn);
    }
}
