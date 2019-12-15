using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    int layerMask = 1 << 11;
    public GameObject laser;
    public Animator animator;
    private float timerLaserTime = 0.3f;
    private float timerShootRefresh = 0f;
    private bool hasShot = false;

    // Start is called before the first frame update
    void Start()
    {
        laser.SetActive(false);
        animator.SetBool("IsShooting", false);
    }

    // Update is called once per frame
    void Update()
    {
        timerShootRefresh -= Time.deltaTime;
        if (Input.GetMouseButton(0) && timerShootRefresh < 0f)
        {
            Shooting();
            hasShot = true;
            animator.SetBool("IsShooting", true);
            laser.SetActive(true);
            timerLaserTime -= Time.deltaTime;
            if (timerLaserTime < 0f)
            {
                laser.SetActive(false);
                animator.SetBool("IsShooting", false);
                timerLaserTime = 0.3f;
                timerShootRefresh = 1f;
            }
        }
        if (Input.GetMouseButtonUp(0) && hasShot == true)
        {
            laser.SetActive(false);
            animator.SetBool("IsShooting", false);
            timerShootRefresh = 0.4f;
            hasShot = false;
        }
    }

    void Shooting()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            if (hit.collider.gameObject.CompareTag("Enemy"))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Destroy(hit.collider.gameObject);
            }
        }
        else
        {
            Debug.Log("Miss");
        }
    }
}
