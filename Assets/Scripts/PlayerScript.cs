using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;        //Allows us to use SceneManager
using Completed;
using EasyJoystick;

public class PlayerScript : MonoBehaviour
{


    [SerializeField] private float speed;
    private Joystick joystick;



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
    private int healthLimit = 5;
    private bool canTakeDamage = true;
    private float speedLimit = 8f;
    public Vector2 lastPostion;

    private Potion healthpotion;
    private Potion resistancepotion;
    private Potion speedpotion;

  
    public AudioClip eatSound1;
    public AudioClip eatSound2;
    public AudioClip hitSound1;
    public AudioClip hitSound2;
    public AudioClip deadSound;
    public AudioClip palancaSound;

    private Vector2 touchOrigin = new Vector2(-15, -15);

    private NetworkManagerScript networkManager; 

    private void Awake()
    {
        this.rb2d = GetComponent<Rigidbody2D>();
        this.transform = GetComponent<Transform>();
        this.animator = GetComponent<Animator>();
        this.boardScript = GetComponent<BoardManager>();
        this.inventory = GetComponent<InventorySystem>();
        this.networkManager = GameObject.Find("NetworkManager").GetComponent<NetworkManagerScript>();  
        this.healthManager = GameObject.Find("Canvas").GetComponent<HealthManager>();

        this.joystick = FindObjectOfType<Joystick>();


    }
    // Start is called before the first frame update
    void Start()
    {

    }


    public Vector2 getLastPosition()
    {
        return this.lastPostion; 

    }


    public int getPotionQuanitity(Potion.potionType type)
    {
        switch (type)
        {
            case Potion.potionType.HEALTH:
                return this.healthpotion.GetQuantity();
            case Potion.potionType.SPEED:
                return this.speedpotion.GetQuantity();
            case Potion.potionType.RESISTANCE:
                return this.resistancepotion.GetQuantity();

        }

        return 0;
    }


    public Potion getPotion(Potion.potionType type)
    {
        switch (type)
        {
            case Potion.potionType.HEALTH:
                return this.healthpotion;
            case Potion.potionType.SPEED:
                return this.speedpotion;
            case Potion.potionType.RESISTANCE:
                return this.resistancepotion;

        }

        return null;

    }

    public void setPotion(Potion potion)
    {
        switch (potion.GetType())
        {
            case Potion.potionType.HEALTH:
               this.healthpotion = new Potion(potion.GetType(), potion.GetQuantity());
               break; 
            case Potion.potionType.SPEED:
                this.speedpotion = new Potion(potion.GetType(), potion.GetQuantity());
                break; 
            case Potion.potionType.RESISTANCE:
                this.resistancepotion = new Potion(potion.GetType(), potion.GetQuantity());
                break; 

        }

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
    
    #if UNITY_STANDALONE || UNITY_WEBPLAYER
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

    #elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE

        movX = joystick.Horizontal();
        movY = joystick.Vertical();

        transform.position += new Vector3(movX, movY, 0f) * speed * Time.deltaTime;


    #endif 
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
       
        if (other.tag == "Exit")
        {
            Invoke("Exit",restartLevelDelay);
        }

        else if (other.tag == "House")
        {
            Invoke("House", restartLevelDelay);
        }


        else if (other.tag == "Palanca")
        {
            GameManager.instance.Palanca();
            SoundManager.instance.PlaySingle(palancaSound);
        }

        else if (other.tag == "Door")
        {
            Invoke("Door", restartLevelDelay);

        }

        else if (other.tag == "Healthy1" || other.tag == "Healthy2" || other.tag == "Healthy3" || other.tag == "Healthy4")
        {
            SoundManager.instance.RandomizeSfx(eatSound1,eatSound2);
            GameManager.instance.setHealthy(other.tag);
            inventory.addElement(other.gameObject);
            other.gameObject.SetActive(false);


        }


    }

    public void Exit()
    {
        GameManager.instance.Exit();
        this.transform.position = new Vector2(-7, 6);
        this.networkManager.GetGame().levelsPassed++; 
        Debug.Log(this.networkManager.GetGame().levelsPassed);
        inventory.Reset();
    }

    public void Door()
    {
        GameManager.instance.Bridge();
        this.transform.position = new Vector2(-4, -6);
    }

    public void House()
    {
        GameManager.instance.Restaurant();
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (canTakeDamage)
        {
            if (collision.collider.tag == "Enemy")
            {
                SoundManager.instance.RandomizeSfx(hitSound1, hitSound2);
                this.healthManager.decreaseHealth();
                this.health--;
                if (this.health == 0)
                {
                    GameOver();
                    enabled = false;
                }

            }
        }
    }

    public float increaseSpeed()
    {
        if (this.movementSpeed < this.speedLimit)
        {
            this.movementSpeed++;
        }
        return this.movementSpeed;
    }


    public int increaseLife()
    {
        if (this.health < this.healthLimit)
        {
            this.health++;
            this.healthManager.increaseHealth(this.health);
        }
        return this.health;
    }

    public void invincible()
    {
        this.canTakeDamage = false;
    }

    public void setCanTakeDamage()
    {
        this.canTakeDamage = true;
    }

    public async void GameOver()
    {
        SoundManager.instance.musicSource.Stop();
        SoundManager.instance.PlaySingle(deadSound);
        GameManager.instance.Dead();
        this.networkManager.GetGame().duration = this.networkManager.elapsed_time; 
        //enviar al servidor los datos de la partida 
        await this.networkManager.PostGame_Async(); 
        await this.networkManager.PostUser_Async(); 
    }

}
