using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public bool exitStay = false;

    public VARS.GENDER gender = VARS.GENDER.MALE;

    // Chache from insperctor EVERYTHING!
    [Header("References")]
    public SpriteRenderer playerRenderer;
    public Rigidbody2D playerRrigidbody;
    public Animator playerAnimator;
    public Transform groundCollider;

    [Header("Adjustables")]
    public float speed;
    public float jumpForce;

    [Header("Globals")]
    public bool isGrounded = false;
    public bool thisActive = false;
    
    private float moveInput;
    private Vector2 vector2Up = new Vector2(0, 1);
    private bool left, right, up, switchPlayer;
    

    void Start()
    {
        EventManager.OnButtonLeftEvent -= ButtonLeft;
        EventManager.OnButtonLeftEvent += ButtonLeft;
        EventManager.OnButtonRightEvent -= ButtonRight;
        EventManager.OnButtonRightEvent += ButtonRight;
        EventManager.OnButtonUpEvent -= ButtonUp;
        EventManager.OnButtonUpEvent += ButtonUp;
    }

    private void Update()
    {
        if (thisActive)
        {
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
                playerAnimator.SetBool(VARS.anim_isFalling, false);
                playerAnimator.SetBool(VARS.anim_isJumping, false);
                playerAnimator.SetFloat(VARS.anim_speed, Mathf.Abs(moveInput));

                if (isGrounded && (Input.GetKeyDown(KeyCode.W) || up))
                {
                    isGrounded = false;
                    playerAnimator.SetBool(VARS.anim_isJumping, true);
                    playerRrigidbody.velocity = vector2Up * jumpForce;
                }
            }

            if (playerRrigidbody.velocity.y < 0)
            {
                playerAnimator.SetBool(VARS.anim_isJumping, false);
                playerAnimator.SetBool(VARS.anim_isFalling, true);
            }
        }
    }

    void FixedUpdate()
    {
        if (thisActive)
        {
#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_WEBGL
            moveInput = Input.GetAxisRaw("Horizontal");
#endif
#if UNITY_IOS || UNITY_ANDROID
            if (right)
                moveInput = 1;
            else if (left)
                moveInput = -1;
#endif
            playerRrigidbody.velocity = new Vector2(moveInput * speed, playerRrigidbody.velocity.y);
            playerAnimator.SetFloat(VARS.anim_speed, Mathf.Abs(moveInput));
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
        Debug.Log("Button Right" + _event);
    }

    private void ButtonUp(bool _event)
    {
        up = _event;
        Debug.Log("Button Up" + _event);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "collectable":
                {
                    Destroy(collision.gameObject);
                    VARS.points++;
                    break;
                }
            case "Exit":
                {
                    break;
                }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Exit - Male":
                {
                    if (exitStay)
                    {
                        exitStay = false;
                        if (this.gender == VARS.GENDER.MALE)
                        {
                            VARS.doneCount -= 1;
                        }
                    }
                    break;
                }
            case "Exit - Female":
                {
                    if (exitStay)
                    {
                        exitStay = false;
                        if (this.gender == VARS.GENDER.FEMALE)
                        {
                            VARS.doneCount -= 1;
                        }
                    }
                    break;
                }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Exit - Male":
                {
                    if (!exitStay)
                    {
                        exitStay = true;
                        if (this.gender == VARS.GENDER.MALE)
                        {
                            VARS.doneCount += 1;
                        }
                    }
                    break;
                }
            case "Exit - Female":
                {
                    if (!exitStay)
                    {
                        exitStay = true;
                        if (this.gender == VARS.GENDER.FEMALE)
                        {
                            VARS.doneCount += 1;
                        }
                    }
                    break;
                }
        }
    }
}
