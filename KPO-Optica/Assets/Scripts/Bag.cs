using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour {

    //If not activated the player will need to press twice to open the bag
    private bool isClosed = true;
    private bool OptionActive;
    public GameObject bag;

    //Method will only be called after interaction with the player mouse click
    public void OpenCloseBag() {
        //Check if an option is already active or not
        GameObject[] objs = GameObject.FindGameObjectsWithTag("UIOption");
        if (objs.Length == 0) {
            // No active items
            OptionActive = false;
        } else {
            OptionActive = true;
        }
        if (isClosed == true && OptionActive == false)
        {
            //Pause
            Time.timeScale = 0.0f;
            bag.SetActive(true);
            isClosed = false;
            
        }
        else {
            //Start game
            Time.timeScale = 1;
            bag.SetActive(false);
            isClosed = true;
        }
    }
}
