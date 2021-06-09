using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public enum RoamingDirection
    {
        Horizontal,
        Vertical

    }

    public enum State
    {
        Roaming,
        Attacking

    }
    public float movementRange = 3f;
    public float movementSpeed = 5f;
    private Vector2 startingPosition;

    private Transform transform;
    private Rigidbody2D rigidbody2D;
   // private Animator animator;
    public RoamingDirection direction;


    private State state;

    private bool dir1 = true;

    void Awake()
    {
        this.transform = GetComponent<Transform>();
    //    this.animator = GetComponent<Animator>();
        this.rigidbody2D = GetComponent<Rigidbody2D>();

    }
    // Start is called before the first frame update
    void Start()
    {
        this.state = State.Roaming;
        this.startingPosition = this.transform.position;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        //FindTarget();
        switch (state)
        {
            case State.Roaming:
                Roaming();
                break;
      //      case State.Attacking:
       //         AttackTarget();
        //        break;
        }
    }



    void Roaming()
    {
        //Roam aroudn in the specified lenght
        if (this.direction == RoamingDirection.Horizontal)
        {
            if (dir1)
            {
                this.rigidbody2D.MovePosition(this.rigidbody2D.position - Vector2.right * this.movementSpeed * Time.fixedDeltaTime);
                if (this.transform.position.x < this.startingPosition.x - this.movementRange + Mathf.Epsilon)
                {
                    this.transform.localScale = new Vector2(-this.transform.localScale.x, this.transform.localScale.y);
                    this.dir1 = false;
                }
            }
            if (!dir1)
            {
                this.rigidbody2D.MovePosition(this.rigidbody2D.position + Vector2.right * this.movementSpeed * Time.fixedDeltaTime);
                if (this.transform.position.x > this.startingPosition.x + this.movementRange - Mathf.Epsilon)
                {
                    this.transform.localScale = new Vector2(-this.transform.localScale.x, this.transform.localScale.y);
                    this.dir1 = true;
                }
            }

        }
        if (this.direction == RoamingDirection.Vertical)
        {
            if (dir1)
            {
                this.rigidbody2D.MovePosition(this.rigidbody2D.position - Vector2.up * this.movementSpeed * Time.fixedDeltaTime);
                if (this.transform.position.y < this.startingPosition.y - this.movementRange + Mathf.Epsilon)
                {
                    this.transform.localScale = new Vector2(-this.transform.localScale.x, this.transform.localScale.y);
                    this.dir1 = false;
                }
            }
            if (!dir1)
            {
                this.rigidbody2D.MovePosition(this.rigidbody2D.position + Vector2.up * this.movementSpeed * Time.fixedDeltaTime);
                if (this.transform.position.y > this.startingPosition.y + this.movementRange - Mathf.Epsilon)
                {
                    this.transform.localScale = new Vector2(-this.transform.localScale.x, this.transform.localScale.y);
                    this.dir1 = true;
                }
            }
        }


    }


    void FindTarget()
    {
        //detect the player at 0.5 unit distance
        RaycastHit2D horizontalHit = new RaycastHit2D();
        if (this.direction == RoamingDirection.Horizontal)
            if (dir1) { horizontalHit = Physics2D.Raycast(this.transform.position, -Vector2.right, 1f); }
        if (!dir1) { horizontalHit = Physics2D.Raycast(this.transform.position, Vector2.right, 1f); }
        if (horizontalHit.collider != null)
        {
            this.state = State.Attacking;
        }
        else
        {
            this.state = State.Roaming;
        }
        if (this.direction == RoamingDirection.Vertical)
            if (dir1) { horizontalHit = Physics2D.Raycast(this.transform.position, -Vector2.up, 1f); }
        if (!dir1) { horizontalHit = Physics2D.Raycast(this.transform.position, Vector2.up, 1f); }
        if (horizontalHit.collider != null)
        {
         //   this.state = State.Attacking;
        }
        else
        {
            this.state = State.Roaming;
        }


    }

    void AttackTarget()
    {
        this.rigidbody2D.velocity = Vector2.zero;
     //   this.animator.SetTrigger("attack");
    }



}

