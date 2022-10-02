using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Box : MonoBehaviour
{
    private float min_X = -9f;
    private float max_x = 9f;
    private bool canMove;
    [SerializeField] float moveSpeed = 2f;

    public Rigidbody2D rb;

    private bool gameOver;
    private bool ignoreCollision;
    private bool ignoreTrigger;
    public bool isLanded;

    private CameraFollow cameraScript;
    private Score scoreScript;

    private void Awake()
    {
        GameplayController.instance.currentBox = this;
        Debug.Log("gravity equal 0");
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        cameraScript = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
        scoreScript = GameObject.Find("Score").GetComponent<Score>();
        if(Random.Range(0, 2) > 0)
        {
            moveSpeed *= -1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveBox();
    }

    void MoveBox()
    {
        if (canMove)
        {
            Vector3 temp = transform.position;
            temp.x += moveSpeed * Time.deltaTime;
            if(temp.x > max_x)
            {
                moveSpeed *= -1f;
            }
            else if(temp.x < min_X)
            {
                moveSpeed *= -1f;
            }
            transform.position = temp;
        }
    }

    public void DropBox()
    {
        canMove = false;
        rb.gravityScale = 4;
    }

    public void Landed()
    {
        if (isLanded)
        {
            ignoreCollision = true;
            ignoreTrigger = true;
            cameraScript.totalBox += 1;
            cameraScript.CameraGoUp();
            scoreScript.SetScore();
        }
    }
    public void GameOver()
    {
        SceneManager.LoadScene(1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("Box"))
        {
            Debug.Log("Landed");
            isLanded = true;
            Landed();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GameOver"))
        {
            if (!ignoreTrigger)
            {
                GameOver();
            }
        }
    }
}
