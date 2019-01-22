using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

	public Dialogue dialogue;
    private bool check;
    void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" && check == false)
		{
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            check = true;
        }

		if (other.CompareTag("Flashlight") && tag != "Solid" && check == false)
		{
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            check = true;

        }
	}


	public void TriggerDialogue()
	{
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
	}

}
