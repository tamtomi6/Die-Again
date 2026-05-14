using UnityEngine;
using UnityEngine.SceneManagement;
public class move_char : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;

    public float jumpForce = 7f;

    // Gravity modifiers
    public float fallMultiplier = 3.5f;
    public float lowJumpMultiplier = 2f;
    public float deadY = 52f;

    public float loseDelay = 4f;
    private Rigidbody rb;
    private Animator anim;
    private bool isDead;
    private bool isGrounded;
    private bool isTrapped;


    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        if (isDead) return;

        if (transform.position.y < deadY)
        {
            Die();
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveX, 0, moveZ).normalized;

        // Move
        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);

        // Animation Run
        bool isMoving = move != Vector3.zero;
        anim.SetBool("IsRun", isMoving);

        // Rotate toward movement direction
        if (move != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || isTrapped))
        {
            anim.SetTrigger("Jump");

            if (SoundManager.instance != null)
            {
            SoundManager.instance.PlayJump();
            }

            rb.linearVelocity = new Vector3(
                rb.linearVelocity.x,
                jumpForce,
                rb.linearVelocity.z
            );
        }

        // Better jump physics

        // Falling faster
    /*
        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector3.up *
                Physics.gravity.y *
                (fallMultiplier - 1) *
                Time.deltaTime;
        }
    */

         rb.linearVelocity += Vector3.up *
                Physics.gravity.y *
                (fallMultiplier - 1) *
                Time.deltaTime;

    

        // Short hop when releasing jump

    /*
       else if (rb.linearVelocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.linearVelocity += Vector3.up *
                Physics.gravity.y *
                (lowJumpMultiplier - 1) *
                Time.deltaTime;
        }
    */

    }

    void Die()
    {
    if (isDead) return;

        isDead = true;

        anim.SetTrigger("IsDead");

            if (SoundManager.instance != null)
            {
                SoundManager.instance.PlayDead();
            }

        GameManager.currentLevel = SceneManager.GetActiveScene().name;

        GameManager.IQ -= 1;

        Invoke("LoadLoseScene", loseDelay);
    }

    void LoadLoseScene()
    {   
        if (SoundManager.instance != null)
                {
                    SoundManager.instance.PlayLose();
                }

        SceneManager.LoadScene("Lose");
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Trap"))
        {
            isTrapped = true;
            // Handle trap collision (e.g., reduce health, reset position, etc.)
             Debug.Log("Hit a trap!");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }

        if (collision.gameObject.CompareTag("Trap"))
        {
            isTrapped = false;
        }


    }
}