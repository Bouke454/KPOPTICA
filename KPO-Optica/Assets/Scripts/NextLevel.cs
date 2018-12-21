using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {
    public GameStatus status;
    public WeaponItem item;


    // Use this for initialization
    void Start() {
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene name is: " + scene.name + "\nActive Scene index: " + scene.buildIndex);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Key")) {
            status.AccesLevel = true;
            Scene scene = SceneManager.GetActiveScene();
            if (status.AccesLevel == true) {
                Debug.Log("You may enter");
                Destroy(GameObject.FindWithTag("Key"));
                status.AccesLevel = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        } else {
            Debug.Log("You are not authorized");
        }
    }
}
