using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    static readonly int anim_speed = Animator.StringToHash("speed");
    static readonly int anim_isFalling = Animator.StringToHash("isFalling");
    static readonly int anim_isJumping = Animator.StringToHash("isJumping");

    Vector2 vector2Up = new Vector3(0, 1, 0);

    public Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    public float moveInput;

    public bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    public Animator animator;

    public bool left, right, up, switchPlayer;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.OnButtonLeftEvent += ButtonLeft;
        EventManager.OnButtonRightEvent += ButtonRight;
        EventManager.OnButtonUpEvent += ButtonUp;
        EventManager.OnButtonSwitchEvent += ButtonSwitch;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        animator.SetFloat(anim_speed, Mathf.Abs(moveInput));

        #region FOR MOBILE     

        if (right)
        {
            moveInput = 1;
        }
        else if (left)
        {
            moveInput = -1;
        }
        
        #endregion

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    private void Update()
    {

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (isGrounded == true && Input.GetKeyDown(KeyCode.W))
        {
            isJumping = true;
            animator.SetBool(anim_isJumping, true);
            jumpTimeCounter = jumpTime;
            rb.velocity = vector2Up * jumpForce;
        }

        if (Input.GetKey(KeyCode.W) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = vector2Up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
                animator.SetBool(anim_isJumping, true);
            }
            else
            {
                isJumping = false;
                animator.SetBool(anim_isJumping, false);
                animator.SetBool(anim_isFalling, true);
            }

            rb.velocity = vector2Up * jumpForce;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            isJumping = false;
            animator.SetBool(anim_isJumping, false);
            animator.SetBool(anim_isFalling, true);
        }

        if (isGrounded == true)
        {
            animator.SetBool(anim_isFalling, false);
            animator.SetBool(anim_isJumping, false);
            animator.SetFloat(anim_speed, Mathf.Abs(moveInput));
        }
    }

    private void ButtonLeft(bool _event)
    {
        left = _event;
        Debug.Log("Button Left");
    }

    private void ButtonRight(bool _event)
    {
        right = _event;
        Debug.Log("Button Right");
    }

    private void ButtonUp(bool _event)
    {
        up = _event;
        Debug.Log("Button Up");
    }

    private void ButtonSwitch(bool _event)
    {
        switchPlayer = _event;
        Debug.Log("Button Switch");
    }
}
