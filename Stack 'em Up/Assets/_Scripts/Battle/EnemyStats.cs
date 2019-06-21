using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {

    public string Name;
    public float Health;
    public int Strength;
    public int Magic;
    public int StackNo;
    private Enemy self;

	// Use this for initialization
	void Start () {
        self = new Enemy(Name, Health, Strength, Magic, StackNo);
	}
}
