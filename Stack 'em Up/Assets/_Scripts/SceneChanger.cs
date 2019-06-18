using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {
    
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //Loads BattleScene
            SceneManager.LoadScene(1);
        }
	}
}
