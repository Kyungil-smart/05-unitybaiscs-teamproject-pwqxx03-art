using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battleback : MonoBehaviour
{
    private float moveSpeed = 3f;
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
    }
}
