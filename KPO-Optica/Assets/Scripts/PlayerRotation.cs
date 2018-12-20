using UnityEngine;
using System.Collections;

public class PlayerRotation : MonoBehaviour {
    public GameObject player;
    private float degreesPerSec = 140f;
    private static bool rotate;
    // Update is called once per frame
    public void Update() {
        if (rotate) {
            float rotAmount = degreesPerSec * Time.deltaTime;
            float curRot = player.transform.localRotation.eulerAngles.z;
            player.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, curRot + rotAmount));
        }
    }
   public void rot() {
        if (rotate) {
            rotate = false;
        } else {
            rotate = true;
        }
        
    }
}
