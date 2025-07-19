using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 30f;
    public float damage = 10f;
    public float speed = 2f;

    private Transform target;

    void Start()
    {
        target = FindObjectOfType<PlayerController>().transform;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if (health <= 0) Die();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.GetComponent<PlayerController>() is PlayerController player)
        {
            player.TakeDamage(damage);
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        GameManager.Instance.AddCoin();
    }
}
