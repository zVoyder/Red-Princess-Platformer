using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DialogueTrigger : MonoBehaviour {

    public DialogueManager dialogueReference;
    public Dialogue dialogue;

    private void OnTriggerEnter2D(Collider2D col)
    {
        dialogueReference.SetUpDialogue(dialogue);
        Destroy(gameObject);
	}
}
