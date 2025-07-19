using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 5f;
    public Rigidbody2D rb;
    public Animator animator;

    private float moveHorizontal, moveVertical;

    private void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();
        if (animator == null) animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // ������ ����
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        // ������� ������
        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized;
        rb.velocity = movement * Speed;

        // ������������� ��������
        bool isRunning = rb.velocity.magnitude > 0.1f;
        animator.SetBool("isRunning", isRunning);
    }
}
