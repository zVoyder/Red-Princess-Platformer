using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class DialogueManager : MonoBehaviour {
	public float displayLetterTime = 0.5f;
	public AudioClip[] voiceSounds;

	private Text dialogueText;
	private Animator animator;
	private AudioSource audio;
	private Player player;
	private Dialogue dialogue;

	bool isTalking;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		dialogueText = GetComponentInChildren<Text>();
		audio = GetComponent<AudioSource>();

		player = FindObjectOfType<Player>();
	}

	public void SetUpDialogue(Dialogue dialogue)
    {
		player.inputsController.EnableTalk();
		player.SetDialogueReference(this);
		player.Freeze();
		animator.SetBool("isOpen", true);

		this.dialogue = dialogue;
    }

	/// I will call this method via animation, so the text will not appear before the animation's end.
	public void StartDialogue ()
	{
		//sentences.Enqueue(string.Empty);
		DisplayNextSentence();
	}

	public void DisplayNextSentence ()
	{
		if (dialogue.isEnd() && !isTalking)
		{
			EndDialogue();
			return;
		}

		StopAllCoroutines();
		if (!isTalking)
        {
			StartCoroutine(TypeSentence(dialogue.Next()));
        }
        else
        {
			isTalking = false;
			dialogueText.text = dialogue.Current();
        }
	}

	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		isTalking = true;
		foreach (char letter in sentence.ToCharArray())
		{
			audio.clip = voiceSounds[Random.Range(0, voiceSounds.Length)];
			audio.Play();
			dialogueText.text += letter;
			yield return new WaitForSeconds(displayLetterTime);
		}
		isTalking = false;
	}

	void EndDialogue()
	{
		dialogueText.text = "";
		animator.SetBool("isOpen", false);
		player.DeFreeze();
		player.inputsController.DisableTalk();
	}
}
