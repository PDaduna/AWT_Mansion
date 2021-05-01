using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    public float movementSpeed = 1;
    public float Gravity = 9.8f;
    public float jumpHeight = 13f;
    private float velocity = 0;
    Camera camera;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        camera = Camera.main;
    }

    void Update()
    {
        Vector3 moveDirection = transform.TransformDirection(Vector3.forward) * movementSpeed;
        // player movement - forward, backward, left, right
        float horizontal = Input.GetAxis("Horizontal") * movementSpeed;
        float vertical = Input.GetAxis("Vertical") * movementSpeed;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float jump = Input.GetAxis("Jump");

        Vector3 moveX = camera.transform.right * moveHorizontal * movementSpeed;
        Vector3 moveZ = transform.forward * moveVertical * movementSpeed;
        Vector3 moveY = Vector3.up * jump * jumpHeight;
        moveDirection = moveX + moveY + moveZ;

        moveDirection.y -= Gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);

        // Gravity
        if (characterController.isGrounded)
        {
            velocity = 0;
        }
        else
        {
            velocity -= Gravity * Time.deltaTime;
            characterController.Move(new Vector3(0, velocity, 0));
        }
    }
}
