using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Input_Controller : MonoBehaviour {

    // This script Handles Player Inputs
    // Player 1 = Left bar W/S
    // Player 2 = Right bar Up/Down

    public GameObject Player1;
    public GameObject Player2;

	void Start () {
		
	}
	
	void Update () {

        //Default stationary Player 1
        Player1.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);

        //Player 1 is pressing W
        if (Input.GetKey(KeyCode.W))
        {
            Player1.GetComponent<Rigidbody>().velocity = new Vector3(0f, 7f, 0f);
        }

        //Player 1 is pressing S
        else if (Input.GetKey(KeyCode.S))
        {
            Player1.GetComponent<Rigidbody>().velocity = new Vector3(0f, -7f, 0f);
        }


        //Default Stationary Player 2
        Player2.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);

        //Player 2 is pressing W
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Player2.GetComponent<Rigidbody>().velocity = new Vector3(0f, 7f, 0f);
        }

        //Player 2 is pressing S
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Player2.GetComponent<Rigidbody>().velocity = new Vector3(0f, -7f, 0f);
        }


    }
}
