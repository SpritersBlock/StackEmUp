using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public string Name;
    public int Level;
    public float Health;
    public int Strength;
    public int Magic;
    public int ExpRequired;
    public int StackNo;
    private Player self;

	// Use this for initialization
	void Start () {
        self = new Player(Name, Level, Health, Strength, Magic, ExpRequired, StackNo);
	}
}
