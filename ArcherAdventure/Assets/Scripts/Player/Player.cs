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

    void Update()
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
     void OnTriggerExit2D( Collider2D collision )
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