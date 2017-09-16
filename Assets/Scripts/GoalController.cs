using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour {

    [SerializeField] private GameObject m_UI;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        // Check if object is of tag Player
        if (other.gameObject.tag == "Player")
        {
            // YOU WIN
            YouWin();
        }
    }

    void YouWin()
    {
        UIController.GameComplete = true;   
    }
}
