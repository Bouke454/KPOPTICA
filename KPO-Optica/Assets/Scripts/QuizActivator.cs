using UnityEngine;
using System.Collections;

public class QuizActivator : MonoBehaviour {
    public GameObject Quiz;
	public GameObject GameController;
    public GameObject MirrorEvent;
	public Event QuizCheck;
	private LightingCollider2D controlLighting;
    private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Flashlight") && QuizCheck.EventCheck == true)
		{
            MirrorEvent.SetActive(true);
            Invoke("StartQuiz", 2f);
		}
		else
		{
			Debug.Log("You need to finish the event first!");
		}
    }
    public void StartQuiz() {
        MirrorEvent.SetActive(false);
        Quiz.SetActive(true);
        GameController.SetActive(true);
    }

}