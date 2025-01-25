using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float SPEED;
    public int moveHorizontal;
    public int moveVertical;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SPEED = 2.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            // Set move direction up
            moveVertical = 1;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            moveVertical = 0;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            // Set move direction down
            moveVertical = -1;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            moveVertical = 0;
        }



        if (Input.GetKeyDown(KeyCode.A))
        {
            // Set move direction left
            moveHorizontal = -1;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            moveHorizontal = 0;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            // Set move direction right
            moveHorizontal = 1;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            moveHorizontal = 0;
        }

        rb.velocity = new Vector2 (moveHorizontal * SPEED, moveVertical * SPEED);
    }
}
