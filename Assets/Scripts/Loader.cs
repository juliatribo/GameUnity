using UnityEngine;
using System.Collections;


public class Loader : MonoBehaviour
{
    public GameObject gameManager;            //GameManager prefab to instantiate.
    public GameObject player;
    private Vector3 position;

    void Awake()
    {
        position = transform.position - player.transform.position;
        //Check if a GameManager has already been assigned to static variable GameManager.instance or if it's still null
        if (GameManager.instance == null)

            //Instantiate gameManager prefab
            Instantiate(gameManager);


    }

    void Update()
    {
        transform.position = player.transform.position + position;

    }


}