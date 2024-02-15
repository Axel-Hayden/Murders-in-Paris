using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogueManager : MonoBehaviour
{
    public Image actorImage;
    public TextMeshProUGUI actorName;
    public TextMeshProUGUI messageText;
    public RectTransform backgroundBox;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage =0;
    public static bool isActive = false;

    public void OpenDialogue(Message[] messages, Actor[] actors){
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;
        Debug.Log("Started conversation! Loaded messages;" + messages.Length);
        DisplayMessage();
        backgroundBox.LeanScale(Vector3.one, .3f);
    }

    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;
    }
    public void NextMessage(int mes)
    {
        activeMessage = mes;
        if (activeMessage < currentMessages.Length) {
            DisplayMessage();
        }
        else {
            Debug.Log("Conversation ended");
            backgroundBox.LeanScale(Vector3.zero, .3f).setEaseInOutExpo();
            activeMessage = 0;
            isActive = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (activeMessage == 0 && isActive == true) {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                NextMessage(1);
                Debug.Log("1 pressed");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                NextMessage(2);
                Debug.Log("2 pressed");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                NextMessage(3);
                Debug.Log("3 pressed");
            }

        }
        if (activeMessage != 0 && isActive == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                backgroundBox.LeanScale(Vector3.zero, .3f).setEaseInOutExpo();
                activeMessage = 0;
                isActive = false;
                Debug.Log("Space pressed");
            }
        }
    }
}
