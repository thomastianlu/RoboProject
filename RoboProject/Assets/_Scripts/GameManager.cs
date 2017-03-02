using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public bool bossIsWalking = true;
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void ManageBossMovementSpeed()
    {
        platformMoveSpeed += Time.deltaTime * 0.02f;
    }
}
