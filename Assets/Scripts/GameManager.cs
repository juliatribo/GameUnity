using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using System.Collections.Generic;
using Completed;

public class GameManager : MonoBehaviour
{
    public float levelStartDelay = 2f;
    public static GameManager instance = null;                //Static instance of GameManager which allows it to be accessed by any other script.
    public BoardManager boardScript;
    public Loader loader;
    private int level = 1;
    public PlayerScript player;

    public AudioClip winSound;


    public int playerPoints = 0;
    private int foodPoints = 10;
    public bool palanca = false;

    private Text pointsText;
    private Text levelText;
    private GameObject levelImage;

    //Awake is always called before any Start functions
    void Awake()
    {
        this.player = FindObjectOfType<PlayerScript>();

        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        //DontDestroyOnLoad(gameObject);

        //Get a component reference to the attached BoardManager script
        boardScript = GetComponent<BoardManager>();
        loader = GetComponent<Loader>();

        pointsText = GameObject.Find("PointsText").GetComponent<Text>();
        levelImage = GameObject.Find("LevelImage");
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
        pointsText.text = "Points: " + playerPoints;

        //Call the InitGame function to initialize the first level
        InitGame();
    }

    //Initializes the game for each level.
    public void InitGame()
    {
        //call the api for the corresponding level 
        
        //Call the SetupScene function of the BoardManager script, pass it current level number.
        boardScript.SetupScene(level, 0);
        Invoke("HideLevelImage", levelStartDelay);

    }

    private void Reset()
    {
        palanca = false;
        boardScript.h1 = true;
        boardScript.h2 = true;
        boardScript.h3 = true;
        boardScript.h4 = true;
    }

    public void Dead()
    {
        string[] enfermedades = { "Obesity", "Diabetes", "Hypertension", "Choesterol"};
        int enfermedad = Random.Range(0,enfermedades.Length);
        levelText.text = enfermedades[enfermedad] + " has killed you";
        levelImage.SetActive(true);
        this.GameOver();
    }

    public void Restaurant()
    {
        if (palanca)
            Destroy(GameObject.Find("Bridge"));
        else
            Destroy(GameObject.Find("Board"));

        boardScript.SetupScene(level, 1);

    }


    public void Palanca()
    {
        this.palanca = true;
    }

    public void Bridge()
    {
        Destroy(GameObject.Find("Restaurant"));
        if (palanca)
        {
            boardScript.SetupScene(level, 3);
        }
        else
        {
            boardScript.SetupScene(level, 0);
        }
    }



    public void setHealthy(string healthy)
    {
        playerPoints += foodPoints;
        pointsText.text = "Points: " + playerPoints;
        switch (healthy)
        {
            case "Healthy1":
                Healthy1();
                break;
            case "Healthy2":
                Healthy2();
                break;
            case "Healthy3":
                Healthy3();
                break;
            case "Healthy4":
                Healthy4();
                break;
        }

    }
    public void Healthy1()
    {
        boardScript.h1 = false;
    }

    public void Healthy2()
    {
        boardScript.h2 = false;
    }

    public void Healthy3()
    {
        boardScript.h3 = false;
    }

    public void Healthy4()
    {
        boardScript.h4 = false;
    }

    public void Exit()
    {
        if (level < 4)
        {
            this.level += 1;
            levelText.text = "Level " + this.level;
            levelImage.SetActive(true);
            Invoke("HideLevelImage", levelStartDelay);
            Reset();
            boardScript.SetupScene(level, 0);
            Destroy(GameObject.Find("Bridge"));
        }
        else
        {
            levelText.text = "Congratulations, you are healthy!!";
            levelImage.SetActive(true);
            SoundManager.instance.musicSource.Stop();
            SoundManager.instance.PlaySingle(winSound);
            GameOver();
        }
    }

    private void HideLevelImage()
    {
        levelImage.SetActive(false);
    }

    public void GameOver()
    {

        Destroy(GameObject.Find("GameManager(Clone)"));
    }

}