using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyColision : MonoBehaviour
{
    public AudioSource manager;

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            manager.Play();
            Debug.Log(manager.isPlaying);
            StartCoroutine(waiting());
        }
    }
    private IEnumerator waiting()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("Game Over");
    }
}
