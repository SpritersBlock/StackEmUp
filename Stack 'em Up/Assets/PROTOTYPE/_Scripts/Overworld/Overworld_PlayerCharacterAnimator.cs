using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overworld_PlayerCharacterAnimator : MonoBehaviour {

    //public Vector2 movementDirection;
    //public float movementSpeed;

    //public float MOVEMENT_BASE_SPEED = 1;

    //private void Awake()
    //{

    //}

    //private void Update()
    //{
    //    ProcessInputs();
    //}

    //void ProcessInputs()
    //{
    //    movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    //    movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0f, 1f);
    //    movementDirection.Normalize();
    //}

    public Movement playerMovementScript;

    private Animator anim;

    private bool playerMoving;
    private Vector2 lastMove;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMoving = false;

        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            if (!playerMoving)
            {
                playerMoving = true;
            }
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }

        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            if (!playerMoving)
            {
                playerMoving = true;
            }
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }
}
