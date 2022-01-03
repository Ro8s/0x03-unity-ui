using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    private int score;
    public int health;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        health = 5;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float vHorizontal = Input.GetAxis("Horizontal") * speed;
        float vVertical = Input.GetAxis("Vertical") * speed;
        rb.velocity = new Vector3(vHorizontal, 0, vVertical);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            score += 1;
            SetScoreText();
            Debug.Log("Score: " + score);
            Destroy(other.gameObject);
        }
        if (other.tag == "Trap")
        {
            health -= 1;
            Debug.Log("Health: " + health);
        }
        if (other.tag == "Goal")
        {
            Debug.Log("You win!");
        }
    }
    private void Update()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene("maze");
        }
    }
    void SetScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
