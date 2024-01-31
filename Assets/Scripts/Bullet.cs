using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    [SerializeField] public bool targetDestroyed = false;
    [SerializeField] public bool leftPathsSafe;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject targetHitText;
    [SerializeField] private GameObject pathElements;
    [SerializeField] private Barriers barriers;
    [SerializeField] private float bulletSpeed = 20f;
    private RaycastHit hit;
    private bool shot = false;

    // Start is called before the first frame update
    // make bullet not visible to player
    void Start()
    {
        gameObject.transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // display gun if in combat zone
        gun.SetActive(barriers.combat);

        // shoot gun if player is in the combat zone and left clicks and a bullet is not already shooting
        if (barriers.combat && Input.GetMouseButtonDown(0) && !shot)
        {
            Shoot();

        }

    }

    void Shoot()
    {
        // move bullet to mainCamera position and make visible
        transform.position = mainCamera.transform.position;
        gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

        // generate straight line forward from camera until it hits something
        Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit);

        // shoot the bullet and mark it as shooting
        StartCoroutine(MoveBullet());
        shot = true;
    }

    IEnumerator MoveBullet()
    {
        // while the bullet is not at the hit point, continue moving it towards the hit point
        if (transform.position != hit.point)
        {
            transform.position = Vector3.MoveTowards(transform.position, hit.point, bulletSpeed * Time.deltaTime);
            yield return null;
            yield return MoveBullet();
        }

        // if the bullet has hit the target
        if (hit.collider.gameObject.tag == "Target")
        {
            // generate random boolean to decide safe/unsafe paths
            leftPathsSafe = Random.Range(0, 2) == 0;

            // mark target as destroyed and deactivate it
            targetDestroyed = true;
            target.SetActive(false);

            // activate target hit text and path elements (begins canyon path generation)
            targetHitText.SetActive(true);
            pathElements.SetActive(true);
        }

        // make bullet invisible, mark it as done shooting
        gameObject.transform.localScale = new Vector3(0, 0, 0);
        shot = false;
        yield break;
    }
}