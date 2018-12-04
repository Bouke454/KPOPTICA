using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour {

    //If not activated the player will need to press twice to open the bag
    bool isClosed = true;
    public GameObject bag;


    //Method will only be called after interaction with the player mouse click
    public void OpenCloseBag() {
        if (isClosed == true)
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
