using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;         //Allows us to use Lists.
using Random = UnityEngine.Random;         //Tells Random to use the Unity Engine random number generator.
using System.Text;

namespace Completed
{
    public class BoardManager : MonoBehaviour
    {
        private Transform mainBoard;
        private Transform bridgeBoard;
        private Transform restaurantBoard;

        GameObject toInstantiate;
        GameObject toInstantiate2;
        GameObject toInstantiate3;
        GameObject toInstantiate4;
        GameObject toInstantiate5;

        GameObject map;
        GameObject healthy1;
        GameObject healthy2;
        GameObject healthy3;
        GameObject healthy4;
        GameObject player; 

        public bool restaurant = false;
        public bool bridge = false;
        public bool main = false;

        public bool h1 = true;
        public bool h2 = true;
        public bool h3 = true;
        public bool h4 = true;


        public List<String> levelPaths; 
        private NetworkManagerScript networkManagerScript; 


        public GameObject getPlayer() {
            return this.player; 
        }


        public void setValues()
        {
            this.main = false;
            h1 = true; h2 = true; h3 = true; h4 = true; 
        }



        private void Awake()
        {
            levelPaths = new List<String>(); 
            this.networkManagerScript = GameObject.Find("NetworkManager").GetComponent<NetworkManagerScript>(); 
         
        }


        private void Start() {
           
        }
        public void SetupScene(int level, int scene, string path)
        {
               
            //basándonos en la escena y el nivel pedimos todo el nivel así seteamos todas las propiedades: 
            foreach(NetworkManagerScript.Level l  in this.networkManagerScript.levels){
                Debug.Log(l);
            }

            if (scene == 0 && !main)
            {


                                
                //pedir al servidorl la uri del recurso board 
                mainBoard = new GameObject("Board").transform;
                //meter el recurso para cargarlo
                toInstantiate = Resources.Load(path+ "/MainBoard") as GameObject;
                map = Instantiate(toInstantiate, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                map.transform.SetParent(mainBoard);
                player = GameObject.Find("Player(Clone)");
                if (player == null)
                {
                    player = Resources.Load("Player") as GameObject;
                    Instantiate(player, new Vector2(-7, 6), Quaternion.identity);
                }
                else {
                    player.transform.position = this.player.GetComponent<PlayerScript>().getLastPosition(); 
                }

                if (h1)
                {
                    
                    toInstantiate2 = Resources.Load(path + "/Healthy1") as GameObject;
                    healthy1= Instantiate(toInstantiate2, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    healthy1.transform.SetParent(mainBoard);
                }
                if (h2)
                {
                    toInstantiate3 = Resources.Load(path + "/Healthy2") as GameObject;
                    healthy2 = Instantiate(toInstantiate3, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    healthy2.transform.SetParent(mainBoard);
                }
                if (h3)
                {
                    toInstantiate4 = Resources.Load(path+ "/Healthy3") as GameObject;
                    healthy3 = Instantiate(toInstantiate4, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    healthy3.transform.SetParent(mainBoard);
                }
                if (h4)
                {
                    toInstantiate5 = Resources.Load(path+ "/Healthy4") as GameObject;
                    healthy4 = Instantiate(toInstantiate5, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    healthy4.transform.SetParent(mainBoard);
                }
      
                restaurant = false;
                bridge = false;
                main = true;
            }

            else if (scene == 1 && !restaurant)
            {
                //pedir el restaurante 
                restaurantBoard = new GameObject("Restaurant").transform;
                toInstantiate = Resources.Load(path + "/Restaurant") as GameObject;
                map = Instantiate(toInstantiate, new Vector3(-3, -4, 0), Quaternion.identity) as GameObject;
                map.transform.SetParent(restaurantBoard);

                restaurant = true;
                bridge = false;
                main = false;
            }

            else if (scene == 3 && !bridge)
            {
                //pedir el puente
                bridgeBoard = new GameObject("Bridge").transform;
                toInstantiate = Resources.Load(path + "/MainBoardBridge") as GameObject;
                map = Instantiate(toInstantiate, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                map.transform.SetParent(bridgeBoard);

                this.player.transform.position = this.player.GetComponent<PlayerScript>().getLastPosition(); 

                if (h1)
                {
                    toInstantiate2 = Resources.Load(path+ "/Healthy1") as GameObject;
                    healthy1 = Instantiate(toInstantiate2, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    healthy1.transform.SetParent(bridgeBoard);
                }
                if (h2)
                {
                    toInstantiate3 = Resources.Load(path + "/Healthy2") as GameObject;
                    healthy2 = Instantiate(toInstantiate3, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    healthy2.transform.SetParent(bridgeBoard);
                }
                if (h3)
                {
                    toInstantiate4 = Resources.Load(path + "/Healthy3") as GameObject;
                    healthy3 = Instantiate(toInstantiate4, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    healthy3.transform.SetParent(bridgeBoard);
                }
                if (h4)
                {
                    toInstantiate5 = Resources.Load(path+ "/Healthy4") as GameObject;
                    healthy4 = Instantiate(toInstantiate5, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    healthy4.transform.SetParent(bridgeBoard);
                }

                restaurant = false;
                bridge = true;
                main = false;
            }
        }
    }
}