using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 100f;
    [SerializeField] float lifeTime = 5f;
    public GameObject player;
    Rigidbody2D rb;
    float timer;
    [HideInInspector] public bool deflected = false;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player"); 

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * projectileSpeed;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > lifeTime)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (deflected)
        {
            if (col.gameObject.CompareTag("Enemy"))
            {
                EnemyController enemy = col.gameObject.GetComponent<EnemyController>();
                enemy.Damage();
                Destroy(gameObject);
            }
        }
        else
        {
            if (col.gameObject.CompareTag("Player"))
            {
                PlayerController player = col.gameObject.GetComponent<PlayerController>();
                player.Damage();
                Destroy(gameObject);
            }
            else if (col.gameObject.CompareTag("Shield"))
            {
                if (this.gameObject.CompareTag("Reflect"))
                {
                    Vector2 shieldNormal = col.contacts[0].normal;
                    Vector3 reflection = Vector2.Reflect(rb.velocity, shieldNormal).normalized;
                    rb.velocity = reflection * projectileSpeed;
                    deflected = true;
                }
                else if (this.gameObject.CompareTag("Block"))
                {
                    Destroy(gameObject);
                }
            }
        }
        
    }

}
