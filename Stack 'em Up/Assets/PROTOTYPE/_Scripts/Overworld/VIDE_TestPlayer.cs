using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VIDE_Data;

public class VIDE_TestPlayer : MonoBehaviour {

    public string playerName = "Player Name"; //Will show up as a default name if no other name is given.

    public VIDE_UI_Man dialogueUI;

    //Stored current VA when inside a trigger
    public VIDE_Assign inTrigger; //The primary dialogue accessible by the game.
    public VIDE_Assign lastTrigger; //Used as a backup.

    public KeyCode actionKey;
    public KeyCode skipKey;

    private void Start()
    {
        //Check if Action/Skip Keys are assigned. If not, make 'em the Jaesda-picked defaults.
        if (actionKey == KeyCode.None)
        {
            Debug.LogWarning("No Action Key Assigned. Action Key is now E.");
            actionKey = KeyCode.E;
        }
        if (skipKey == KeyCode.None)
        {
            Debug.LogWarning("No Skip Key Assigned. Skip Key is now Q.");
            skipKey = KeyCode.Q;
        }
    }

    //This and OnTriggerExit pick up available conversations in the overworld.
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<VIDE_Assign>() != null)
        {
            inTrigger = other.GetComponent<VIDE_Assign>();
            if (other.tag == "TriggerDialogue")
            {
                TryInteract();
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<VIDE_Assign>() != null)
        {
            inTrigger = null;
        }
    }

    //2D variant, because I'm still unclear on whether we're going for a 2D scene or 3D scene. Can't hurt to cover our bases.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<VIDE_Assign>() != null)
        {
            inTrigger = collision.GetComponent<VIDE_Assign>();
            if (collision.tag == "TriggerDialogue")
            {
                TryInteract();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<VIDE_Assign>() != null)
        {
            inTrigger = null;
        }
    }


    void Update () {
        //Interact with NPCs when pressing ActionKey
        if (Input.GetKeyDown(actionKey))
        {
            TryInteract(); //NOTE: "Interact" both begins dialogue and advances it.
        }

        if (Input.GetKeyDown(skipKey)) //Skip dialogue...
        {
            if (VD.isActive && VD.assigned.interactionCount > 0) //...but only if the player's talked to this person already.
            {
                dialogueUI.CutTextAnim();
                dialogueUI.EndDialogue(VD.nodeData);
            }
        }
    }

    void TryInteract() //See if the player is able to interact.
    {
        if (inTrigger && !VD.isActive)
        {
            Interact(inTrigger);
            return;
        }
        else if (VD.isActive)
        //This makes sure that the player can advance dialogue if they leave the range of conversation for whatever reason.
        //This is only if dialogue is currently active.
        {
            Interact(lastTrigger); //lastTrigger is set down below in Interact();
        }

    }

    //THIS IS HOW WE ACTIVATE DIALOGUE, WOOO
    public void Interact(VIDE_Assign dialogue)
    {
        dialogueUI.Interact(dialogue);
        lastTrigger = dialogue; //This creates a back-up that we can use to advance dialogue up above.

        //NOTE: "Interact" both begins dialogue and advances it.
        //We'll have to be careful about making sure dialogue isn't activated when we run this, unless we want the player to automatically advance.
    }
}
