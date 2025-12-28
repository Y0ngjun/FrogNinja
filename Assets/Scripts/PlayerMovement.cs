using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CapsuleCollider2D standingCollider;
    public CapsuleCollider2D slidingCollider;
    public float moveSpeed;
    public float jumpSpeed;
    public int maxJumpCount;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    private int jumpCount;
    private bool isSlide;
    private bool isFall;
    private bool isRun;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        jumpCount = 0;
        isSlide = false;
        isFall = false;
        isRun = false;
    }

    void Update()
    {
        if (GameManager.Instance.IsGameOver)
        {
            return;
        }

        Move();
    }

    private void Move()
    {
        float currentSpeed = moveSpeed;

        if (isSlide || isFall)
        {
            currentSpeed *= 1.5f;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            sr.flipX = false;
            rb.velocityX = currentSpeed;
            anim.SetBool("isRun", true);
            isRun = true;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            sr.flipX = true;
            rb.velocityX = -currentSpeed;
            anim.SetBool("isRun", true);
            isRun = true;
        }
        else
        {
            isSlide = false;
            rb.velocityX = 0;
            anim.SetBool("isRun", false);
            standingCollider.enabled = true;
            slidingCollider.enabled = false;
            isRun = false;
        }

        if (rb.velocityY == 0)
        {
            jumpCount = 0;
            isFall = false;
            anim.SetBool("isIdle", true);

            if (Input.GetKeyDown(KeyCode.DownArrow) && !isSlide && isRun)
            {
                isSlide = true;
                anim.SetTrigger("isSlide");
                slidingCollider.enabled = true;
                standingCollider.enabled = false;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) && !isFall)
            {
                isFall = true;
                anim.SetTrigger("isFall");
                rb.velocityY = -jumpSpeed * 1.5f;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumpCount && !isFall)
        {
            jumpCount++;
            isSlide = false;
            slidingCollider.enabled = false;
            standingCollider.enabled = true;

            if (jumpCount == 1)
            {
                rb.velocityY = jumpSpeed;
                anim.SetTrigger("isJump");
            }
            else
            {
                rb.velocityY = jumpSpeed * 1.5f;
                anim.SetTrigger("isDoubleJump");
            }

            anim.SetBool("isIdle", false);
        }
    }

    public void Tram()
    {
        jumpCount = 1;
        isSlide = false;
        isFall = false;
        rb.velocityY = jumpSpeed * 2f;
        anim.SetTrigger("isJump");
        anim.SetBool("isIdle", false);
        slidingCollider.enabled = false;
        standingCollider.enabled = true;
    }
}