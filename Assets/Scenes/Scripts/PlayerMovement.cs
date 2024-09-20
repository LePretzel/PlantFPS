using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{


    [SerializeField]
    private float moveSpeed = 25;

    [SerializeField]
    private float lookSpeed = 10;

    private CharacterController controller;
    private Transform cam;

    private float rotX;
    private float rotY;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        cam = transform.GetChild(0).GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        rotY += Input.GetAxis("Mouse X");
        rotX += -Input.GetAxis("Mouse Y");
        rotX = Mathf.Clamp(rotX, -15f, 15f);

        transform.rotation = Quaternion.Euler(0f, rotY * lookSpeed, 0f);
        cam.localRotation = Quaternion.Euler(rotX * lookSpeed, 0f, 0f);

        var forward = Input.GetAxis("Vertical") * transform.forward;
        var strafe = Input.GetAxis("Horizontal") * transform.right;
        var movement = forward + strafe;
        controller.Move(movement * moveSpeed * Time.deltaTime);
    }
}
