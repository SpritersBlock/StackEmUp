using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {

    public float speed;
    public float encounterBuffer = 500f;
    public float bufferCount = 10f;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private int encounterChanceMin = 30;
    private int encounterChanceMax = 50;
    private int encounterCheck;

    private void Start()
    {       
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {

        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;

        if(moveInput.y != 0f || moveInput.x != 0f)
        {
            encounterCheck = Random.Range(1, 3000);
            bufferCount += Time.deltaTime;
        }

        if((encounterCheck > encounterChanceMin && encounterCheck < encounterChanceMax) && (bufferCount > encounterBuffer))
        {
            bufferCount = 10f;
            Debug.Log("RANDOM ENCOUNTER STARTED");
            SceneManager.LoadScene(1);
        }
	}

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);

    }
}
