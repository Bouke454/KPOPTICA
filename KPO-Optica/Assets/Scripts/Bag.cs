using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour {

    bool isClosed;
    public GameObject bag;

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
