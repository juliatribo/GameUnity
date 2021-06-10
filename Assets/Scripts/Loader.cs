using UnityEngine;
using System.Collections;
using Completed;


public class Loader : MonoBehaviour
{
    public GameObject gameManager;            //GameManager prefab to instantiate.
    private GameObject player;
    private Vector3 position;
    private BoardManager boardManager;

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
        this.player = GameObject.Find("Player(Clone)") as GameObject;
        position = transform.position - player.transform.position;

    }

    void Update()
    {
        transform.position = player.transform.position + position;
    }



}