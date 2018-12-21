using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class OverworldSelection : MonoBehaviour {

public void LevelSystem() {
        string GetButtonNumber = EventSystem.current.currentSelectedGameObject.name.Substring(6);
        Debug.Log(GetButtonNumber);
        Destroy(GameObject.FindWithTag("Key"));
        SceneManager.LoadScene("Castle"+ GetButtonNumber);
    }
}
