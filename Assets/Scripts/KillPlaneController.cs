using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlaneController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        // Check if object is of tag Player
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Ball")
        {
            // GAME OVER
            UIController.GameOver = true;
        }
    }
}
