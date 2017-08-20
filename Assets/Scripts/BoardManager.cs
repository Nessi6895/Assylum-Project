using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {

    [Serializable]
    public class Count
    {
        public int min;
        public int max;

        public Count(int _min, int _max)
        {
            min = _min;
            max = _max;
        }
    }

    public int columns = 5;
    public int rows = 7;
    public GameObject[] innerWalls;
    public GameObject[] outterWalls;
    public GameObject[] floorTiles;
    public GameObject[] exitProbes;

    private GameObject[] exits;
    private Transform boardHolder;
    private List<Vector3> freePositions;

    private void InitializeExits()
    {
        for(int i = 0; i < exits.Length; i++)
            exits[i] = exitProbes[Random.Range(0, exitProbes.Length)];
    }

    private void InitializeFreePositions()
    {
        for(int i = 1; i <= columns; i++)
        {
            for(int j = 1; j <= rows; j++)
            {
                freePositions.Add(new Vector3(i, j, 0f));
            }
        }
    }

    private void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;
        for(int i = 0; i <= columns + 1; i++)
        {
            for(int j = 0; j <= rows + 1; j++)
            {
                GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];
                if (i == 0 || j == 0 || i == columns + 1 || j == rows + 1) toInstantiate = outterWalls[Random.Range(0, outterWalls.Length)];
                if((i == 0 || i == columns + 1) && j == rows/2 + 1 || (j == 0 || j == rows + 1) && i == columns/2 + 1) toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];

                GameObject instance = Instantiate(toInstantiate, new Vector3(i, j, 0f), Quaternion.identity);
                instance.transform.SetParent(boardHolder);
            }
        }
    }

    public void SetupScene(int level)
    {
        BoardSetup();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
