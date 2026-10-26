using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveForce = 10f;
    [SerializeField] private float jumpForce = 6f;

    private Rigidbody rigidbodyComponent;
    private Vector3 moveDirection;
    private bool isGrounded;
    private bool jumpRequested;
    private GameController gameController;

    private void Awake()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
        gameController = Object.FindFirstObjectByType<GameController>();
    }

    private void Update()
    {
        float horizontal = 0f;
        float vertical = 0f;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) horizontal = -1f;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) horizontal = 1f;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) vertical = -1f;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) vertical = 1f;

        moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jumpRequested = true;
        }
    }

    private void FixedUpdate()
    {
        rigidbodyComponent.AddForce(moveDirection * moveForce);

        if (jumpRequested)
        {
            rigidbodyComponent.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpRequested = false;
            isGrounded = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                
                if (contact.normal.y > 0.5f)
                {
                    isGrounded = true;
                    break;
                }
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            if (gameController != null)
            {
                gameController.CollectItem();
            }
            Destroy(other.gameObject);
        }
    }
}