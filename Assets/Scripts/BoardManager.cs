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
        GameObject instance2;
        GameObject instance3;
        GameObject instance4;
        GameObject instance5;
        GameObject instance6;
        GameObject instance7;

        bool restaurant = false;
        bool bridge = false;
        bool main = false;

        public int columns = 21;                                         
        public int rows = 15;



            public void SetupScene(int level, int scene)
        {
            if (scene == 0 && !main)
            {
                Destroy(instance);
                Destroy(instance2);
                Destroy(instance3);
                Destroy(instance4);
                Destroy(instance5);
                Destroy(instance6);
                Destroy(instance7);


                mainBoard = new GameObject("Board").transform;

                GameObject toInstantiate = Resources.Load("Prefabs/Level" + level.ToString() + "/Main/FloorMain") as GameObject;
                GameObject toInstantiate2 = Resources.Load("Prefabs/Level" + level.ToString() + "/Main/Lake") as GameObject;
                GameObject toInstantiate3 = Resources.Load("Prefabs/Level" + level.ToString() + "/Main/Exit") as GameObject;
                GameObject toInstantiate4 = Resources.Load("Prefabs/Level" + level.ToString() + "/Main/Houses") as GameObject;
                GameObject toInstantiate5 = Resources.Load("Prefabs/Level" + level.ToString() + "/Main/HealthyFood") as GameObject;
                GameObject toInstantiate6 = Resources.Load("Prefabs/Level" + level.ToString() + "/Main/Deco") as GameObject;
                GameObject toInstantiate7 = Resources.Load("Prefabs/Level" + level.ToString() + "/Main/Block") as GameObject;

                instance = Instantiate(toInstantiate, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                instance2 = Instantiate(toInstantiate2, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                instance3 = Instantiate(toInstantiate3, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                instance4 = Instantiate(toInstantiate4, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                instance5 = Instantiate(toInstantiate5, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                instance6 = Instantiate(toInstantiate6, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                instance7 = Instantiate(toInstantiate7, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;

                instance.transform.SetParent(mainBoard);
                instance2.transform.SetParent(mainBoard);
                instance3.transform.SetParent(mainBoard);
                instance4.transform.SetParent(mainBoard);
                instance5.transform.SetParent(mainBoard);
                instance6.transform.SetParent(mainBoard);
                instance7.transform.SetParent(mainBoard);

                restaurant = false;
                bridge = false;
                main = true;

            }

            else if (scene == 1 && !restaurant)
            {

                Destroy(instance);
                Destroy(instance2);
                Destroy(instance3);
                Destroy(instance4);
                Destroy(instance5);
                Destroy(instance6);
                Destroy(instance7);

                restaurantBoard = new GameObject("Bridge").transform;

                GameObject toInstantiate = Resources.Load("Prefabs/Level" + level.ToString() + "/Restaurant/FloorRest") as GameObject;
                GameObject toInstantiate2 = Resources.Load("Prefabs/Level" + level.ToString() + "/Restaurant/Door") as GameObject;
                GameObject toInstantiate3 = Resources.Load("Prefabs/Level" + level.ToString() + "/Restaurant/Palanca") as GameObject;

                instance = Instantiate(toInstantiate, new Vector3(-2, -2, 0), Quaternion.identity) as GameObject;
                instance2 = Instantiate(toInstantiate2, new Vector3(-2, -2, 0), Quaternion.identity) as GameObject;
                instance3 = Instantiate(toInstantiate3, new Vector3(-2, -2, 0), Quaternion.identity) as GameObject;

                instance.transform.SetParent(restaurantBoard);
                instance2.transform.SetParent(restaurantBoard);
                instance3.transform.SetParent(restaurantBoard);

                restaurant = true;
                bridge = false;
                main = false;

            }

            else if (scene == 3 && !bridge)
            {
                Destroy(instance);
                Destroy(instance2);
                Destroy(instance3);
                Destroy(instance4);
                Destroy(instance5);
                Destroy(instance6);
                Destroy(instance7);

                bridgeBoard = new GameObject("Bridge").transform;

                GameObject toInstantiate = Resources.Load("Prefabs/Level" + level.ToString() + "/Main/FloorMain") as GameObject;
                GameObject toInstantiate2 = Resources.Load("Prefabs/Level" + level.ToString() + "/Main/LakeBridge") as GameObject;
                GameObject toInstantiate3 = Resources.Load("Prefabs/Level" + level.ToString() + "/Main/Exit") as GameObject;
                GameObject toInstantiate4 = Resources.Load("Prefabs/Level" + level.ToString() + "/Main/Houses") as GameObject;
                GameObject toInstantiate5 = Resources.Load("Prefabs/Level" + level.ToString() + "/Main/HealthyFood") as GameObject;
                GameObject toInstantiate6 = Resources.Load("Prefabs/Level" + level.ToString() + "/Main/Deco") as GameObject;
                GameObject toInstantiate7 = Resources.Load("Prefabs/Level" + level.ToString() + "/Main/Block") as GameObject;

                instance = Instantiate(toInstantiate, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                instance2 = Instantiate(toInstantiate2, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                instance3 = Instantiate(toInstantiate3, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                instance4 = Instantiate(toInstantiate4, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                instance5 = Instantiate(toInstantiate5, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                instance6 = Instantiate(toInstantiate6, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                instance7 = Instantiate(toInstantiate7, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;

                instance.transform.SetParent(bridgeBoard);
                instance2.transform.SetParent(bridgeBoard);
                instance3.transform.SetParent(bridgeBoard);
                instance4.transform.SetParent(bridgeBoard);
                instance5.transform.SetParent(bridgeBoard);
                instance6.transform.SetParent(bridgeBoard);
                instance7.transform.SetParent(bridgeBoard);

                restaurant = false;
                bridge = true;
                main = false;
            }
        }
    }
}