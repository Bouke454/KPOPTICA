using UnityEngine;
using System.Collections;

public class DetectLight : MonoBehaviour {
    public float LightHitTime = 5f;
    private bool LightCollide;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Solid") && !LightCollide) {
            Debug.Log("Light reached object");
            LightCollide = true;
            Invoke("ReloadDialogue", LightHitTime);
        }

    }
    public void ReloadDialogue() {
        LightCollide = false;
    }

}