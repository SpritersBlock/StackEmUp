using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyList : MonoBehaviour {

    public static EnemyList instance;

    public List<GameObject> enemyList = new List<GameObject>();

	// Use this for initialization
	void Start () {
        instance = this;
        enemyList.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
	}

    private void FixedUpdate()
    {
        if(enemyList.Count == 0)
        {
            Invoke("BackToWorld", 2f);
        }
    }

    private void BackToWorld()
    {
        SceneManager.LoadScene(0);
    }
}
