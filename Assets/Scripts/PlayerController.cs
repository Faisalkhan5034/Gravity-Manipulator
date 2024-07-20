using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Private Variables
    private float speed = 3.0f;
    private float turnSpeed = 50.0f;
    private float horizantalInput;
    private float forwardInput;
    private Rigidbody playerRb;
    private Animator playerAnime;
    private float jumpForce = 10f;


    [HideInInspector]
    public bool isOnGround;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnime = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        // Get the Input
        horizantalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        
        //Move the Player Forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        //Rotate the Player
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizantalInput);

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnime.SetBool("Fall", true);
        }
        else
        {
            playerAnime.SetBool("Fall", false);
        }


        if (forwardInput != 0)
        {
            playerAnime.SetBool("Run", true);
        }else if (forwardInput == 0) 
        {
            playerAnime.SetBool("Run", false);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isOnGround = true;
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isOnGround = false;
        }
    }

}
