using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

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

    public bool isGrounded;

    PlayerData data;
    public Text pointsText;

    // public LayerMask groundLayer;

    // public float groundCheck = 0.2f;
    private float moveInput;
    private Vector2 vector2Up = new Vector2(0, 1);
    private bool left, right, up, switchPlayer;
    // private int direction = 0;

    public bool thisActive = false;

    void Start()
    {
        EventManager.OnButtonLeftEvent -= ButtonLeft;
        EventManager.OnButtonLeftEvent += ButtonLeft;
        EventManager.OnButtonRightEvent -= ButtonRight;
        EventManager.OnButtonRightEvent += ButtonRight;
        EventManager.OnButtonUpEvent -= ButtonUp;
        EventManager.OnButtonUpEvent += ButtonUp;

        data = GameObject.Find("PlayerData").GetComponent<PlayerData>();
    }

    private void Update()
    {
        if (thisActive)
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
            // }

            if (moveInput > 0)
            {
                playerRenderer.flipX = false;
            }
            else if (moveInput < 0)
            {
                playerRenderer.flipX = true;
            }

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
        }
    }

    void FixedUpdate()
    {
        if (thisActive)
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
    }



    private void ButtonLeft(bool _event)
    {
        left = _event;
        Debug.Log("Button Left" + _event);
    }

    private void ButtonRight(bool _event)
    {
        right = _event;
        Debug.Log("Button Right"+ _event);
    }

    private void ButtonUp(bool _event)
    {
        up = _event;
        Debug.Log("Button Up" + _event);
    }
    private void OnTriggerEnter2D(Collider2D collision) // wanted to make it in seperate script, but that didn't work
    {
        switch (collision.tag) // te varetu ari ielikt lever, pogas, "durvis" utt.
        {
            case "collectable":
                {
                    Destroy(collision.gameObject);
                    data.points++;
                    pointsText.text = data.points.ToString();
                    return;
                }
            default: 
                {
                    return;
                }
            
        }
    }
}
