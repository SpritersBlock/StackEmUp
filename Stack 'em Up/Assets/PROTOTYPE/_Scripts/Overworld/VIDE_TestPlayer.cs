using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VIDE_Data;

public class VIDE_TestPlayer : MonoBehaviour {

    public string playerName = "Player Name"; //Will show up as a default name if no other name is given.

    public VIDE_UI_Man dialogueUI;

    //Stored current VA when inside a trigger
    public VIDE_Assign inTrigger;

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<VIDE_Assign>() != null)
            inTrigger = other.GetComponent<VIDE_Assign>();
    }

    void OnTriggerExit()
    {
        inTrigger = null;
    }
	
	// Update is called once per frame
	void Update () {
        //Interact with NPCs when pressing E
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
    }

    void TryInteract()
    {
        /* Prioritize triggers */

        if (inTrigger)
        {
            Interact(inTrigger);
            return;
        }

        /* If we are not in a trigger, try with raycasts */

        //RaycastHit rHit;

        //if (Physics.Raycast(transform.position, transform.forward, out rHit, 2))
        //{
        //    //Lets grab the NPC's VIDE_Assign script, if there's any
        //    VIDE_Assign assigned;
        //    if (rHit.collider.GetComponent<VIDE_Assign>() != null)
        //        assigned = rHit.collider.GetComponent<VIDE_Assign>();
        //    else return;


        //    dialogueUI.Interact(assigned); //Begins interaction
        //}
    }

    void Interact(VIDE_Assign dialogue)
    {
        dialogueUI.Interact(dialogue);
    }
}
