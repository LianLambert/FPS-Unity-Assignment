using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathLeft : MonoBehaviour
{
    [SerializeField] private Bullet bullet;
    [SerializeField] private GameObject safeStone;
    [SerializeField] private GameObject unsafeStone;
    [SerializeField] private GameObject pathStones;
    private GameObject pathStone;

    // Update is called once per frame
    void Update()
    {

        // path generation only starts once the target is destroyed
        if (bullet.targetDestroyed)
        {
            // use randomly generated boolean to decide if left paths or right paths will be the successful paths
            if (bullet.leftPathsSafe)
            {
                pathStone = safeStone;
            }

            else
            {
                pathStone = unsafeStone;
            }

            // while path does not reach to the other end of the canyon
            while (transform.localPosition.x < 22.5f)
            {
                // if not already at left canyon wall
                if (transform.localPosition.z < 22.5f)
                {
                    // move left or straight randomly and make stepping stone
                    bool left = Random.Range(0, 2) == 0;

                    if (left)
                    {
                        transform.Translate(0, 0, 10);
                        Instantiate(pathStone, transform.position, Quaternion.identity, pathStones.transform);

                    }

                    else
                    {
                        transform.Translate(10, 0, 0);
                        Instantiate(pathStone, transform.position, Quaternion.identity, pathStones.transform);
                    }
                }

                // if at left canyon wall, can only go straight
                else
                {
                    transform.Translate(10, 0, 0);
                    Instantiate(pathStone, transform.position, Quaternion.identity, pathStones.transform);
                }
            }
        }
    }

}
