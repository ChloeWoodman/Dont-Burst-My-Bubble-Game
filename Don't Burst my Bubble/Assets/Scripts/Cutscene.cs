using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    public AudioSource manager;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
    }

    void EndCutscene()
    {
        gameManager.LoadNextScene();
    }

    void PlaySound()
    {
        manager.Play();
    }
}
