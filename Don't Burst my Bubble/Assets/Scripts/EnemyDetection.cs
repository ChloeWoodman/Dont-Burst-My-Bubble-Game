using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDetection : MonoBehaviour
{
    public float SPEED;
    public GameObject Path;
    private Vector3 movePos;
    private Rigidbody2D rb;
    private int index = 1;
    Transform[] points;

    // Start is called before the first frame update
    void Start()
    {
        SPEED = 0.045f;
        rb = GetComponent<Rigidbody2D>();
        if (Path != null)
        {
            points = Path.GetComponentsInChildren<Transform>();
            movePos = points[index].position;
        }
        else
        {
            movePos = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
       if (movePos != null)
        {
            rb.position = Vector3.MoveTowards(transform.position, movePos, SPEED);
        }

       if (gameObject.transform.position == movePos)
        {
            index++;
            if (index > points.Length - 1)
            {
                index = 1;
            }
            movePos = points[index].position;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            movePos = collision.transform.position;
        }
    }
}
