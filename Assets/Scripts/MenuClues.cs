using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class MenuClues : MonoBehaviour
{
    public Sprite Clues, Context;
    public int whichClue;
    public GameObject GameManager;
    public string content, tips;
    public Button but;
    public GameObject leftPage;
    public GameObject rightPage;

    void Start()
    {
        but.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        GameObject rightChild = rightPage.transform.GetChild(0).gameObject;
        if (GameManager.GetComponent<GameManager>().clueNum.Contains(whichClue))
        {
            rightChild.SetActive(true);
            leftPage.GetComponent<TMPro.TextMeshProUGUI>().text = content;
            rightChild.GetComponent<Image>().sprite = Context; 
            rightPage.GetComponent<TMPro.TextMeshProUGUI>().text = tips;
        }
        else
        {
            rightChild.SetActive(false);
            leftPage.GetComponent<TMPro.TextMeshProUGUI>().text = "Look harder";
            rightPage.GetComponent<TMPro.TextMeshProUGUI>().text = "";
        }
    }

    void Update()
    {
        /*if(this.transform.parent.gameObject.activeInHierarchy == false)
        {

            this.GetComponent<RectTransform>().position = this.transform.parent.GetComponent<RectTransform>().position;
        }*/
    }

}
