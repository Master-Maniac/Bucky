using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public float SlowFactor = 20f;

    public void EndGame()
    {
        StartCoroutine(RestartLevel());
    }

    IEnumerator RestartLevel()
    {
        //before 1 sec

        Time.timeScale = 1f / SlowFactor;
        Time.fixedDeltaTime = Time.fixedDeltaTime / SlowFactor;

        yield return new WaitForSeconds(1f/SlowFactor);

        //after 1 sec

        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * SlowFactor;

        SceneManager.LoadScene(2);
    }
}
