using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameUIControlsManager : MonoBehaviour {
    [SerializeField]
    private bool _shouldRestartGame;
    private float _screenStayMinimum = 1f;

	// Update is called once per frame
	void Update () {
        ManageInputs();
	}

    void ManageInputs()
    {
        _screenStayMinimum -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) 
            && _screenStayMinimum < 0
            && !_shouldRestartGame)
        {
            int buildIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(buildIndex + 1);
        }
        else if (Input.GetKeyDown(KeyCode.Space)
            && _screenStayMinimum < 0
            && _shouldRestartGame)
        {
            int buildIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(0);
        }
    }
}
