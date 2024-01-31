using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goalPoint : MonoBehaviour
{
    [SerializeField] private GameObject gameWonText;
    [SerializeField] private GameObject goalAreaText;

    private void OnCollisionEnter(Collision collision)
    {
        // when the player reaches the goal area
        if (collision.gameObject.tag == "Player")
        {
            // deactivate goalAreaText and goal point, displaygameWonText
            goalAreaText.SetActive(false);
            this.gameObject.SetActive(false);
            gameWonText.SetActive(true);
        }
        
    }
}
