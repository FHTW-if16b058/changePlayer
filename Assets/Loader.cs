using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

    public GameObject _controller;

	void Awake () {
		if (RoundController.instance == null)
        {
            Instantiate(_controller);
        }
	}
}
