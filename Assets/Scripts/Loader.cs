using UnityEngine;
using System.Collections;
using Completed;


public class Loader : MonoBehaviour
{
    public GameObject gameManager;            //GameManager prefab to instantiate.
    private GameObject player;
    public bool followplayer = false; 
    private Vector3 position;

    void Awake()
    {
        //Check if a GameManager has already been assigned to static variable GameManager.instance or if it's still null
        if (GameManager.instance == null)
        {  //Instantiate gameManager prefab
            Instantiate(gameManager);
        }




    }

    private void Start()
    {  
        position = transform.position - new Vector3(-7,6,0);

    }

    void Update()
    {
        
        this.player = GameObject.Find("Player(Clone)") as GameObject;
        if(this.player != null){
            transform.position = player.transform.position + position;
        }

        
        
    }



}