using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDetection : MonoBehaviour
{
    public float SPEED;
    private Vector3 movePos;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        SPEED = 0.03f;
        rb = GetComponent<Rigidbody2D>();
        movePos = rb.position;
    }

    // Update is called once per frame
    void Update()
    {
       
        rb.position = Vector3.MoveTowards(transform.position, movePos, SPEED);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            movePos = collision.transform.position;
        }
    }
}
