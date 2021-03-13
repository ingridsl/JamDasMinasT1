using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    public float moveSpeed = 1f;
    public GameManager gameManager = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        //transform.position += movement * Time.deltaTime * moveSpeed;

        Vector3 moveInput = Vector3.zero;
        if (Input.GetKey(gameManager.left) || Input.GetKey(gameManager.right))
        {
            //moveInput = Vector3.left;
            moveInput.x =  Input.GetAxis("Horizontal");
        }

        if (Input.GetKey(gameManager.up) || Input.GetKey(gameManager.down))
        {
            //moveInput = Vector3.right;
            moveInput.y = Input.GetAxis("Vertical");
        }
        transform.position += moveInput * moveSpeed * Time.deltaTime;
    }
}
