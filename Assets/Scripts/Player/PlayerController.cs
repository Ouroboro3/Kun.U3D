using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject camera;
    private Rigidbody rb;

    private float mouseX, mouseY, xRotation, yRotation;
    public float mouseSensitivity;
    private float inputH, inputV;
    public float moveSpeed;
    public float jumpVelocity;
    public bool isAir;
    public Vector3 groundCheckCenter;
    public Vector3 groundCheckSize;
    public LayerMask groundLayer;
    private Collider[] groundCollider;

    private void Awake()
    {
        camera = transform.GetChild(0).gameObject;
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        transform.localRotation = Quaternion.identity;
        camera.transform.localRotation = Quaternion.identity;
    }

    private void Update()
    {
        //视角移动
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation += mouseY;
        xRotation = Mathf.Clamp(xRotation, -45, 90);
        yRotation += mouseX;

        transform.localRotation = Quaternion.Euler(0, yRotation, 0);
        camera.transform.localRotation = Quaternion.Euler(-xRotation, 0, 0);

        //玩家移动
        inputH = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        inputV = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(new Vector3(inputH, 0, inputV), relativeTo: Space.Self);

        //玩家跳跃
        groundCollider = Physics.OverlapBox(transform.position + groundCheckCenter, groundCheckSize, Quaternion.identity, groundLayer);
        isAir = groundCollider.Length > 0 ? false : true;
        if (Input.GetKeyDown(KeyCode.Space) && !isAir)
        {
            rb.velocity = new Vector3(rb.velocity.x,jumpVelocity,rb.velocity.z);
        }
        
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(transform.position + groundCheckCenter, groundCheckSize);
    }
}
