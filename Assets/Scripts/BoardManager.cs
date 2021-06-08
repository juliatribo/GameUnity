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

        GameObject instance;

        bool restaurant = false;
        bool bridge = false;
        bool main = false;


            public void SetupScene(int level, int scene)
        {
            if (scene == 0 && !main)
            {
                Destroy(instance);


                mainBoard = new GameObject("Board").transform;

                GameObject toInstantiate = Resources.Load("Prefabs/Level" + level.ToString() + "/MainBoard") as GameObject;

                instance = Instantiate(toInstantiate, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;

                instance.transform.SetParent(mainBoard);

                restaurant = false;
                bridge = false;
                main = true;

            }

            else if (scene == 1 && !restaurant)
            {

                Destroy(instance);

                restaurantBoard = new GameObject("Bridge").transform;

                GameObject toInstantiate = Resources.Load("Prefabs/Level" + level.ToString() + "/Restaurant") as GameObject;

                instance = Instantiate(toInstantiate, new Vector3(-2, -2, 0), Quaternion.identity) as GameObject;

                instance.transform.SetParent(restaurantBoard);

                restaurant = true;
                bridge = false;
                main = false;

            }

            else if (scene == 3 && !bridge)
            {
                Destroy(instance);

                bridgeBoard = new GameObject("Bridge").transform;

                GameObject toInstantiate = Resources.Load("Prefabs/Level" + level.ToString() + "/MainBoardBridge") as GameObject;

                instance = Instantiate(toInstantiate, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;

                instance.transform.SetParent(bridgeBoard);

                restaurant = false;
                bridge = true;
                main = false;
            }
        }
    }
}