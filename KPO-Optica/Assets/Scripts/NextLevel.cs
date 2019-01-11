using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {
    public GameStatus status;
    private Inventory inv;

    // Use this for initialization
    void Start() {
        inv = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene name is: " + scene.name + "\nActive Scene index: " + scene.buildIndex);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        Scene scene = SceneManager.GetActiveScene();
        if (other.CompareTag("Key")) {
            status.AccesLevel = true;
            if (status.AccesLevel == true) {

                Debug.Log("You may enter");
                Destroy(GameObject.FindWithTag("Key"));
                //Remove the key from the canvas
                foreach (GameObject slot in inv.slots) {
                    var children2 = slot.GetComponentsInChildren<Transform>();
                    foreach (var child in children2) {
                        if (child.name == "KeyButton(Clone)") {
                            Destroy(child.gameObject);
                        }
                    }
                }
                if(scene.name != "Intro") {
                    string GetButtonNumber = scene.name.Substring(6);
                    status.GrantLevelCompletion(GetButtonNumber);
                    status.AccesLevel = false;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                } else {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
        } else {
            Debug.Log("You are not authorized");
            
        }
    }
}
