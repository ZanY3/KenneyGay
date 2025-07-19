using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField, Tooltip("�������� ������������")] private float speed = 5f;
    [SerializeField, Tooltip("��������� ��� ������ ��������")] private float acceleration = 20f;
    [SerializeField, Tooltip("������ ��� ���������")] private float deceleration = 20f;
    [SerializeField, Tooltip("��������� ��� �������")] private float sprintMultiplier = 1.5f;
    [SerializeField, Tooltip("���� �������")] private KeyCode sprintKey = KeyCode.LeftShift;

    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 currentVelocity;

    private static readonly int IsRunningHash = Animator.StringToHash("isRunning");
    private static readonly int MoveXHash = Animator.StringToHash("moveX");
    private static readonly int MoveYHash = Animator.StringToHash("moveY");

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // ������ ����
        Vector2 input = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        ).normalized;

        // ���������� ������� ��������
        float targetSpeed = speed * (Input.GetKey(sprintKey) ? sprintMultiplier : 1f);
        Vector2 targetVelocity = input * targetSpeed;

        // ������������� �������� ��� ���������
        float accel = (input.magnitude > 0.1f) ? acceleration : deceleration;
        currentVelocity = Vector2.MoveTowards(currentVelocity, targetVelocity, accel * Time.deltaTime);

        // ��������
        bool isRunning = currentVelocity.sqrMagnitude > 0.01f;
        animator.SetBool(IsRunningHash, isRunning);
        if (isRunning)
        {
            animator.SetFloat(MoveXHash, currentVelocity.x);
            animator.SetFloat(MoveYHash, currentVelocity.y);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = currentVelocity;
    }
}
