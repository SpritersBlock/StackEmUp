using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidInteractionNotification : MonoBehaviour {

    public GameObject canInteractNotif; //This could be a little "!" above the player or something, lets the player know they can initiate dialogue.

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InteractSignalSwitch (bool mode)
    {
        if (canInteractNotif != null)
        {
            canInteractNotif.SetActive(mode);
        } else if (canInteractNotif == null)
        {
            Debug.LogWarning("No InteractionNotification set up! Would be " + mode + ".");
        }
    }
}
