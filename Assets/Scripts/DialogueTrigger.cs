using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{
    public Message[] messages;
    public int dialogueSplit, splitStart, clue, lock1, lock2;
    public Actor[] actors;
    private Scene scene;
    public bool collected = false;

    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    public void StartDialogue()
    {
        FindObjectOfType<IntroNPCDialogue>().intChange(clue, dialogueSplit, splitStart, lock1, lock2);
        FindObjectOfType<IntroNPCDialogue>().OpenDialogue(messages, actors);
    }
}

[System.Serializable]
public class Message{
    public int actorId;
    public string message;
}

[System.Serializable]
public class Actor{
    public string name;
    public Sprite sprite;
}