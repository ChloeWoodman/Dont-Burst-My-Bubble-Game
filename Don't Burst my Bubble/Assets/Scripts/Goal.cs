using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    private GameManager gameManager;
    public AudioSource manager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            manager.Play();
            StartCoroutine(waiting());
        }
    }

    private IEnumerator waiting()
    {
        yield return new WaitForSeconds(0.15f);
        gameManager.LoadNextScene();
    }
}
