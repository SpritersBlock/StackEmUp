using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum phases { P1, P2, P3};

public class BattlePhases : MonoBehaviour {

    public static BattlePhases instance;

    public phases playerTurn;

	// Use this for initialization
	void Start () {
        instance = this;
        playerTurn = phases.P1;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
