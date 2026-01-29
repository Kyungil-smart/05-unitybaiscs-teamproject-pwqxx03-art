using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D collision )
    {
        if (collision.gameObject.tag =="BorderWeapon")
        {
            Destroy(gameObject);
        }
    }
}
