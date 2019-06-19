using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum phases { P1 = 0, P2 = 1, P3 = 2};

public class BattlePhases : MonoBehaviour {

    public static BattlePhases instance;

    public phases playerTurn;

	// Use this for initialization
	void Start () {
        instance = this;
        playerTurn = phases.P1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Z) && playerTurn == phases.P1)
        {
            GameObject.Find("GameObject").GetComponent<EnemyHP>().Damage(GameObject.Find("P1").GetComponent<PlayerStats>().attack);
            //BattlePhases.instance.playerTurn = phases.P2;
        }
        if (Input.GetKeyDown(KeyCode.X) && playerTurn == phases.P2)
        {
            GameObject.Find("GameObject").GetComponent<EnemyHP>().Damage(GameObject.Find("P2").GetComponent<PlayerStats>().attack);
            //BattlePhases.instance.playerTurn = phases.P3;
        }
        if (Input.GetKeyDown(KeyCode.L) && playerTurn == phases.P3)
        {
            GameObject.Find("GameObject").GetComponent<EnemyHP>().Damage(GameObject.Find("P3").GetComponent<PlayerStats>().attack);
            //BattlePhases.instance.playerTurn = phases.P1;
        }
    }

    IEnumerator Joust()
    {
        Debug.Log("Joust");
        healthText.text = "Joust";
        yield return new WaitForSeconds(2f);
        healthText.text = health.ToString();
        BattlePhases.instance.playerTurn = 0;
    }
}
