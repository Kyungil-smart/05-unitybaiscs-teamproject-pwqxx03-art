using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool isTouchTop;
    public bool isTouchBottom;
    public bool isTouchRight;
    public bool isTouchLeft;

    public GameObject weaponA;
    public GameObject weaponB;

    // [New] Reference for the specific firing position (The "LaunchPoint" object)
    public Transform launchPoint;

    // Variables related to launch cooldown
    public float fireRate = 0.2f; // firing interval (seconds)
    private float nextFireTime = 0f;

    void Update()
    {
        Move();
        Fire();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if ((isTouchRight && horizontalInput == 1) || (isTouchLeft && horizontalInput == -1))
            horizontalInput = 0;

        float verticalInput = Input.GetAxisRaw("Vertical");
        if ((isTouchTop && verticalInput == 1) || (isTouchBottom && verticalInput == -1))
            verticalInput = 0;

        Vector3 moveTo = new Vector3(horizontalInput, verticalInput, 0f).normalized;
        transform.position += moveTo * moveSpeed * Time.deltaTime;
    }

    void Fire()
    {   
        

        if (Time.time < nextFireTime)
            return;

        nextFireTime = Time.time + fireRate;

        Vector3 spawnPosition;
        // Quaternion spawnRotation;

        if (launchPoint != null)
        {
            spawnPosition = launchPoint.position;
            // spawnRotation = launchPoint.rotation;
        }
        else
        {
            spawnPosition = transform.position + new Vector3(0, 0.7f, 0);
            // spawnRotation = transform.rotation;
            Debug.LogWarning("LaunchPoint is not assigned in the Inspector! Using default position.");
        }

        GameObject weapon = Instantiate(weaponA, spawnPosition, Quaternion.identity);

        Collider2D weaponCollider = weapon.GetComponent<Collider2D>();
        Collider2D playerCollider = GetComponent<Collider2D>();
        if (weaponCollider != null && playerCollider != null)
        {
            Physics2D.IgnoreCollision(weaponCollider, playerCollider);
        }

        Rigidbody2D rigid = weapon.GetComponent<Rigidbody2D>();
        if (rigid != null)
        {
            rigid.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Border"))
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = true;
                    break;
                case "Bottom":
                    isTouchBottom = true;
                    break;
                case "Right":
                    isTouchRight = true;
                    break;
                case "Left":
                    isTouchLeft = true;
                    break;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Border"))
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = false;
                    break;
                case "Bottom":
                    isTouchBottom = false;
                    break;
                case "Right":
                    isTouchRight = false;
                    break;
                case "Left":
                    isTouchLeft = false;
                    break;
            }
        }
    }
}