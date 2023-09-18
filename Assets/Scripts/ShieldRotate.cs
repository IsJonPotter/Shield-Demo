using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldRotate : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    Rigidbody2D shieldRb;


    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        shieldRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        AimShield();
    }

    void AimShield()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    public void MoveShieldWithPlayer(Vector2 velocity)
    {
        shieldRb.velocity = velocity;
    }

}
