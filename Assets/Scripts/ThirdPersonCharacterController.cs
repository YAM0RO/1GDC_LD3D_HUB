using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{
    public float speed = 6.0f;
    public float sprintSpeed = 12.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    private AudioSource _audio;
    private Animator _anim;

    [SerializeField]
    private Transform cameraTransform;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        _anim = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            // Move the character forward and backward
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            moveDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * moveDirection;

            // Sprint if left shift is pressed
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveDirection *= sprintSpeed / speed;
                _anim.SetBool("Run", true);
            }

            else
            {
                _anim.SetBool("Run", false);
            }

            // Jump if space is pressed
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
                _anim.SetTrigger("jump");
            }
        }

        // Apply gravity
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the character
        controller.Move(moveDirection * Time.deltaTime);
    }

    private void OnApplicationFocus(bool focus)
    {
        if(focus)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}