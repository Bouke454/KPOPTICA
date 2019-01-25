using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameStatus : MonoBehaviour {

    //eenmalig voor elke deur te openen per level
    public bool AccesLevel;
    //Toestemming om te reizen
    public bool TravelPermission;
    //Vastleggen welke levels behaald zijn (overworld & storybook)
    public int LevelCounter;

    public void GrantLevelAcces(string sceneName) {
        int SceneNumber;
        Int32.TryParse(sceneName, out SceneNumber);
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Intro") {
            TravelPermission = false;
        }
        else if (LevelCounter >= SceneNumber) {
            TravelPermission = true;
        }
    }

    public void GrantLevelCompletion(string sceneName) {
        int SceneNumber;
        Int32.TryParse(sceneName, out SceneNumber);
        if(SceneNumber > LevelCounter) {
            LevelCounter = SceneNumber;
        }
    }
}
