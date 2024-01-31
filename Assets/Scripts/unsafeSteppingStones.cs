using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unsafeSteppingStones : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {

        // unsafe stones disappear if the player steps onto them
        if (collision.gameObject.tag == "Player")
        {
            this.gameObject.SetActive(false);
        }
    }
}
