using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidInteractionNotification : MonoBehaviour {

    public GameObject canInteractNotif; //This could be a little "!" above the player or something, lets the player know they can initiate dialogue.
    [SerializeField]
    private float notifHeight = 1.5f; //How tall above the player the notification is.
    GameObject interactNotifClone;

    // Use this for initialization
    void Start () {
        interactNotifClone = Instantiate(canInteractNotif, transform, false);
        interactNotifClone.transform.position += new Vector3(0, notifHeight, 0);
        InteractSignalSwitch(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InteractSignalSwitch (bool mode)
    {
        if (canInteractNotif != null)
        {
            interactNotifClone.SetActive(mode);
        } else if (canInteractNotif == null)
        {
            Debug.LogWarning("No InteractionNotification set up! Would be " + mode + ".");
        }
    }
}
