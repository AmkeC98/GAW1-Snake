using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    public GameObject tailPrefab;

    Vector2 dir = Vector2.right;
    List<Transform> tail = new List<Transform>();
    bool ate = false;

    void Start()
    {
        InvokeRepeating("Move", 0.3f, 0.3f);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            dir = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir = Vector2.right;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            dir = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir = Vector2.down;
        }
    }

    void Move()
    {
        // Save current position (gap will be here)
        Vector2 v = transform.position;

        // Move head into new direction (now there is a gap)
        transform.Translate(dir);

        if (ate)
        {
            // Load prefab into the world
            GameObject g = (GameObject)Instantiate(tailPrefab, v, Quaternion.identity);

            // Keep track of it in our tail list
            tail.Insert(0, g.transform);

            // Reset the flag
            ate = false;
        }
        // Do we have a tail?
        else if (tail.Count > 0)
        {
            Debug.Log(tail.Count);

            if (tail.Count == 3)
            {
                WinGame();
            }

            // Move last Tail Element to where the Head was
            tail.Last().position = v;

            // Add to front of list, remove from the back
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Food"))
        {
            ate = true;
            Destroy(collision.gameObject);
        }
        else if (collision.tag.Equals("Wall"))
        {
            LoseGame();
        }
    }

    void WinGame()
    {
        Debug.Log("You win!");
        SceneManager.LoadScene("WinScene");
    }

    void LoseGame()
    {
        Debug.Log("You lose!");
        SceneManager.LoadScene("LoseScene");
    }
}
