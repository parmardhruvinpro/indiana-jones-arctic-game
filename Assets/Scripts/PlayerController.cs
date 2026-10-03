using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 7f;
    public float jumpForce = 8f;
    public float rotationSpeed = 10f;
    public bool isGrounded;

    private Rigidbody rb;
    private Transform mainCamera;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    private void Start()
    {
        mainCamera = Camera.main != null ? Camera.main.transform : null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 input = new Vector3(horizontal, 0f, vertical);
        if (input.sqrMagnitude > 1f)
        {
            input.Normalize();
        }

        if (mainCamera == null)
        {
            rb.velocity = new Vector3(input.x * moveSpeed, rb.velocity.y, input.z * moveSpeed);
            return;
        }

        Vector3 cameraForward = Vector3.Scale(mainCamera.forward, new Vector3(1f, 0f, 1f)).normalized;
        Vector3 cameraRight = Vector3.Scale(mainCamera.right, new Vector3(1f, 0f, 1f)).normalized;

        Vector3 moveDirection = cameraForward * input.z + cameraRight * input.x;

        if (moveDirection.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
            rb.velocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.z * moveSpeed);
        }
        else
        {
            rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
