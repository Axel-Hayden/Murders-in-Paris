using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class AccuseButton : MonoBehaviour
{

    public Button but;
    public GameObject Connections;
    private GameObject game, game1;
    public string loseScene, winScene;
    private int count = 0,count2 = 0;
    public int sus, pageSus;


    void Start()
    {
        but.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {

        for (int i = 0; i < Connections.transform.childCount; i++) //checks number of suspect pages
        {
            game = Connections.transform.GetChild(i).gameObject; //get the children of connect and saves them to a variable
            if (Connections.transform.GetChild(i).gameObject.activeInHierarchy == true) //checks if suspect page is active
            {
                pageSus = i;
                for(int y = 1; y < game.transform.childCount; y++) //looks at all but the first child
                {
                    if(game.transform.GetChild(y).childCount > 0) //checks to see if the children of suspect page have children
                    {
                        count++;
                        if(count > 1)
                        {
                            winOrLose();
                        }

                    }
                }
            }
        }

        void winOrLose()
        {
            for(int x = 1; x <= 12; x++)//checks for clues starting at 1; no zeroth clue
            { 
                if(GameManager.clueNum.Contains(x) && GameManager.correctClues.Contains(x)) //checks to see if the player has the correct clues for the suspect
                { 
                    count2++;
                    Debug.Log("count 2 = " + count2);
                    Debug.Log(x + " clue");
                }
            }
            if(count2 >= 6 && pageSus == sus)//if player has collected at least 3 associated clues then they win
            { 
                UnityEngine.SceneManagement.SceneManager.LoadScene(winScene);
            }
            else
                UnityEngine.SceneManagement.SceneManager.LoadScene(loseScene);
        }

            /*for (int i = 0; i < Connections.transform.childCount; i++)
            {
                game = Connections.transform.GetChild(i).gameObject;
                if (game.GetComponentsInChildren<MenuClues>() != null)
                {
                    //count++;
                    //Debug.Log(count);
                    if (game.GetComponentsInChildren<MenuClues>().length > 2)
                        UnityEngine.SceneManagement.SceneManager.LoadScene(winScene);
                    else
                        UnityEngine.SceneManagement.SceneManager.LoadScene(loseScene);
                }
            }
                //GameManager.GetComponent<GameManager>().isAnimation = true;
                 for (int i = 0; i < Connections.transform.childCount; i++)
                 {
                     game = Connections.transform.GetChild(i).gameObject; //suspect connects
                     for (int x = 0; x < game.transform.childCount; x++)
                     {
                         game1 = game.transform.GetChild(i).gameObject; //pic frame & clue spots
                         for (int y = 0; x < game1.transform.childCount; y++) {
                             if (game1.transform.GetChild(y).gameObject.GetComponents<MenuClues>().Length != 0 && game1.transform.GetChild(y).gameObject != null)
                             {
                                 count++;
                                 if(count > 2)
                                 {
                                     UnityEngine.SceneManagement.SceneManager.LoadScene(winScene);
                                 }
                                 else
                                     UnityEngine.SceneManagement.SceneManager.LoadScene(loseScene);
                             }

                         }
                     }*/

        

    }
}
