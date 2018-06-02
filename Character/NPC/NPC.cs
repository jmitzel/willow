using UnityEngine;
using UnityEngine.AI;

public class NPC : Interactable {

    public string[] dialogue;
    public string npcName;

    public override void Interact()
    {
        DialogueSystem.Instance2.AddNewDialogue(dialogue, npcName);
        Debug.Log("Interacting with NPC");
    }
}