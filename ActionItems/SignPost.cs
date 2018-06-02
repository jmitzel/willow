using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignPost : Interactable {

    public string[] dialogue;
    public string signName;

	public override void Interact()
    {
        DialogueSystem.Instance2.AddNewDialogue(dialogue,signName);
        Debug.Log("Turn back now");
    }
}
