using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float playerMoveSpeed = 5f;
    public float playerSize = 5f;
    public float playerHealth = 5f;
    public float maxHealth = 5f;
    GameObject playerBody;
    GameObject playerShield;
    Rigidbody2D myRigidbody;
    Vector2 moveInput;

    void Start()
    {
        playerBody = GameObject.Find("Sprite");
        playerShield = GameObject.Find("Shield Rotator");
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.localScale = new Vector2(playerSize, playerSize);
        Move();
        FlipSprite();
        MaintainHealth();
    }

    private void MaintainHealth()
    {
        if(playerHealth > maxHealth)
        {
            playerHealth = maxHealth;
        }
    }

    public void Damage()
    {
        playerHealth--;
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            playerBody.transform.localScale = new Vector2(-Mathf.Sign(myRigidbody.velocity.x), 1);
        }
    }

    private void Move()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x*playerMoveSpeed, moveInput.y*playerMoveSpeed);
        myRigidbody.velocity = playerVelocity;
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}
