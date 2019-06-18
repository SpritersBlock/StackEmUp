using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Controls : MonoBehaviour {

    public TMP_Text text;

	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Win");
            text.text += "Winner is U ";
        }
	}
}
