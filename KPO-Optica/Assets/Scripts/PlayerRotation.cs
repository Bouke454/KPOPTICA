using UnityEngine;
using System.Collections;

public class PlayerRotation : MonoBehaviour {
    private GameObject player;
    private float degreesPerSec = 120f;
    public bool rotate = false;

    // Update is called once per frame
    public void Update() {
        if (rotate == true) {
            player = GameObject.Find("Player");
            float rotAmount = degreesPerSec * Time.deltaTime;
            float curRot = player.transform.localRotation.eulerAngles.z;
            player.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, curRot + rotAmount));
        }
    }
   public void RotatePlayer() {
        if (rotate == false) {
            rotate = true;
        } else if(rotate == true) {
            rotate = false;
        }
        
    }
}
