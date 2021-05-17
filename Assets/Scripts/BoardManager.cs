using UnityEngine;
using System;
using System.Collections.Generic;         //Allows us to use Lists.
using Random = UnityEngine.Random;         //Tells Random to use the Unity Engine random number generator.

namespace Completed

{

    public class BoardManager : MonoBehaviour
    {
        // Using Serializable allows us to embed a class with sub properties in the inspector.
        [Serializable]
        public class Count
        {
            public int minimum;             //Minimum value for our Count class.
            public int maximum;             //Maximum value for our Count class.


            //Assignment constructor.
            public Count(int min, int max)
            {
                minimum = min;
                maximum = max;
            }
        }


        public int columns;                                         //Number of columns in our game board.
        public int rows;                                            //Number of rows in our game board.
        public Count wallCount = new Count(5, 9);                        //Lower and upper limit for our random number of walls per level.
        public Count foodCount = new Count(1, 5);                        //Lower and upper limit for our random number of food items per level.
        public GameObject exit;                                            //Prefab to spawn for exit.
        public GameObject[] waterTiles;
        public GameObject[] sandTiles;
        public GameObject[] houseTiles;
        public GameObject[] decorationTiles;
        public GameObject floorTile;                                    //Array of floor prefabs.
        public GameObject[] horizontalWallTiles;                        //Array of wall prefabs.
        public GameObject[] verticallWallTiles;
        public GameObject[] foodTiles;                                    //Array of food prefabs.
        public GameObject[] enemyTiles;                                    //Array of enemy prefabs.
        public GameObject outerWallTile;                                //Array of outer tile prefabs.

        private Transform boardHolder;                                    //A variable to store a reference to the transform of our Board object.
        private List<Vector3> gridPositions = new List<Vector3>();    //A list of possible locations to place tiles.


        //Clears our list gridPositions and prepares it to generate a new board.
        void InitialiseList()
        {
            //Clear our list gridPositions.
            gridPositions.Clear();

            //Loop through x axis (columns).
            for (int x = 1; x < columns; x++)
            {
                //Within each column, loop through y axis (rows).
                for (int y = 1; y < rows; y++)
                {
                    //At each index add a new Vector3 to our list with the x and y coordinates of that position.
                    gridPositions.Add(new Vector3(x, y, 0f));
                }
            }
        }


        //Sets up the outer walls and floor (background) of the game board.
        void BoardSetup()
        {
            //Instantiate Board and set boardHolder to its transform.
            boardHolder = new GameObject("Board").transform;

            //Loop along x axis, starting from -1 (to fill corner) with floor or outerwall edge tiles.
            for (int x = -1; x < columns + 1; x++)
            {
                //Loop along y axis, starting from -1 to place floor or outerwall tiles.
                for (int y = -1; y < rows + 1; y++)
                {
                    //Choose a random tile from our array of floor tile prefabs and prepare to instantiate it.
                    GameObject toInstantiate = floorTile;

                    //Check if we current position is at board edge, if so choose a random outer wall prefab from our array of outer wall tiles.
                    if (x == -1 || x == columns || y == -1 || y == rows)
                        toInstantiate = outerWallTile;

                    // LEFT PATH

                    if (x > 1 && x < 3 && y > 1 && y < 15)
                        toInstantiate = sandTiles[0];

                    if (x == 1 && y > 1 && y < 15)
                        toInstantiate = sandTiles[1];

                    if (x == 3 && y > 1 && y < 15)
                        toInstantiate = sandTiles[2];

                    if (x == 1 && y == 1)
                        toInstantiate = sandTiles[6];

                    if (x > 1 && x < 3 && y == 1)
                        toInstantiate = sandTiles[7];

                    if (x == 3 && y == 1)
                        toInstantiate = sandTiles[7];

                    if (x == 3 && y == 2)
                        toInstantiate = sandTiles[0];

                    if (x > 3 && x < 11 && y ==2)
                        toInstantiate = sandTiles[4];

                    if (x > 3 && x < 11 && y ==1)
                        toInstantiate = sandTiles[7];

                    if (x == 11 && y == 2)
                        toInstantiate = sandTiles[5];

                    if (x == 11 && y == 1)
                        toInstantiate = sandTiles[8];

                    //1ST WALL

                    if (x == 7 &&  y > 8 && y < 15)
                        toInstantiate = verticallWallTiles[Random.Range(0, 2)];

                    //2ND WALL

                    if (y == 6 && x > 6 && x < 15)
                        toInstantiate = horizontalWallTiles[1];

                    if (y == 6 && x == 6)
                        toInstantiate = horizontalWallTiles[0];

                    if (y == 6 && x == 15)
                        toInstantiate = horizontalWallTiles[2];

                    //3RD WALL

                    if (y == 4 && x > 16 && x < 25)
                        toInstantiate = horizontalWallTiles[1];

                    if (y == 4 && x == 16)
                        toInstantiate = horizontalWallTiles[0];

                    if (y == 4 && x == 25)
                        toInstantiate = horizontalWallTiles[2];


                    //LAKE

                    if (x > 14 && x < 16 && y > 0 && y < 14)
                        toInstantiate = waterTiles[Random.Range(0, 2)];

                    if (x == 14 && y >0 && y < 14)
                        toInstantiate = waterTiles[2];

                    if (x == 16 && y > 0 && y < 14)
                        toInstantiate = waterTiles[3];

                    if (x == 14 && y == 14)
                        toInstantiate = waterTiles[4];

                    if (x > 14 && x < 16 && y == 14)
                        toInstantiate = waterTiles[5];

                    if (x == 16 && y == 14)
                        toInstantiate = waterTiles[6];

                    if (x == 14 && y == 0)
                        toInstantiate = waterTiles[7];

                    if (x > 14 && x < 16 && y == 0)
                        toInstantiate = waterTiles[8];

                    if (x == 16 && y == 0)
                        toInstantiate = waterTiles[9];

                    //PATH RIGHT

                   
                    if (x > 16 && x < 26 && y == 10)
                        toInstantiate = sandTiles[4];

                    if (x > 16 && x < 26 && y == 9)
                        toInstantiate = sandTiles[7];

                    if (x == 16 && y < 11 && y > 8)
                        toInstantiate = waterTiles[10];

                    if (x == 26 && y == 10)
                        toInstantiate = sandTiles[5];

                    if (x == 26 && y == 9)
                        toInstantiate = sandTiles[8];





                    //Instantiate the GameObject instance using the prefab chosen for toInstantiate at the Vector3 corresponding to current grid position in loop, cast it to GameObject.
                    GameObject instance =
                        Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;

                    //Set the parent of our newly instantiated object instance to boardHolder, this is just organizational to avoid cluttering hierarchy.
                    instance.transform.SetParent(boardHolder);
                }
            }
        }


