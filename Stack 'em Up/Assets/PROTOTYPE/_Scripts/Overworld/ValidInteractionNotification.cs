using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidInteractionNotification : MonoBehaviour {

    //I've set up a prefab called "CanInteractSignal" for the sake of the prototype. Drag it into "canInteractSignal" until we find something better.

    public GameObject canInteractSignal; //This could be a little "!" above the player or something, lets the player know they can initiate dialogue.
    [SerializeField]
    private float notifHeight = 1.5f; //How tall above the player the notification is.
    GameObject interactSignalClone;

    // Use this for initialization
    void Start () {
        interactSignalClone = Instantiate(canInteractSignal, transform, false);
        interactSignalClone.transform.position += new Vector3(0, notifHeight, 0);
        InteractSignalSwitch(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InteractSignalSwitch (bool mode)
    {
        if (canInteractSignal != null)
        {
            interactSignalClone.SetActive(mode);
        } else if (canInteractSignal == null)
        {
            Debug.LogWarning("No InteractionNotification set up! Would be " + mode + ".");
        }
    }
}
