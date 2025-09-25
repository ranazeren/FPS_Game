using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 10f;
    public float gravity = -14.81f;
    public int PlayerHealth = 100;
    private Vector3 gravityVector;

    //GrounCheck
    public Transform groundCheckPoint;
    public float groundCheckRadius = 0.35f;
    public LayerMask groundLayer;

    public bool isGrounded = false;
    public float jumpSpeed = 7f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }


    void Update()
    {
        MovePlayer();
        GroundCheck();
        JumpAngGravity();

    }
    void MovePlayer()
    {
        Vector3 moveVector = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;

        characterController.Move(moveVector * speed * Time.deltaTime);

    }
    void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheckPoint.position, groundCheckRadius, groundLayer);
    }
    void JumpAngGravity()
    {
        gravityVector.y += gravity * Time.deltaTime;

        characterController.Move(gravityVector * Time.deltaTime);



        if (isGrounded && gravityVector.y < 0)
        {
            gravityVector.y = -3f;
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            gravityVector.y = jumpSpeed;
        }

    }
    void PlayerTakeDamage(int DamageAmount)
    {
        PlayerHealth -= DamageAmount;

        if (PlayerHealth <= 0)
        {
            PlayerDeath();
        }
    }
    void PlayerDeath()
    {
        // SceneManager dan sahneyi tekrar yükleyebiliriz
        // veya bir gamemanager yapıp oyunu yeniden başlatma görevini atayabiliriz.
    }
}
