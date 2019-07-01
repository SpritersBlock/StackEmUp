using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VIDE_Data;

[RequireComponent(typeof(ValidInteractionNotification))]
public class VIDE_PlayerDialogueStarter : MonoBehaviour {

    public string playerName = "Player Name"; //Will show up as a default name if no other name is given.

    public bool canInteract; //This will be useful for turning a "CAN INTERACT" notification on/off.

    public VIDE_UI_Manager dialogueUI; //This handles the UI for the dialogue, hopefully obviously enough.

    //Stored current VA when inside a trigger
    public VIDE_Assign inTrigger; //The primary dialogue accessible by the game.
    private VIDE_Assign lastTrigger; //Used as a backup.

    public ValidInteractionNotification validInteractNotif; //The script that activates/disables a "can interact" signal to the player.

    private void Start()
    {
        if (validInteractNotif == null)
        {
            validInteractNotif = GetComponent<ValidInteractionNotification>();
        }
    }

    //This and OnTriggerExit pick up available conversations in the overworld.
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<VIDE_Assign>() != null)
        {
            inTrigger = other.GetComponent<VIDE_Assign>();
            canInteract = true;
            if (other.tag == "TriggerDialogue") // If dialogue is meant to initiate the instant the player walks into a zone.
            {
                TryInteract();
            } else //This is so that the interact signal doesn't show up on automatic dialogue zones.
            {
                validInteractNotif.InteractSignalSwitch(true);
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<VIDE_Assign>() != null) //This is to make sure that the player can't lose their dialogue if an unrelated trigger enters and exits while they're still within an ACTUAL VA
        {
            inTrigger = null;
            canInteract = false;
            validInteractNotif.InteractSignalSwitch(false);
        }
    }

    //2D variant, because I'm still unclear on whether we're going for a 2D scene or 3D scene. Can't hurt to cover our bases.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<VIDE_Assign>() != null)
        {
            inTrigger = collision.GetComponent<VIDE_Assign>();
            canInteract = true;
            if (collision.tag == "TriggerDialogue") // If dialogue is meant to initiate the instant the player walks into a zone.
            {
                TryInteract();
            } else //This is so that the interact signal doesn't show up on automatic dialogue zones.
            {
                validInteractNotif.InteractSignalSwitch(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<VIDE_Assign>() != null)
        {
            inTrigger = null;
            canInteract = false;
            validInteractNotif.InteractSignalSwitch(false);
        }
    }


    void Update () {
        //Interact with NPCs when pressing ActionKey
        if (Input.GetButtonDown("Select"))
        {
            TryInteract(); //NOTE: "Interact" both begins dialogue and advances it.
        }

        if (Input.GetButtonDown("Cancel")) //Skip dialogue...
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
