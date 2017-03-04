using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// Game Manager Script - SINGLETON
// This script manages the speed of the tiles moving in the game
// and to check if the player has died.
// It also gradually increases the speed of the boss walking over time

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public bool bossIsWalking = true;
    public bool playerHasDied = false;
    private float _timeUntilGameOverPage = 3f;

    public float platformMoveSpeed = 1f;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        ManageBossMovementSpeed();
        ManagePlayerDeath();
        ManageQuitInput();
    }

    void ManageBossMovementSpeed()
    {
        platformMoveSpeed += Time.deltaTime * 0.04f;
    }

    void ManagePlayerDeath()
    {
        if (playerHasDied)
        {
            _timeUntilGameOverPage -= Time.deltaTime;

            if (_timeUntilGameOverPage < 0)
            {
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(currentSceneIndex + 1);
            }
        }
    }

    void ManageQuitInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
