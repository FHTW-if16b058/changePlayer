using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public RoundController roundController;

    // Use this for initialization
	void Awake () {
        roundController = GetComponent<RoundController>();
        roundController.StartGame();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
