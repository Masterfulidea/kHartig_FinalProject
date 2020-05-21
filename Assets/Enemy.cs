using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 5;

    public GameObject deathEffect;

    public bool notBoss = true;

    private UnityEngine.Object enemyRef;
    private BoxCollider2D collider;

    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);

        if (notBoss)
        {
            GetComponent<Renderer>().enabled = false;
            collider.enabled = false;
            Invoke("Respawn", 5);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Respawn()
    {
        GetComponent<Renderer>().enabled = true;
        collider.enabled = true;
        health = 5;
    }

    private bool dirRight = true;
    public float speed;
    public float path1;
    public float path2;

    void Update()
    {
        if (notBoss)
        {
            if (dirRight)
            {
                transform.Translate(2 * Time.deltaTime * speed, 0, 0);
                transform.localScale = new Vector2(-2, 2);
            }

            else
            {
                transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
                transform.localScale = new Vector2(2, 2);
            }

            if (transform.position.x >= path1)
            {
                dirRight = false;
            }

            if (transform.position.x <= path2)
            {
                dirRight = true;
            }
        }
    }
}