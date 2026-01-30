using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private int playerSpeed = 3;
    [SerializeField]private Rigidbody2D _rigidbody;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.velocity = Vector2.up * playerSpeed;
        }
    }
}
