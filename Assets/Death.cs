using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour
{
    public GameObject deathEffect;
    private Weapon weaponScript;
    private PlayerMovement moveScript;
    private CharacterController2D jumpScript;
    private CircleCollider2D collider1;
    private CircleCollider2D collider2;

    void Start()
    {
        weaponScript = GetComponent<Weapon>();
        moveScript = GetComponent<PlayerMovement>();
        collider1 = GetComponent<CircleCollider2D>();
        collider2 = GetComponent<CircleCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(DieAndRespawn());
        }
    }

    IEnumerator DieAndRespawn()
    {
        GetComponent<Renderer>().enabled = false;
        weaponScript.enabled = false;
        moveScript.runSpeed = 0;
        moveScript.dead = true;
        collider1.enabled = false;
        collider2.enabled = false;

        Instantiate(deathEffect, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2.0f);
        transform.position = new Vector3(-10.42f, -0.64f, 0.0f);
        //transform.rotation = Quaternion.identity;

        GetComponent<Renderer>().enabled = true;
        weaponScript.enabled = true;
        moveScript.runSpeed = 25;
        moveScript.dead = false;
        collider1.enabled = true;
        collider2.enabled = true;
    }
}