using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float runSpeed = 3.0f;

    private Rigidbody _charRigidbody;
    private Animator _animator;

    void Start()
    {
        _charRigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");

        bool isRun = Input.GetKey(KeyCode.LeftShift);

        // �̵��ϰ��� �ϴ� ���� ���
        Vector3 inputDir = new Vector3(hAxis, 0, vAxis).normalized;

        _charRigidbody.MovePosition(_charRigidbody.position + inputDir * moveSpeed * Time.deltaTime);

        // �̵��ϴ� �������� ȸ��
        transform.LookAt(transform.position + inputDir);

        if (!isRun)
        {
            _charRigidbody.MovePosition(_charRigidbody.position + inputDir * moveSpeed * Time.deltaTime);
        }
        else
        {
            _charRigidbody.MovePosition(_charRigidbody.position + inputDir * runSpeed * Time.deltaTime);
        }

        _animator.SetBool("isWalking", inputDir != Vector3.zero);
        _animator.SetBool("isRunning", isRun);
    }
}