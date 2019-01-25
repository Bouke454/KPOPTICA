using UnityEngine;
using System.Collections;

public class QuizActivator : MonoBehaviour {
    public GameObject Quiz;
	public GameObject GameController;
    public GameObject MirrorEvent;
	public Event QuizCheck;
	private LightingCollider2D controlLighting;
    private GameObject player;
    private GameObject TouchPad;
    private void OnTriggerEnter2D(Collider2D other) {
        player = GameObject.Find("Player");
        TouchPad = GameObject.Find("TouchPad_Rotator");
        if (other.CompareTag("Flashlight") && QuizCheck.EventCheck == true)
		{
            MirrorEvent.SetActive(true);
            player.GetComponent<PlayerController>().enabled = false;
            TouchPad.GetComponent<PlayerRotation>().rotate = false;
            StartCoroutine(StartQuiz());
		}
		else
		{
			Debug.Log("You need to finish the event first!");
		}
    }

    IEnumerator StartQuiz() {
        yield return new WaitForSeconds(1);
        player.GetComponent<PlayerController>().enabled = true;
        MirrorEvent.SetActive(false);
        Quiz.SetActive(true);
        GameController.SetActive(true);
    }

}