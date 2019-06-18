using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Controls : MonoBehaviour {

    public TMP_Text text;

	// Update is called once per frame
	public void WinText() {
            Debug.Log("Win");
            text.text += "Winner is U ";
            Invoke("BackToWorld", 2);
	}

     void BackToWorld()
    {
        SceneManager.LoadScene(0);
    }
}
