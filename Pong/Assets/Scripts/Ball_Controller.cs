using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Controller : MonoBehaviour {

    Rigidbody rb;

	void Start () {

        //Shortcut for component
        rb = GetComponent<Rigidbody> ();

        //Delay Ball launch
        StartCoroutine(Pause ());

	}

    void LaunchBall()
    {
        //Reset Position
        transform.position = Vector3.zero;

        //Randomize intial X velocity
        int xDirection = Random.Range(0, 3);


        //Randomize intial Y velocity
        int yDirection = Random.Range(0, 3);

        Vector3 launchDirection = new Vector3();

        //Check results of randomization
        //x-axis
        if (xDirection == 0)
        {
            launchDirection.x = -8f;
        }
        if (xDirection == 1)
        {
            launchDirection.x = 8f;
        }
        if (xDirection == 2)
        {
            launchDirection.x = 0f;
        }

        //y-axis
        if (yDirection == 0)
        {
            launchDirection.y = -3f;
        }
        if (yDirection == 1)
        {
            launchDirection.y = 3f;
        }
        if (yDirection == 2)
        {
            launchDirection.y = 0f;
        }

        rb.velocity = launchDirection;

    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(2.5f);

        LaunchBall();
    }

    void Update () {
		
        //If ball goes behind Player 1
        if (transform.position.x < -17f)
        {
            StartCoroutine(Pause());
        }

        //If ball goes behind Player 2
        if(transform.position.x > 17f)
        {
            StartCoroutine(Pause());
        }

	}

    //When ball hits something
    void OnCollisionEnter(Collision hit)
    {
        //If hit boundary
        if(hit.gameObject.name == "TopBounds")
        {
            float speedInXDirection = 0f;

            if (rb.velocity.x > 0f)
                speedInXDirection = 8f;

            if (rb.velocity.x < 0f)
                speedInXDirection = -8f;

            rb.velocity = new Vector3(speedInXDirection, -8f, 0f);
        }

        if (hit.gameObject.name == "BottomBounds")
        {
            float speedInXDirection = 0f;

            if (rb.velocity.x > 0f)
                speedInXDirection = 8f;

            if (rb.velocity.x < 0f)
                speedInXDirection = -8f;

            rb.velocity = new Vector3(speedInXDirection, 8f, 0f);
        }
        //If hit bat
        if (hit.gameObject.name == "Player 1")
        {
            rb.velocity = new Vector3(8f, 0f, 0f);

            //If hit lower half of bat...
            if(transform.position.y - hit.gameObject.transform.position.y < -0.2)
            {
                rb.velocity = new Vector3(8f, -8f, 0f);
            }

            //If hit upper half of bat...
            if (transform.position.y - hit.gameObject.transform.position.y > -0.2)
            {
                rb.velocity = new Vector3(8f, 8f, 0f);
            }
        }

        if (hit.gameObject.name == "Player 2")
        {
            rb.velocity = new Vector3(-8f, 0f, 0f);

            //If hit lower half of bat...
            if (transform.position.y - hit.gameObject.transform.position.y < -0.2)
            {
                rb.velocity = new Vector3(-8f, -8f, 0f);
            }

            //If hit upper half of bat...
            if (transform.position.y - hit.gameObject.transform.position.y > -0.2)
            {
                rb.velocity = new Vector3(-8f, 8f, 0f);
            }
        }
    }
}
