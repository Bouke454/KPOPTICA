using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StoryBookSelection : MonoBehaviour {

    public GameStatus status;
    public GameObject PageForward;
    public GameObject CurrentPage;
    public void BookNext() {
        //krijg waarde van de button level0 dus 0
        string GetButtonNumber = EventSystem.current.currentSelectedGameObject.name.Substring(5);
        //vergelijk waarde van volgende button en match dat met het nummer van de gamestatus
        status.GrantLevelAcces(GetButtonNumber);
        if (status.TravelPermission == true) {
            status.TravelPermission = false;
            PageForward.SetActive(true);
            CurrentPage.SetActive(false);
        } else {
            Debug.Log("You have not unlocked this page yet");
        }

    }
}


