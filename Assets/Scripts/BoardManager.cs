using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;         //Allows us to use Lists.
using Random = UnityEngine.Random;         //Tells Random to use the Unity Engine random number generator.

namespace Completed

{

    public class BoardManager : MonoBehaviour
    {

        private Transform boardHolder;

        GameObject instance;
        GameObject instance2;
        GameObject instance3;
        GameObject instance4;
        GameObject instance5;
        GameObject instance6;
        GameObject instance7;



        public void SetupScene(int level)
        {
            if (level == 0)
            {
                Destroy(instance);
                Destroy(instance2);
                Destroy(instance3);
                Destroy(instance4);
                Destroy(instance5);
                Destroy(instance6);
                Destroy(instance7);


                boardHolder = new GameObject("Board").transform;

                GameObject toInstantiate = Resources.Load("Prefabs/Main1/FloorMain") as GameObject;
                GameObject toInstantiate2 = Resources.Load("Prefabs/Main1/Lake") as GameObject;
                GameObject toInstantiate3 = Resources.Load("Prefabs/Main1/Exit") as GameObject;
                GameObject toInstantiate4 = Resources.Load("Prefabs/Main1/Houses") as GameObject;
                GameObject toInstantiate5 = Resources.Load("Prefabs/Main1/HealthyFood") as GameObject;
                GameObject toInstantiate6 = Resources.Load("Prefabs/Main1/Deco") as GameObject;
                GameObject toInstantiate7 = Resources.Load("Prefabs/Main1/Block") as GameObject;

                instance = Instantiate(toInstantiate, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                instance2 = Instantiate(toInstantiate2, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                instance3 = Instantiate(toInstantiate3, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                instance4 = Instantiate(toInstantiate4, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                instance5 = Instantiate(toInstantiate5, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                instance6 = Instantiate(toInstantiate6, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                instance7 = Instantiate(toInstantiate7, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;

                instance.transform.SetParent(boardHolder);
                instance2.transform.SetParent(boardHolder);
                instance3.transform.SetParent(boardHolder);
                instance4.transform.SetParent(boardHolder);
                instance5.transform.SetParent(boardHolder);
                instance6.transform.SetParent(boardHolder);
                instance7.transform.SetParent(boardHolder);

            }

            else if (level == 1)
            {

                Destroy(instance);
                Destroy(instance2);
                Destroy(instance3);
                Destroy(instance4);
                Destroy(instance5);
                Destroy(instance6);
                Destroy(instance7);

                boardHolder = new GameObject("Restaurant").transform;

                GameObject toInstantiate = Resources.Load("Prefabs/Restaurant/FloorRest") as GameObject;
                GameObject toInstantiate2 = Resources.Load("Prefabs/Restaurant/Door") as GameObject;
                GameObject toInstantiate3 = Resources.Load("Prefabs/Restaurant/Palanca") as GameObject;

                instance = Instantiate(toInstantiate, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                instance2 = Instantiate(toInstantiate2, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                instance3 = Instantiate(toInstantiate3, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;

                instance.transform.SetParent(boardHolder);
                instance2.transform.SetParent(boardHolder);
                instance3.transform.SetParent(boardHolder);

            }

            else if (level == 3)
            {
                Destroy(instance);
                Destroy(instance2);
                Destroy(instance3);
                Destroy(instance4);
                Destroy(instance5);
                Destroy(instance6);
                Destroy(instance7);

                boardHolder = new GameObject("Board").transform;

                GameObject toInstantiate = Resources.Load("Prefabs/Main1/FloorMain") as GameObject;
                GameObject toInstantiate2 = Resources.Load("Prefabs/Main1/LakeBridge") as GameObject;
                GameObject toInstantiate3 = Resources.Load("Prefabs/Main1/Exit") as GameObject;
                GameObject toInstantiate4 = Resources.Load("Prefabs/Main1/Houses") as GameObject;
                GameObject toInstantiate5 = Resources.Load("Prefabs/Main1/HealthyFood") as GameObject;
                GameObject toInstantiate6 = Resources.Load("Prefabs/Main1/Deco") as GameObject;
                GameObject toInstantiate7 = Resources.Load("Prefabs/Main1/Block") as GameObject;

                instance = Instantiate(toInstantiate, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                instance2 = Instantiate(toInstantiate2, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                instance3 = Instantiate(toInstantiate3, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                instance4 = Instantiate(toInstantiate4, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                instance5 = Instantiate(toInstantiate5, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                instance6 = Instantiate(toInstantiate6, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                instance7 = Instantiate(toInstantiate7, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;

                instance.transform.SetParent(boardHolder);
                instance2.transform.SetParent(boardHolder);
                instance3.transform.SetParent(boardHolder);
                instance4.transform.SetParent(boardHolder);
                instance5.transform.SetParent(boardHolder);
                instance6.transform.SetParent(boardHolder);
                instance7.transform.SetParent(boardHolder);
            }
        }
    }
}