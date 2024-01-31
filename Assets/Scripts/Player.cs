using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject gameLostText;
    [SerializeField] private GameObject gameWonText;
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float rotateSpeed = 50.0f;


    // Start is called before the first frame update
    void Start()
    {
        // spawn player in top left corner
        transform.position = new Vector3(-30, 1, 30);
    }

    // Update is called once per frame
    void Update()
    {

        // if at any point the player falls (e.g. into canyon), display game over and allow player to restart
        if (transform.position.y < -5)
        {
            gameLostText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        // if player has won the game, allow player to restart
        if (gameWonText.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        UpdateMovement();
    }

    // allow player to move forward, backward and to turn
    void UpdateMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-1 * Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -1 * Time.deltaTime * rotateSpeed, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 1 * Time.deltaTime * rotateSpeed, 0);
        }
    }
}
