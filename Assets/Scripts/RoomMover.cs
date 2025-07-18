using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMover : MonoBehaviour
{
    public Vector3 CameraChangePos;
    public Vector3 PlayerChangePos;
    private Animator _transitionAnim;

    private Camera _cam;

    private void Start()
    {
        _transitionAnim = GameObject.FindGameObjectWithTag("RoomTransition").GetComponent<Animator>();
        _cam = Camera.main;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            _transitionAnim.SetTrigger("OnTransition");
            collision.gameObject.transform.position += PlayerChangePos;
            _cam.transform.position += CameraChangePos; //������� � ������ 15 � ������ 8(������ ��� � ������� ���������, ������ ����� � ���� �� ������)
        }
    }
}
