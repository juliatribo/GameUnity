using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;        //Allows us to use SceneManager
using Completed;

public class PlayerScript : MonoBehaviour
{
    public float movementSpeed = 5f;
    private Rigidbody2D rb2d;
    private Transform transform;
    private Animator animator;
    private BoardManager boardScript;
    private HealthManager healthManager; 
    private float movX, movY;
    private float restartLevelDelay = 1f;
    private InventorySystem inventory;
    private int health = 5; 

    private void Awake()
    {
        this.rb2d = GetComponent<Rigidbody2D>();
        this.transform = GetComponent<Transform>();
        this.animator = GetComponent<Animator>();
        this.boardScript = GetComponent<BoardManager>();
        this.inventory = GetComponent<InventorySystem>();
        this.healthManager = GameObject.Find("Canvas").GetComponent<HealthManager>(); 

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        getInput();
    }


    private void FixedUpdate()
    {
        movePlayer();
    }

    private void getInput()
    {
        this.movY = Input.GetAxisRaw("Vertical");
        this.movX = Input.GetAxisRaw("Horizontal");
        if (movX < 0)
        {
            this.transform.localScale = new Vector2(-1, 1);
        }
        else if (movX > 0)
        {
            this.transform.localScale = new Vector2(1, 1);
        }
    }

    private void movePlayer()
    {
        this.rb2d.MovePosition(this.rb2d.position + new Vector2(movX, movY) * movementSpeed * Time.fixedDeltaTime);
        if (movX == 0 && movY == 0)
        {
            animator.SetTrigger("stopMoving");
        }
        else
        {
            animator.SetTrigger("moving");
        }


    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        //Check if the tag of the trigger collided with is Exit.
        if (other.tag == "Exit")
        {
            //Invoke the Restart function to start the next level with a delay of restartLevelDelay (default 1 second).
            Restart();
            //Disable the player object since level is over.
        }

        else if (other.tag == "House")
        {
            //Invoke the Restart function to start the next level with a delay of restartLevelDelay (default 1 second).
            Invoke("Restaurant", restartLevelDelay);

            //Disable the player object since level is over.

        }


        else if (other.tag == "Palanca")
        {
            //Invoke the Restart function to start the next level with a delay of restartLevelDelay (default 1 second).
            Invoke("Palanca", restartLevelDelay);

            //Disable the player object since level is over.

        }

        else if (other.tag == "Door")
        {
            //Invoke the Restart function to start the next level with a delay of restartLevelDelay (default 1 second).
            Invoke("Bridge", restartLevelDelay);
            //Disable the player object since level is over.

        }

        //Check if the tag of the trigger collided with is Food.
        else if (other.tag == "Healthy1" || other.tag == "Healthy2" || other.tag == "Healthy3" || other.tag == "Healthy4")
        {
            //Add pointsPerFood to the players current food total.
            GameManager.instance.setHealthy(other.tag);
            inventory.addElement(other.gameObject);
            //Disable the food object the player collided with.
            other.gameObject.SetActive(false);


        }


    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy") {
            this.healthManager.decreaseHealth();
            this.health--;
            if (this.health == 0) {
                Reset(); 
            }

        }
        
    }


    //Restart reloads the scene when called.
    private void Restart()
    {
        this.transform.position = new Vector2(-7, 6);
        GameManager.instance.Exit();
    }

    private void Restaurant()
    {
        GameManager.instance.Restaurant();


        //Load the last scene loaded, in this case Main, the only scene in the game.
    }

    private void Palanca()
    {
        GameManager.instance.Palanca();


        //Load the last scene loaded, in this case Main, the only scene in the game.
    }

    private void Bridge()
    {
        GameManager.instance.Bridge();
        this.transform.position = new Vector2(-4, -6);


        //Load the last scene loaded, in this case Main, the only scene in the game.
    }


    public void Reset()
    {
        this.health = 5; 
        this.inventory.Reset(); 
    }


}
