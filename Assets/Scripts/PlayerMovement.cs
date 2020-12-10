using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float moveSpeed;
    public float jumpForce;

    public Rigidbody2D rb;

    public Transform GroundedCheckLeft;
    public Transform GroundedCheckRight;
    public Animator animator;
    public SpriteRenderer spriteRenderer;


    private bool isJumping;
    private bool isGrounded;
    private Vector3 velocity = Vector3.zero;

    
    void FixedUpdate()

    {
        isGrounded = Physics2D.OverlapArea(GroundedCheckLeft.position, GroundedCheckRight.position); /// A l'aide de deux collisions box aux pieds, on vérifie si elles sont au contact du sol ou non, donc si le perso saute ou non
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }

        MovePlayer(horizontalMovement);

        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x); /// La vitesse étant négative quand on va vers la gauche sur x, on prend la valeur absolue pour que l'animator comprenne
        animator.SetFloat("Speed", characterVelocity);
    }

    void MovePlayer(float _horizontalMovement)
    {
    	Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
    	rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if(isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if(_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }
}
