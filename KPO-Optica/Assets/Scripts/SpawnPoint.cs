using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {
    private GameObject player;
    private GameObject TouchPad;
    private Vector3 target;

    // Use this for initialization
    void Start() {
        Destroy(GameObject.FindWithTag("Key"));
        DestroyAll("Flashlight");
        DestroyAll("Torch");
        DestroyAll("uvFlashlight");
        player = GameObject.Find("Player");
        TouchPad = GameObject.Find("TouchPad_Rotator");
        target = transform.position;
        player.transform.position = target;
        player.GetComponent<PlayerController>().enabled = false;
        TouchPad.GetComponent<PlayerRotation>().rotate = false;
        StartCoroutine(UnfreezeControls());

    }
    IEnumerator UnfreezeControls() {
        yield return new WaitForSeconds(1.5f);
        player.GetComponent<PlayerController>().enabled = true;
    }
    void DestroyAll(string tag) {
        GameObject[] item = GameObject.FindGameObjectsWithTag(tag);
        for (int i = 0; i < item.Length; i++) {
            Destroy(item[i]);
        }
    }

}
