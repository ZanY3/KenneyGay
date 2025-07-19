using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float health;
    public float damage;

    private Rigidbody2D rb;
    private Vector2 input;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void ApplyStats(PlayerStats stats)
    {
        health = stats.GetMaxHealth();
        moveSpeed = stats.GetSpeed();
        damage = stats.GetDamage();
    }

    void Update()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        if (Input.GetButtonDown("Fire1")) Attack();
    }

    void FixedUpdate()
    {
        rb.velocity = input * moveSpeed;
    }

    void Attack()
    {
        // ѕроста€ атака: луч в направлении курсора
        Vector3 worldMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = (worldMouse - transform.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 1.5f, LayerMask.GetMask("Enemy"));
        if (hit.collider != null)
        {
            hit.collider.GetComponent<Enemy>().TakeDamage(damage);
        }
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        UIManager.Instance.UpdateHealth(health);
        if (health <= 0) Die();
    }

    void Die()
    {
        GameManager.Instance.EndRun(false);
    }
}
