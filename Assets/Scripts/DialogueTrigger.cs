using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;
    public int clue;
    private Scene scene;

    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    public void StartDialogue(){
        FindObjectOfType<DialogueManager>().OpenDialogue(messages, actors, clue);
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