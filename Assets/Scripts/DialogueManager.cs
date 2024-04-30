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
    public GameObject GameManagers;
    public Animator animator;
    Vector2 movement;
    public int whichClue;
    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage =0;
    public static bool isActive = false;

    public void OpenDialogue(Message[] messages, Actor[] actors,int c){
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;
        Debug.Log("Started conversation! Loaded messages;" + messages.Length);
        DisplayMessage();
        backgroundBox.LeanScale(Vector3.one, .3f);
        whichClue = c;
    }

    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;
    }
    public void NextMessage()
    {
        activeMessage++;
        if (activeMessage < currentMessages.Length) {
            DisplayMessage();
        }
        else {
            Debug.Log(currentMessages.Length);
            Debug.Log("Conversation ended");
            backgroundBox.LeanScale(Vector3.zero, .3f).setEaseInOutExpo();
            activeMessage = 0;
            isActive = false;
            GameManagers.GetComponent<GameManager>().isAnimation = false;
            if(whichClue != 0)
                GameManager.clueNum.Add(whichClue);
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
            GameManagers.GetComponent<GameManager>().isAnimation = true;
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Space pressed");
                NextMessage();
            }
        
    }
}
