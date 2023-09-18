using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] float speedUp = 0f;
    [SerializeField] float healthUp = 0f;
    [SerializeField] float sizeDown = 0f;
    [SerializeField] float shieldWidthUp = 0f;
    [SerializeField] float powerUpTime = 3f;
    PlayerController playerController;
    bool wasCollected = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !wasCollected)
        {
            wasCollected = true;
            playerController = other.gameObject.GetComponent<PlayerController>();

            playerController.playerMoveSpeed += speedUp;
            playerController.playerHealth += healthUp;
            playerController.playerSize -= sizeDown;

            gameObject.SetActive(false);

            Invoke(nameof(ResetPowerUps), powerUpTime);
        }
    }   

    void ResetPowerUps()
    {
        playerController.playerMoveSpeed -= speedUp;
        playerController.playerSize += sizeDown;

        Destroy(gameObject);
    }

    
}
