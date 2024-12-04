using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public float crouchSpeed = 2f;
    public float crouchHeight = 0.5f;
    public float standingHeight = 2f;
    public float mouseSensitivity = 2f;
    public float climbSpeed = 3f;
    public Transform cameraTransform;
    public float headClearance = 0.5f;
    public float characterHeight = 2f;
    public float gravity = -9.81f;
    private float jumpGravityMultiplier = 1.5f;
    public float fallSpeed = 2f;
    public float climbAngleThreshold = 30f;
    public static PlayerController instance;
    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    private float xRotation = 0f;
    private float yRotation = 0f;
    private bool isCrouching = false;
    private bool isClimbing = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        controller.height = standingHeight;
    }

    void Update()
    {
        isGrounded = CheckGround();

        if (isClimbing)
        {
            HandleClimbing();
        }
        else
        {
            HandleMovement();
            HandleJump();
            ApplyGravity();
        }

        HandleCrouch();
        HandleCameraRotation();
    }

    private bool CheckGround()
    {
        return Physics.CheckSphere(transform.position + Vector3.down * (controller.height / 2), 0.1f);
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        if (isCrouching)
        {
            controller.Move(move * crouchSpeed * Time.deltaTime);
        }
        else
        {
            controller.Move(move * speed * Time.deltaTime);
        }
    }

    private void HandleCrouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (isCrouching)
            {
                StandUp();
            }
            else if (!IsOverheadObstructed())
            {
                Crouch();
            }
        }
    }

    private void Crouch()
    {
        isCrouching = true;
        controller.height = crouchHeight;
    }

    private void StandUp()
    {
        isCrouching = false;
        controller.height = standingHeight;
    }

    private void HandleJump()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f))
            {
                float surfaceAngle = Vector3.Angle(hit.normal, Vector3.up);
                if (surfaceAngle <= climbAngleThreshold)
                {
                    velocity.y = jumpForce;
                }
            }
        }
    }

    private void ApplyGravity()
    {
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -fallSpeed;
        }
        else
        {
            float gravityMultiplier = isGrounded ? 1 : jumpGravityMultiplier;
            velocity.y += gravity * gravityMultiplier * Time.deltaTime;
        }
        controller.Move(velocity * Time.deltaTime);
    }

    private void HandleClimbing()
    {
        Vector3 climbMove = new Vector3(0, Input.GetAxis("Vertical") * climbSpeed * Time.deltaTime, 0);
        controller.Move(climbMove);
        if (Input.GetKeyDown(KeyCode.E))
        {
            isClimbing = false;
        }
    }

    private void HandleCameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        yRotation += mouseX;
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.rotation = Quaternion.Euler(0f, yRotation, 0f);
    }

    private bool IsOverheadObstructed()
    {
        Vector3 rayOrigin = transform.position + Vector3.up * (controller.height);
        RaycastHit hit;
        return Physics.Raycast(rayOrigin, Vector3.up, out hit, headClearance);
    }
}