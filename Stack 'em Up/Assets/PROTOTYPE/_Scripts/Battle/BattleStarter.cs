using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleStarter : MonoBehaviour {

    public static BattleStarter instance;

    public TMP_Text PlayerHPText;
    public TMP_Text EnemyHPText;

    public GameObject enemy;
    public GameObject enemySpawn;
    public GameObject player;
    public GameObject playerSpawn;

    float EnemyStackHP;
    float EnemyStackMaxHP;
    float PlayerStackHP;
    float PlayerStackMaxHP;

    public GameObject playerHPBar;
    public Image playerHPFillAmount;
    public GameObject enemyHPBar;
    public Image enemyHPFillAmount;

    public GameObject playerHPSpawn;
    public GameObject enemyHPSpawn;

    public List<GameObject> enemyFieldList = new List<GameObject>();
    public List<Enemy> enemyList = new List<Enemy>();
    public List<StackHP> enemyStack = new List<StackHP>();
    public List<GameObject> playerFieldList = new List<GameObject>();
    public List<Player> playerList = new List<Player>();
    public List<StackHP> playerStack = new List<StackHP>();

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
            var fieldEnemy = Instantiate(enemy, enemySpawn.transform.position + new Vector3(0, (i + 1), 0), Quaternion.identity);
            fieldEnemy.name = "Enemy " + (i + 1);
            fieldEnemy.transform.parent = GameObject.Find("EnemyStackHolder").transform;
            enemyFieldList.Add(fieldEnemy);
            //Add Random thing there
            var managerEnemy = new Enemy("Enemy " + (i + 1), 15, 3, 6, i, fieldEnemy);
            enemyList.Add(managerEnemy);
            Debug.Log(enemyList[i].name);
        }
        int players = 3;
        for (int i = 0; i < players; i++)
        {
            var fieldPlayer = Instantiate(player, playerSpawn.transform.position + new Vector3(0, (i + 1), 0), Quaternion.identity);
            fieldPlayer.name = "Player " + (i + 1);
            fieldPlayer.transform.parent = GameObject.Find("PlayerStackHolder").transform;
            playerFieldList.Add(fieldPlayer);
            //Add Player Stats from field
            var managerPlayer = new Player("Player " + (i + 1), 5, 25, 4, 7, 10, i, fieldPlayer);
            playerList.Add(managerPlayer);
            Debug.Log(playerList[i].name);
        }
        foreach (var enemy in enemyList)
        {
            EnemyStackHP += enemy.health;
            EnemyStackMaxHP += enemy.maxHealth;
        }
        var EnemyStack = new StackHP(EnemyStackHP, EnemyStackMaxHP);
        enemyStack.Add(EnemyStack);
        foreach (var player in playerList)
        {
            PlayerStackHP += player.health;
            PlayerStackMaxHP += player.maxHealth;
        }
        var PlayerStack = new StackHP(PlayerStackHP, PlayerStackMaxHP);
        playerStack.Add(PlayerStack);
        Debug.Log(playerStack[0].health);
        Debug.Log(enemyStack[0].health);

        playerHPFillAmount = GameObject.Find("PlayerHPBar").GetComponent<Image>();
        enemyHPFillAmount = GameObject.Find("EnemyHPBar").GetComponent<Image>();
    }

    private void FixedUpdate()
    {
        playerHPFillAmount.fillAmount = (1 / PlayerStackMaxHP) * playerStack[0].health;
        enemyHPFillAmount.fillAmount = (1 / EnemyStackMaxHP) * enemyStack[0].health;
        PlayerHPText.text = playerStack[0].health.ToString();
        EnemyHPText.text = enemyStack[0].health.ToString();
    }

    public void CheckHP()
    {
        for (int i = 0; i < enemyStack.Count; i++)
        {
            if(enemyStack[i].health <= 0)
            {
                enemyStack.Remove(enemyStack[i]);
            }
        }
        for (int i = 0; i < playerStack.Count; i++)
        {
            if (playerStack[i].health <= 0)
            {
                playerStack.Remove(playerStack[i]);
            }
        }
    }

    private void BackToWorld()
    {
        SceneManagers.instance.ToOverWorld();
    }
}
