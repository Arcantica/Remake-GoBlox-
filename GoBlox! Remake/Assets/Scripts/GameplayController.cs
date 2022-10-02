using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    public Box boxScript;
    public BoxSpawner boxSpawner;
    public static GameplayController instance;

    [HideInInspector]
    public Box currentBox;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        boxSpawner.SpawnBox();
        PlayerPrefs.DeleteKey("totalScore");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("BoxDrop");
            currentBox.DropBox();
        }
        if(currentBox.isLanded)
        {
            boxSpawner.SpawnBox();
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene(1);
    }
}
