using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private string horizontalInputName = "Horizontal";

    [SerializeField]
    private string verticalInputName = "Vertical";

    [SerializeField]
    private float movementSpeed = 6f;

    [SerializeField]
    private float gravity = 20f;

    [SerializeField]
    private float jumpForce = 8f;

    [SerializeField]
    private KeyCode jumpKey = KeyCode.Space;

    private float verticalVelocity;

    private CharacterController charController;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float horizInput = Input.GetAxis(horizontalInputName) * movementSpeed;
        float vertInput = Input.GetAxis(verticalInputName) * movementSpeed;

        if (charController.isGrounded)
        {
            verticalVelocity = -5;

            if (Input.GetKeyDown(jumpKey))
                verticalVelocity = jumpForce;
        }
        else
            verticalVelocity -= gravity * Time.deltaTime;

        Vector3 jumpMovement = transform.up * verticalVelocity;
        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;
        Vector3 moveVector = forwardMovement + rightMovement + jumpMovement;

        charController.Move(moveVector * Time.deltaTime);
    }
}
