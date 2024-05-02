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
    private int whichClue, dialogueSplit, splitStart, cLock, cLock1, diaClue;
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
                Debug.Log(activeMessage);
                if(whichClue != 0 && activeMessage == diaClue)
                    GameManager.clueNum.Add(whichClue);
                activeMessage = 0;
                GameManagers.GetComponent<GameManager>().isAnimation = false;
                isActive = false;
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
                Debug.Log(activeMessage);
                if(whichClue != 0 && activeMessage == diaClue)
                    GameManager.clueNum.Add(whichClue);
                activeMessage = 0;
                GameManagers.GetComponent<GameManager>().isAnimation = false;
                isActive = false;
                collected = true;
            }
        }
    }

    // Start is called before the first frame update
    public void intChange(int clue, int dSplit, int sSplit, int locked, int locked1, int dClues)
    {
        whichClue = clue;
        dialogueSplit = dSplit;
        splitStart = sSplit;
        cLock = locked;
        cLock1 = locked1;
        diaClue = dClues;
    }

    void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
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
            animator.SetFloat("Speed", movement.sqrMagnitude); //stop player sprite from moving
            if(Input.GetKeyDown(KeyCode.Space) && (activeMessage > dialogueSplit) && (activeMessage != 13 && activeMessage != 14 && activeMessage != 15)) //ends dialogue if you are on page beyond the dialouge split and hit space
            {
                Debug.Log("Conversation ended");
                backgroundBox.LeanScale(Vector3.zero, .3f).setEaseInOutExpo();
                Debug.Log(activeMessage);
                if(whichClue != 0 && activeMessage == diaClue)
                    GameManager.clueNum.Add(whichClue);
                activeMessage = 0;
                GameManagers.GetComponent<GameManager>().isAnimation = false;
                isActive = false;
                collected = true;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && activeMessage == dialogueSplit - 1)
            {
                if(GameManager.clueNum.Contains(cLock) && GameManager.clueNum.Contains(cLock1))
                {
                    NextMessage(13);
                }
                else if (GameManager.clueNum.Contains(cLock1))
                {
                    NextMessage(14);
                }
                else if (GameManager.clueNum.Contains(cLock))
                {
                    NextMessage(15);
                }
                else if (Input.GetKeyDown(KeyCode.Space) && (activeMessage != dialogueSplit || activeMessage != 13 || activeMessage != 14 || activeMessage != 15))
                {
                    NextMessage(0);
                    Debug.Log("Next");
                } 
            }
            else if (Input.GetKeyDown(KeyCode.Space) && activeMessage != dialogueSplit && activeMessage != 13 && activeMessage != 14 && activeMessage != 15)
            {
                NextMessage(0);
                Debug.Log("Next");
            }
            else if (activeMessage == dialogueSplit || activeMessage == 13 || activeMessage == 14 || activeMessage == 15) //when at the dialogue split allows for different questioning options
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
                else if (Input.GetKeyDown(KeyCode.Alpha4) && GameManager.clueNum.Contains(cLock)) //checks collected clues to see if player has context to ask this question
                {
                    NextMessage(dialogueSplit + 4);
                    Debug.Log("4 pressed");
                }
                else if (Input.GetKeyDown(KeyCode.Alpha5) && GameManager.clueNum.Contains(cLock1)) //checks collected clues to see if player has context to ask this question
                {
                    NextMessage(dialogueSplit + 5);
                    Debug.Log("5 pressed");
                }

            }
        }

    }
}

