using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 360f;
    public float jumpSpeed = 8f;
    public float gravity = 20f;

    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            // ���ʤ�V�]�w
            float moveDirectionY = moveDirection.y;
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= moveSpeed;

            // ���D
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
            else
            {
                moveDirection.y = moveDirectionY;
            }
        }

        // ���O����
        moveDirection.y -= gravity * Time.deltaTime;

        // ���ʨ���
        controller.Move(moveDirection * Time.deltaTime);
    }

    void FixedUpdate()
    {
        // ������V
        float turn = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        transform.Rotate(0, turn, 0);
    }
    // Start is called before the first frame update

}
