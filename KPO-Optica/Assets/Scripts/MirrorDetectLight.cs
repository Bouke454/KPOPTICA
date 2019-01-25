using UnityEngine;
using System.Collections;

public class MirrorDetectLight : MonoBehaviour
{
    private GameObject player;
    private GameObject TouchPad;
    public GameObject HiddenMirror;
    public Event QuizCheck;
    private LightingCollider2D controlLighting;
    public AudioSource Found;
    private bool once;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("uvFlashlight"))
        {
            if (once == false) {
                Found.Play();
            }
            once = true;
            player = GameObject.Find("Player");
            TouchPad = GameObject.Find("TouchPad_Rotator");
            player.GetComponent<PlayerController>().enabled = false;
            TouchPad.GetComponent<PlayerRotation>().rotate = false;
            StartCoroutine(UnfreezeControls());
            //controlLighting = gameObject.GetComponent<LightingCollider2D>();
            //controlLighting.enabled = true;
            HiddenMirror.SetActive(true);
            QuizCheck.EventCheck = true;

        }

    }
    IEnumerator UnfreezeControls() {
        yield return new WaitForSeconds(1.5f);
        player.GetComponent<PlayerController>().enabled = true;
    }

}