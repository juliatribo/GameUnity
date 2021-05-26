using UnityEngine;
using System.Collections;

using System.Collections.Generic;
using Completed;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;                //Static instance of GameManager which allows it to be accessed by any other script.
    public BoardManager boardScript;


    public int playerLifePoints = 100;
    public  bool palanca = false;

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



        //Call the InitGame function to initialize the first level
        InitGame();
    }

    //Initializes the game for each level.
    void InitGame()
    {
        //Call the SetupScene function of the BoardManager script, pass it current level number.
        boardScript.SetupScene(0);

    }

    public void Restaurant()
    {
        boardScript.SetupScene(1);
      
    }


    public void Palanca()
    {
        this.palanca = true;
    }

    public void Bridge()
    {
        if (palanca)
            boardScript.SetupScene(3);
        else
            boardScript.SetupScene(0);
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