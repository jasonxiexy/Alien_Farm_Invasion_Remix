using System.Xml.Serialization;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll; 
    private SpriteRenderer sprite;
    private Animator anim;
    private float dirX = 0f;
    bool facingRight = true;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpSpeed = 7f;


    [SerializeField] private LayerMask jumpableGround;

    private enum movementState { idle, walk, jump }

    [SerializeField] private AudioSource jumpSoundEffect;

    [SerializeField] public Transform keyFollowPoint;

    public Key followingKey;
    private float boostTimer = 0;
    private float boostAppearTimer = 0;
    private bool boosting = false;
    private bool doubleJump = false;
    private bool doubleJumping = false;
    private float jumpTimer = 0;
    private float jumpBoostAppearTimer = 0;
    [SerializeField] GameObject speedBoost;
    [SerializeField] GameObject jumpBoost;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        boostNewPosition();
        jumpNewPosition();
    }

    // Update is called once per frame
    private void Update()
    {
        if (boosting)
        {
            boostTimer += Time.deltaTime;
            boostAppearTimer += Time.deltaTime;
            speedBoost.SetActive(false);
            if (boostTimer >= 3)
            {
                moveSpeed = 10f;
                // Debug.Log("3");
                boostTimer = 0;
                // boosting = false;
                // speedBoost.SetActive(true);
            }
            if (boostAppearTimer >= 10)
            {
                // Debug.Log("10");
                boostAppearTimer = 0;
                speedBoost.SetActive(true);
                boosting = false;
            }
        }

        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        if (doubleJumping)
        {
            jumpTimer += Time.deltaTime;
            jumpBoost.SetActive(false);
            if (jumpTimer >= 5)
            {
                doubleJumping = false;
                jumpTimer = 0;
                jumpBoost.SetActive(true);
            }
            handleJumpling();
            UpdateAnimationState();
        }
        else
        {
            if (Input.GetButton("Jump") && IsGrounded())
            {
                jumpSoundEffect.Play();
                rb.velocity = new Vector2(0, jumpSpeed);
            }
            UpdateAnimationState();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SpeedBoost")
        {
            boosting = true;
            moveSpeed = 15f;
            // Destroy(other.gameObject);
            boostNewPosition();
        }
        if (other.tag == "JumpBoost")
        {
            doubleJumping = true;
            // Destroy(other.gameObject);
            jumpNewPosition();
            // jumpBoostAppearTimer+=Time.deltaTime;
            // jumpBoost.SetActive(false);
            // if (jumpBoostAppearTimer >= 11){
            //     Debug.Log("11");
            //     jumpBoostAppearTimer=0;
            //     jumpBoost.SetActive(true);
            // }
        }
    }

    private void UpdateAnimationState()
    {
        movementState state;

        
        if (dirX > 0f)
        {
            
            state = movementState.walk;
            //sprite.flipX = false;
            //sprite.transform.localScale = new Vector3(1, 1, 1);
            if (!facingRight){
                transform.Rotate(0f, 180f, 0f);
                facingRight = true;
            }
            
            
        }
        else if (dirX < 0f)
        {
            state = movementState.walk;
            //sprite.flipX = true;
            //sprite.transform.localScale = new Vector3(-1, 1, 1);
            //transform.Rotate(0f, -180f, 0f);

           if (facingRight){
               
                transform.Rotate(0f, 180f, 0f);
                facingRight = false;
            }
   
            
            
        }
        else
        {
            state = movementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = movementState.jump;
        }
        else if (rb.velocity.y < -.1f)
        {
            //falling
        }

        anim.SetInteger("state", (int)state);
    }



    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
    private void boostNewPosition()
    {
        speedBoost.transform.position = new Vector3(Random.Range(22f, 30f), Random.Range(-4f, -2f), 0f);
    }
    private void jumpNewPosition()
    {
        jumpBoost.transform.position = new Vector3(Random.Range(22f, 30f), Random.Range(-4f, -2f), 0f);
    }
    private void handleJumpling()
    {
        if (IsGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded() || doubleJump)
            {
                jumpSoundEffect.Play();
                rb.velocity = new Vector2(0, jumpSpeed);
                doubleJump = !doubleJump;
            }
        }
        else if (Input.GetButtonDown("Jump") && rb.velocity.y < 0f)
        {
            rb.velocity = new Vector2(0, rb.velocity.y * 1.22f);
            jumpSoundEffect.Play();
        }
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    