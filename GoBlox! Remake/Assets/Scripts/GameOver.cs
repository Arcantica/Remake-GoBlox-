using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private void GameEnd()
    {
        SceneManager.LoadScene(1);
    }
}
