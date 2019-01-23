using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StoryBookSelectionReturn : MonoBehaviour {

    public GameStatus status;
    public GameObject PageBackward;
    public GameObject CurrentPage;
   
    public void BookReturn() {
        PageBackward.SetActive(true);
        CurrentPage.SetActive(false);

    }
}


