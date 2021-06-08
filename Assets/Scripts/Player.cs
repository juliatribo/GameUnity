using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;        //Allows us to use SceneManager
using Completed;


public class Player : MovingObject
{
    public float restartLevelDelay = 1f;        //Delay time in seconds to restart level.
    public int pointsPerFood = 10;
    public BoardManager boardScript;            //How much damage a player does to a wall when chopping it.


    private Animator animator;                    //Used to store a reference to the Player's animator component.
    private int life;
    private bool reset = true;

    //Start overrides the Start function of MovingObject
    protected override void Start()
    {
        //Get a component reference to the Player's animator component
        animator = GetComponent<Animator>();
        life = GameManager.instance.playerLifePoints;
        boardScript = GetComponent<BoardManager>();

        //Call the Start function of the MovingObject base class.
        base.Start();
    }


    //This function is called when the behaviour becomes disabled or inactive.
    private void OnDisable()
    {
        //When Player object is disabled, store the current local food total in the GameManager so it can be re-loaded in next level.
        GameManager.instance.playerLifePoints = life;
    }


    private void Update()
    {

        int horizontal = 0;      //Used to store the horizontal move direction.
        int vertical = 0;        //Used to store the vertical move direction.

        horizontal = (int)(Input.GetAxisRaw("Horizontal"));
        vertical = (int)(Input.GetAxisRaw("Vertical"));

        if (horizontal == 0 && vertical == 0)
        {
            animator.SetTrigger("stopMoving");
        }
        if (horizontal != 0)
        {
            vertical = 0;
        }
        if (horizontal != 0 || vertical != 0)
        {
            AttemptMove(horizontal, vertical);
        }
    }
    private void AttemptMove(int xDir, int yDir)
    {
        RaycastHit2D hit;
        if (Move(xDir, yDir, out hit))
        {
            animator.SetTrigger("moving");
        }
        else
            animator.SetTrigger("stopMoving");
        CheckIfGameOver();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Exit" && reset)
        {
            Invoke("Restart", restartLevelDelay);
            reset = false;
        }
        else if (other.tag == "House")
        {
            Invoke("Restaurant", restartLevelDelay);
            reset = true;
        }
        else if (other.tag == "Palanca")
        {
            Invoke("Palanca", restartLevelDelay);
        }
        else if (other.tag == "Door")
        {
            Invoke("Bridge", restartLevelDelay);
        }
        else if (other.tag == "Healthy1")
        {
            life += pointsPerFood;
            other.gameObject.SetActive(false);
            Invoke("Healthy1", restartLevelDelay);
        }
        else if (other.tag == "Healthy2")
        {
            life += pointsPerFood;
            other.gameObject.SetActive(false);
            Invoke("Healthy2", restartLevelDelay);
        }
        else if (other.tag == "Healthy3")
        {
            life += pointsPerFood;
            other.gameObject.SetActive(false);
            Invoke("Healthy3", restartLevelDelay);
        }
        else if (other.tag == "Healthy4")
        {
            life += pointsPerFood;
            other.gameObject.SetActive(false);
            Invoke("Healthy4", restartLevelDelay);
        }
    }
    private void Restart()
    {
        RestartPosition();
        GameManager.instance.Exit();
        GameObject food1 = GameObject.FindWithTag("Healthy1");
        food1.SetActive(true);
        GameObject food2 = GameObject.FindWithTag("Healthy2");
        food2.SetActive(true);
        GameObject food3 = GameObject.FindWithTag("Healthy3");
        food3.SetActive(true);
        GameObject food4 = GameObject.FindWithTag("Healthy4");
        food4.SetActive(true);
    }
    private void Restaurant()
    {
        GameManager.instance.Restaurant();
    }
    private void Palanca()
    {
        GameManager.instance.Palanca();
    }
    private void Bridge()
    {
        RestartPositionRestaurant();
        GameManager.instance.Bridge();
    }
    public void losLife(int loss)
    {
        life -= loss;

        CheckIfGameOver();
    } 
    public void Healthy1()
    {
        GameManager.instance.Healthy1();
    }
    public void Healthy2()
    {
        GameManager.instance.Healthy2();
    }
    public void Healthy3()
    {
        GameManager.instance.Healthy3();
    }
    public void Healthy4()
    {
        GameManager.instance.Healthy4();
    }
    private void CheckIfGameOver()
    {
        if (life <= 0)
        {
            GameManager.instance.GameOver();
        }
    }
}