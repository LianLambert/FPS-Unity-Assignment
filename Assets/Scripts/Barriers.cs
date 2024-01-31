using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Barriers : MonoBehaviour
{
    public bool combat = false;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject barrier1;
    [SerializeField] private GameObject barrier2;
    [SerializeField] private GameObject barrier3;
    [SerializeField] private GameObject barrier4;
    [SerializeField] private GameObject pathElements;

    // Update is called once per frame
    void Update()
    {
        // if the player has reached the goal area
        if (player.transform.position.x > barrier4.transform.position.x)
        {
            // path disappears
            pathElements.SetActive(false);

            // prevent player from returning to canyon area
            barrier4.GetComponent<BoxCollider>().isTrigger = false;

        }
        // if the player has stepped onto the path
        else if (player.transform.position.x > barrier3.transform.position.x)
        {
            // prevent player from returning to combat area
            barrier2.GetComponent<BoxCollider>().isTrigger = false;
        }


        // if the player has reached the canyon area
        else if (player.transform.position.x > barrier2.transform.position.x)
        {
            // deactivate combat elements
            combat = false;
        }

        // if the player has reached the combat area
        else if (player.transform.position.x > barrier1.transform.position.x)
        {

            // prevent player from returning to starting area and activate combat elements
            barrier1.GetComponent<BoxCollider>().isTrigger = false;
            combat = true;

            // once the target is destroyed, allow player to pass to canyon area
            if (bullet.GetComponent<Bullet>().targetDestroyed)
            {
                barrier2.GetComponent<BoxCollider>().isTrigger = true;
            }

        }
    }
}
