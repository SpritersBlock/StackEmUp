using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VIDE_Data;

public class Movement : MonoBehaviour {

    public float speed;
    public float encounterBuffer = 500f;
    public float bufferCount = 10f;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private int encounterChanceMin = 30;
    private int encounterChanceMax = 50;
    private int encounterCheck;

    public bool canMove = true;
    //private Animator anim;

    private void Start()
    {       
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        if (VD.isActive)
        {
            canMove = false;
        }

        if (canMove)
        {
            Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            moveVelocity = moveInput.normalized * speed;

            if (moveInput.y != 0f || moveInput.x != 0f)
            {
                encounterCheck = Random.Range(1, 3000);
                bufferCount += Time.deltaTime;
            }
        }

        if ((encounterCheck > encounterChanceMin && encounterCheck < encounterChanceMax) && (bufferCount > encounterBuffer))
        {
            bufferCount = 10f;
            Debug.Log("RANDOM ENCOUNTER STARTED");
            SetMoveVelocity(Vector2.zero);
            canMove = false;
            //SceneManagers.instance.ToBattle();
            //SceneManagers.instance.MoveToScene(1); //Generic version of the thing above ^
            StartCoroutine(SceneManagers.instance.SceneTransitionToScene("Battle Scene"));
        }
	}

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    public void SetMoveVelocity(Vector2 newMoveVelocity) //This will be useful for freezing the player, but also moving the player during cutscenes.
    {
        moveVelocity = newMoveVelocity;
    }
}
