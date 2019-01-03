using UnityEngine;
using System.Collections;

public class PrismaDetectLight : MonoBehaviour {
    public GameObject Prisma;
    private LightingCollider2D controlLighting;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Flashlight")) {
            controlLighting = gameObject.GetComponent<LightingCollider2D>();
            controlLighting.enabled = true;
            Prisma.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        Prisma.SetActive(false);
        controlLighting = gameObject.GetComponent<LightingCollider2D>();
        controlLighting.enabled = false;

    }

}