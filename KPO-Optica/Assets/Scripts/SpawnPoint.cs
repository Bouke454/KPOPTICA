using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {
    private GameObject player;
    private Vector3 target;

    // Use this for initialization
    void Start() {
        player = GameObject.Find("Player");
        target = transform.position;
        player.transform.position = target;
    }

}