        //RandomPosition returns a random position from our list gridPositions.
        Vector3 RandomPosition()
        {
            //Declare an integer randomIndex, set it's value to a random number between 0 and the count of items in our List gridPositions.
            int randomIndex = Random.Range(0, gridPositions.Count);

            //Declare a variable of type Vector3 called randomPosition, set it's value to the entry at randomIndex from our List gridPositions.
            Vector3 randomPosition = gridPositions[randomIndex];

            //Remove the entry at randomIndex from the list so that it can't be re-used.
            gridPositions.RemoveAt(randomIndex);

            //Return the randomly selected Vector3 position.
            return randomPosition;
        }


        //LayoutObjectAtRandom accepts an array of game objects to choose from along with a minimum and maximum range for the number of objects to create.
        void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum)
        {
            //Choose a random number of objects to instantiate within the minimum and maximum limits
            int objectCount = Random.Range(minimum, maximum + 1);

            //Instantiate objects until the randomly chosen limit objectCount is reached
            for (int i = 0; i < objectCount; i++)
            {
                //Choose a position for randomPosition by getting a random position from our list of available Vector3s stored in gridPosition
                Vector3 randomPosition = RandomPosition();

                //Choose a random tile from tileArray and assign it to tileChoice
                GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];

                //Instantiate tileChoice at the position returned by RandomPosition with no change in rotation
                Instantiate(tileChoice, randomPosition, Quaternion.identity);
            }
        }


        //SetupScene initializes our level and calls the previous functions to lay out the game board
        public void SetupScene(int level)
        {
            //Creates the outer walls and floor.
            BoardSetup();

            //Reset our list of gridpositions.
            InitialiseList();

            //Instantiate a random number of wall tiles based on minimum and maximum, at randomized positions.
            //LayoutObjectAtRandom(wallTiles, wallCount.minimum, wallCount.maximum);

            //Instantiate a random number of food tiles based on minimum and maximum, at randomized positions.
            LayoutObjectAtRandom(foodTiles, foodCount.minimum, foodCount.maximum);

            //Determine number of enemies based on current level number, based on a logarithmic progression
            int enemyCount = (int)Mathf.Log(level, 2f);

            //Instantiate a random number of enemies based on minimum and maximum, at randomized positions.
            LayoutObjectAtRandom(enemyTiles, enemyCount, enemyCount);

            //Instantiate the exit tile in the upper right hand corner of our game board
            Instantiate(exit, new Vector3(columns - 1, rows - 1, 0f), Quaternion.identity);

            //left house with flowers

            Instantiate(decorationTiles[2], new Vector3(8, 3, 0f), Quaternion.identity);

            GameObject houseChoice = houseTiles[Random.Range(0, houseTiles.Length)];
            Instantiate(houseChoice, new Vector3(10,3, 0f), Quaternion.identity);

            //right house with flowers

            Instantiate(decorationTiles[2], new Vector3(23, 11, 0f), Quaternion.identity);

            GameObject house2Choice = houseTiles[Random.Range(0, houseTiles.Length)];
            Instantiate(house2Choice, new Vector3(25, 11, 0f), Quaternion.identity);

            //first wall with decoration
            Instantiate(decorationTiles[1], new Vector3(9, 14, 0f), Quaternion.identity);
            Instantiate(decorationTiles[0], new Vector3(8, 12, 0f), Quaternion.identity);

            //third wall with decoration
            Instantiate(decorationTiles[1], new Vector3(18, 1, 0f), Quaternion.identity);
            Instantiate(decorationTiles[0], new Vector3(21, 1, 0f), Quaternion.identity);



        }
    }
}