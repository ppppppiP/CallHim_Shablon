using UnityEngine;
using UniversalMobileController;
using YG;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public float crouchSpeed = 2f;
    public float mouseSensitivity = 2f;
    public float crouchHeight = 1f;
    public float climbSpeed = 3f;
    public Transform cameraTransform;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    private float xRotation = 0f;
    private float yRotation = 0f;
    private float currentSpeed;
    private bool isCrouching = false;
    private bool isClimbing = false;
    public float Charectereight = 2f;
    float horizontal, vertical;
    [SerializeField] FloatingJoyStick joyStick;

    public static PlayerController instance;
    void Start()
    {
        instance = this;
        controller = GetComponent<CharacterController>();
        if (YandexGame.EnvironmentData.isDesktop)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        currentSpeed = speed;
    }

    void Update()
    {
        if (isClimbing)
        {
            HandleClimbing();
        }
        else
        {
            if (YandexGame.EnvironmentData.isDesktop)
            {
                horizontal = Input.GetAxis("Horizontal");
                vertical = Input.GetAxis("Vertical");
            }
            else
            {
                horizontal = joyStick.GetHorizontalValue();
                vertical = joyStick.GetVerticalValue();
            }


            Vector3 move = (transform.forward * vertical + transform.right * horizontal) * currentSpeed;

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                isCrouching = !isCrouching;
                currentSpeed = isCrouching ? crouchSpeed : speed;
                controller.height = isCrouching ? crouchHeight : Charectereight;
            }

            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }

            velocity.y += Physics.gravity.y * Time.deltaTime;
            controller.Move(move * Time.deltaTime + velocity * Time.deltaTime);
            isGrounded = controller.isGrounded;
        }

        // HandleCameraRotation();
    }

    public void Jump()
    {
        if (isGrounded)
        {
            velocity.y = jumpForce;
        }
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

    //private void HandleCameraRotation()
    //{
    //    float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
    //    float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

    //    xRotation -= mouseY;
    //    xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    //    yRotation += mouseX;

    //    cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    //    transform.rotation = Quaternion.Euler(0f, yRotation, 0f);
    //}

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