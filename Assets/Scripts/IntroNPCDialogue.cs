using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class IntroNPCDialogue : MonoBehaviour
{
    public Image actorImage;
    public TextMeshProUGUI actorName;
    public TextMeshProUGUI messageText;
    public RectTransform backgroundBox;
    public GameObject GameManagers;
    public Animator animator;
    Vector2 movement;
    private int whichClue, dialogueSplit, splitStart;
    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    public static bool isActive = false;
    private bool collected = false;

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {

        currentMessages = messages;
        currentActors = actors;
        if(collected == false)
            activeMessage = 0;
        else
            activeMessage = splitStart;
        isActive = true;
        Debug.Log("Started conversation! Loaded messages;" + messages.Length);
        DisplayMessage();
        backgroundBox.LeanScale(Vector3.one, .3f);
    }

    void DisplayMessage()
    {
        GameManagers.GetComponent<GameManager>().isAnimation = true;
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;
    }
    public void NextMessage(int x)
    {
        if (x == 0)
        {
            activeMessage = activeMessage + 1;
            if (activeMessage < currentMessages.Length)
            {
                DisplayMessage();
            }
            else
            {
                Debug.Log("Conversation ended");
                backgroundBox.LeanScale(Vector3.zero, .3f).setEaseInOutExpo();
                activeMessage = 0;
                GameManagers.GetComponent<GameManager>().isAnimation = false;
                isActive = false;
                if(whichClue != 0)
                    GameManager.clueNum.Add(whichClue);
            }
        }
        else
        {
            activeMessage = x;
            if (activeMessage < currentMessages.Length)
            {
                DisplayMessage();
            }
            else
            {
                Debug.Log("Conversation ended");
                backgroundBox.LeanScale(Vector3.zero, .3f).setEaseInOutExpo();
                activeMessage = 0;
                GameManagers.GetComponent<GameManager>().isAnimation = false;
                isActive = false;
                collected = true;
            }
        }
    }

    // Start is called before the first frame update
    public void intChange(int clue, int dSplit, int sSplit)
    {
        backgroundBox.transform.localScale = Vector3.zero;
        whichClue = clue;
        dialogueSplit = dSplit;
        splitStart = sSplit;
    }

    public void collect(bool col)
    {
        collected = col;
    }
    // Update is called once per frame
    void Update()
    {
        if (isActive == true)
        {
            animator.SetFloat("Speed", movement.sqrMagnitude);
            if(Input.GetKeyDown(KeyCode.Space) && activeMessage > dialogueSplit)
            {
                Debug.Log("Conversation ended");
                backgroundBox.LeanScale(Vector3.zero, .3f).setEaseInOutExpo();
                activeMessage = 0;
                GameManagers.GetComponent<GameManager>().isAnimation = false;
                isActive = false;
                if(whichClue != 0)
                    GameManager.clueNum.Add(whichClue);
                collected = true;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && activeMessage != dialogueSplit)
            {
                NextMessage(0);
                Debug.Log("Next");
            }
            else if (activeMessage == dialogueSplit)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    NextMessage(dialogueSplit + 1);
                    Debug.Log("1 pressed");
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    NextMessage(dialogueSplit + 2);
                    Debug.Log("2 pressed");
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    NextMessage(dialogueSplit + 3);
                    Debug.Log("3 pressed");
                }

            }
        }

    }
}

