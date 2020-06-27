using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    // TODO: (Cleanup) Add to hash set class
    static readonly int anim_speed = Animator.StringToHash("speed");
    static readonly int anim_isFalling = Animator.StringToHash("isFalling");
    static readonly int anim_isJumping = Animator.StringToHash("isJumping");


    // Chache from insperctor EVERYTHING!
    public SpriteRenderer playerRenderer;
    public Rigidbody2D playerRrigidbody;
    public Animator playerAnimator;
    public Transform groundCollider;

    public float speed;
    public float jumpForce;

    [SerializeField]
    private bool isGrounded;

    public LayerMask groundLayer;

    public float groundCheck = 0.2f;
    private float moveInput;
    private Vector2 vector2Up = new Vector2(0, 1);
    private bool left, right, up, switchPlayer;
    private int direction = 0;

    // public Animator leverAnimator; // ??????
    // private float jumpTimeCounter;
    // public float jumpTime;
    // private bool isJumping;
    // public bool isLeverPressed;

    void Start()
    {
        EventManager.OnButtonLeftEvent += ButtonLeft;
        EventManager.OnButtonRightEvent += ButtonRight;
        EventManager.OnButtonUpEvent += ButtonUp;
        EventManager.OnButtonSwitchEvent += ButtonSwitch;
    }

    void FixedUpdate()
    {
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        moveInput = Input.GetAxisRaw("Horizontal");
#endif
#if UNITY_IOS || UNITY_ANDROID
        if (right)
            moveInput = 1;
        else if (left)
            moveInput = -1;
#endif
        playerRrigidbody.velocity = new Vector2(moveInput * speed, playerRrigidbody.velocity.y);
        playerAnimator.SetFloat(anim_speed, Mathf.Abs(moveInput));
    }

    private void Update()
    {
        // RaycastHit2D hit = Physics2D.Raycast(groundCollider.position, -vector2Up, groundCheck, groundLayer);
        // Debug.DrawRay(transform.position, -vector2Up * groundCheck, Color.red);
        // Debug.DrawRay(groundCollider.position, -vector2Up * groundCheck * 10, Color.red);

        // if (hit)
        // {

        //     GridLayout grid = hit.collider.gameObject.GetComponent<Tilemap>().layoutGrid;
        //     Vector3Int cellPosition = grid.WorldToCell(transform.position);
        //     Vector3Int position = new Vector3Int(
        //         Mathf.RoundToInt(transform.position.x),
        //         Mathf.RoundToInt(transform.position.y),
        //         Mathf.RoundToInt(transform.position.z));
        //     Tile tile = hit.collider.gameObject.GetComponent<Tilemap>().GetTile<Tile>(position);

        //     Debug.Log(cellPosition);
        //     // Debug.Log(hit.collider);


        //     Debug.Log("Tile :" + tile.name);


        //     // isGrounded = true;
        // }

        if (moveInput > 0)
        {
            playerRenderer.flipX = false;
        }
        else if (moveInput < 0)
        {
            playerRenderer.flipX = true;
        }

        // isGrounded = Physics2D.OverlapArea(groundCollider.position, checkRadius, groundLayer);

        if (isGrounded)
        {
            playerAnimator.SetBool(anim_isFalling, false);
            playerAnimator.SetBool(anim_isJumping, false);
            playerAnimator.SetFloat(anim_speed, Mathf.Abs(moveInput));

            if (isGrounded && (Input.GetKeyDown(KeyCode.W) || up))
            {
                isGrounded = false;
                playerAnimator.SetBool(anim_isJumping, true);
                playerRrigidbody.velocity = vector2Up * jumpForce;
            }
        }

        if (playerRrigidbody.velocity.y < 0)
        {
            playerAnimator.SetBool(anim_isJumping, false);
            playerAnimator.SetBool(anim_isFalling, true);
        }


        // if (moveInput > 0)
        // {
        //     transform.eulerAngles = new Vector3(0, 0, 0);
        // }
        // else if (moveInput < 0)
        // {
        //     transform.eulerAngles = new Vector3(0, 180, 0);
        // }

        // if (isGrounded && Input.GetKeyDown(KeyCode.W))
        // {
        //     isJumping = true;
        //     playerAnimator.SetBool(anim_isJumping, true);
        //     jumpTimeCounter = jumpTime;
        //     playerRrigidbody.velocity = vector2Up * jumpForce;
        // }

        // if (Input.GetKey(KeyCode.W) && isJumping == true)
        // {
        //     if (jumpTimeCounter > 0)
        //     {
        //         rb.velocity = vector2Up * jumpForce;
        //         jumpTimeCounter -= Time.deltaTime;
        //         animator.SetBool(anim_isJumping, true);
        //     }
        //     else
        //     {
        //         isJumping = false;
        //         animator.SetBool(anim_isJumping, false);
        //         animator.SetBool(anim_isFalling, true);
        //     }
        //     rb.velocity = vector2Up * jumpForce;
        // }

        // if (Input.GetKeyUp(KeyCode.W))
        // {
        //     isJumping = false;
        //     animator.SetBool(anim_isJumping, false);
        //     animator.SetBool(anim_isFalling, true);
        // }

        // if (isGrounded == true)
        // {
        //     animator.SetBool(anim_isFalling, false);
        //     animator.SetBool(anim_isJumping, false);
        //     animator.SetFloat(anim_speed, Mathf.Abs(moveInput));
        // }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
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
