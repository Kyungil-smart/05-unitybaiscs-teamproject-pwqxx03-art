using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
  [SerializeField] private float _moveSpeed;

    private void Update()
    {
        transform.position += -transform.up * _moveSpeed * Time.deltaTime;
    }
}
