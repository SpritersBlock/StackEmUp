using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {

    public static BattleManager instance;

    public GameObject enemy;
    public GameObject enemySpawn;

    public GameObject player;
    public GameObject playerSpawn;

    public List<Enemy> enemyList = new List<Enemy>();
    public List<Player> playerList = new List<Player>();

    // Use this for initialization
    void Start()
    {
        instance = this;
        StartBattle();
    }

    void StartBattle()
    {
        int enemies = 3;
        for (int i = 0; i < enemies; i++)
        {
            var fieldEnemy = Instantiate(enemy, enemySpawn.transform.position + new Vector3(0, i, 0), Quaternion.identity);
            //Add Random thing there
            var managerEnemy = new Enemy("Bob", 5, 3, 6, i, fieldEnemy);
            enemyList.Add(managerEnemy);
            Debug.Log(enemyList[i].stackNumber);

        }
        int players = 3;
        for (int i = 0; i < players; i++)
        {
            var fieldPlayer = Instantiate(player, playerSpawn.transform.position + new Vector3(0, i, 0), Quaternion.identity);
            //Add Player Stats from field
            var managerPlayer = new Player("Player " + (i + 1), 5, 10, 4, 7, 10, i, fieldPlayer);
            playerList.Add(managerPlayer);
            Debug.Log(playerList[i].name);
        }

    }

    private void FixedUpdate()
    {
        if (enemyList.Count == 0)
        {
            //Invoke("BackToWorld", 2f);
        }
    }

    private void BackToWorld()
    {
        SceneManagers.instance.ToOverWorld();
    }
}
