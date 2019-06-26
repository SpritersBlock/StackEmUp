using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleTurns : MonoBehaviour {

    public TMP_Text text;
    public int turnNo;
    bool joust;

    private void Start()
    {
        turnNo = 0;
        joust = false;
    }

    private void FixedUpdate()
    {
        if(joust == false)
        {
            text.gameObject.transform.position = BattleManager.instance.playerFieldList[turnNo].transform.position - new Vector3(-2, 0, 0);
            text.text = turnNo.ToString();
            if (turnNo == 0)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    turnNo++;
                }
            }
            if (turnNo == 1)
            {
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    turnNo++;
                }
            }
            if (turnNo == 2)
            {
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    StartCoroutine("Joust");
                }
            }
        }
    }

    IEnumerator Joust()
    {
        joust = true;
        yield return new WaitForSeconds(2f);
        turnNo = 0;
        joust = false;
    }
}
