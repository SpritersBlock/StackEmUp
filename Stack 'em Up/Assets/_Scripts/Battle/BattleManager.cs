using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {

    public static BattleManagers instance;

    public List<GameObject> enemyList = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        instance = this;
        enemyList.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
    }

    private void FixedUpdate()
    {
        if (enemyList.Count == 0)
        {
            Invoke("BackToWorld", 2f);
        }
    }

    private void BackToWorld()
    {
        SceneManager.LoadScene(0);
    }
}
