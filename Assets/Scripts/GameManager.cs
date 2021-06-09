using UnityEngine;
using System.Collections;

using System.Collections.Generic;
using Completed;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;                //Static instance of GameManager which allows it to be accessed by any other script.
    public BoardManager boardScript;
    public Loader loader;
    private int level = 1;


    public int playerLifePoints = 100;
    public bool palanca = false;

    //Awake is always called before any Start functions
    void Awake()
    {
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


        //Call the InitGame function to initialize the first level
        InitGame();
    }

    //Initializes the game for each level.
    void InitGame()
    {
        //Call the SetupScene function of the BoardManager script, pass it current level number.
        boardScript.SetupScene(level, 0);

    }

    public void Restaurant()
    {
        boardScript.SetupScene(level, 1);

    }


    public void Palanca()
    {
        this.palanca = true;
    }

    public void Bridge()
    {
        if (palanca == true)
            boardScript.SetupScene(level, 3);
        else
            boardScript.SetupScene(level, 0);
    }



    public void setHealthy(string healthy) {
        switch (healthy) {
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
        this.level += 1;
        palanca = false;
        boardScript.h1 = true;
        boardScript.h2 = true;
        boardScript.h3 = true;
        boardScript.h4 = true;
        boardScript.SetupScene(level, 0);
    }

    public void GameOver()
    {
        enabled = false;
    }


    //Update is called every frame.
    void Update()
    {
    }
}