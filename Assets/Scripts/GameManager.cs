using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if(GameManager.instance != null)
        {
            Destroy(gameObject);
            Destroy(player.gameObject);
            Destroy(floatingTextManager.gameObject);
            return;
        }
        instance = this;
        SceneManager.sceneLoaded += LoadState;
        //level based teleporting
        if(LevelCheck.PreviousLevel == "IntroScene")
            player.transform.position = new Vector3((float) -3.46,(float) 2,0);
        else if(LevelCheck.PreviousLevel == "TopGameRoom")
            player.transform.position = new Vector3((float) -3.46,(float) 8.5,0);
        else if(LevelCheck.PreviousLevel == "LeftGameRoom")
            player.transform.position = new Vector3((float) -14,(float) 4.6,0);
        else if(LevelCheck.PreviousLevel == "RightGameRoom")
            player.transform.position = new Vector3((float) 7,(float) 4.6,0);
    }

    private void FixedUpdate()
    {
        movex = Input.GetAxisRaw("Horizontal");
        movey = Input.GetAxisRaw("Vertical");
    }
    /*private void Update()
    {
        if(clueNum.Count != 0 && ClueNumStatic.Count != 0){
            if(clueNum.Count > ClueNumStatic.Count)
            {
                ClueNumStatic.Clear();
                for(int i = 0; i < clueNum.Count; i++)
                    ClueNumStatic.Add(clueNum[i]);
            }
            else if(ClueNumStatic.Count > clueNum.Count)
            {
                clueNum.Clear();
                for(int i = 0; i < ClueNumStatic.Count; i++)
                    clueNum.Add(ClueNumStatic[i]);
            }
        }
    }*/

    //Animation Control Lock
    public bool isAnimation;

    //Clues Collected
    public static readonly List<int> clueNum = new List<int>();

    //The Clues Which Point To The Correct Suspect
    public static readonly List<int> correctClues = new List<int>(){1,5,8};

    //private static List<int> ClueNumStatic;

    public static float movex,movey;
    //Resources
    public List<Sprite> playerSprite;

    public  List<Sprite> suspectSprite;

    //References
    public Player player;
    public FloatingTextManager floatingTextManager;

    public Animator animator;
    //Logic
    public int dollars;


    //floating text
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    //Game Save
    public void SaveState()
    {
        string s = "";
        s += dollars.ToString() + "|";
        PlayerPrefs.SetString("SaveState", s);
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
        {
            return;
        }

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');
        dollars = int.Parse(data[1]);

        player.transform.position = GameObject.Find("SpawnPoint").transform.position;



    }

}
