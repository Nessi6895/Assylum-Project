using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public BoardManager boardManager;

    public int level = 1;

	// Use this for initialization
	void Awake () {
        boardManager = GetComponent<BoardManager>();
        InitGame();
	}

    private void InitGame()
    {
        boardManager.SetupScene(level);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
