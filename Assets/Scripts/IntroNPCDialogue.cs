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
    public GameObject GameManager;
    public Animator animator;
    Vector2 movement;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    public static bool isActive = false;

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
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
        GameManager.GetComponent<GameManager>().isAnimation = true;
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
                GameManager.GetComponent<GameManager>().isAnimation = false;
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
                activeMessage = 0;
                GameManager.GetComponent<GameManager>().isAnimation = false;
                isActive = false;
            }
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
        if (isActive == true)
        {
            animator.SetFloat("Speed", movement.sqrMagnitude);
            if(Input.GetKeyDown(KeyCode.Space) && activeMessage > 3)
            {
                Debug.Log("Conversation ended");
                backgroundBox.LeanScale(Vector3.zero, .3f).setEaseInOutExpo();
                activeMessage = 0;
                GameManager.GetComponent<GameManager>().isAnimation = false;
                isActive = false;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && activeMessage != 3)
            {
                NextMessage(0);
                Debug.Log("Next");
            }
            else if (activeMessage == 3)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    NextMessage(4);
                    Debug.Log("1 pressed");
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    NextMessage(5);
                    Debug.Log("2 pressed");
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    NextMessage(6);
                    Debug.Log("3 pressed");
                }

            }
        }

    }
}

