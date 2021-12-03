using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private float movementSpeed;

    protected void Movement(Vector2 dir)
    {
        rb2d.MovePosition(rb2d.position + dir * movementSpeed * Time.fixedDeltaTime);
    }
}