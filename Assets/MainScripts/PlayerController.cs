using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public float crouchSpeed = 2f;
    public float mouseSensitivity = 2f;
    public float crouchHeight = 1f;
    public float climbSpeed = 3f;
    public Transform cameraTransform;
    public float headClearance = 0.5f;
    public float characterHeight = 2f;
    public float gravity = -9.81f;
    private float jumpGravityMultiplier = 1.5f;
    private float fallSpeed = 2f;
    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    private float xRotation = 0f;
    private float yRotation = 0f;
    private float currentSpeed;
    private bool isCrouching = false;
    private bool isClimbing = false;
    public static PlayerController instance;
    //public float climbAngleThreshold = 30f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        currentSpeed = speed;
    }

    void Update()
    {
        isGrounded = controller.isGrounded;
        if (isClimbing)
        {
            HandleClimbing();
        }
        else
        {
            HandleMovement();
            if (isGrounded && Input.GetButtonDown("Jump"))
            {
                Jump();
            }
            ApplyGravity();
        }
        //HandleCameraRotation();
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (isCrouching && !IsOverheadObstructed())
            {
                StandUp();
            }
            else if (!IsOverheadObstructed())
            {
                Crouch();
            }
        }
        controller.Move(move * currentSpeed * Time.deltaTime);
   }

    private void Jump()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f))
        {
            //float surfaceAngle = Vector3.Angle(hit.normal, Vector3.up);
            //if (surfaceAngle <= climbAngleThreshold)
            //{
            velocity.y = jumpForce;
            //}
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

    private void Crouch()
    {
        isCrouching = true;
        currentSpeed = crouchSpeed;
        controller.height = crouchHeight;
    }

    private void StandUp()
    {
        isCrouching = false;
        currentSpeed = speed;
        controller.height = characterHeight;
    }
    private bool IsOverheadObstructed()
    {
        Vector3 rayOrigin = transform.position + Vector3.up * (controller.height);
        RaycastHit hit;
        return Physics.Raycast(rayOrigin, Vector3.up, out hit, headClearance);
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

    /*private void HandleCameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        yRotation += mouseX; cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.rotation = Quaternion.Euler(0f, yRotation, 0f);
    }*/
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Ladder"))
    //    {
    //        isClimbing = true;
    //        velocity = Vector3.zero;
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Ladder"))
    //    {
    //        isClimbing = false;
    //    }
    //}
}