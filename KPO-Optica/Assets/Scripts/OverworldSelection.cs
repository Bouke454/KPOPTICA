using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class OverworldSelection : MonoBehaviour {

    public GameStatus status;
    private Inventory inv;
    bool levelCheck;
    private void Start() {
        inv = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    public void LevelSystem() {
        string GetButtonNumber = EventSystem.current.currentSelectedGameObject.name.Substring(6);
        status.GrantLevelAcces(GetButtonNumber);
        if(status.TravelPermission == true) {
            //Remove the key from the canvas
            foreach (GameObject slot in inv.slots) {
                var children2 = slot.GetComponentsInChildren<Transform>();
                foreach (var child in children2) {
                    if (child.name == "KeyButton(Clone)") {
                        Destroy(child.gameObject);
                    }
                }
            }
            status.TravelPermission = false;
            SceneManager.LoadScene("Castle" + GetButtonNumber);
        } else {
            Debug.Log("You have not unlocked this level yet");
        }
        
    }
}


