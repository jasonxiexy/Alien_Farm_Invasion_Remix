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
    public PlayerHealth health;
    private float dirX = 0f;
    bool facingRight = true;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpSpeed = 7f;


    [SerializeField] private LayerMask jumpableGround;

    private enum movementState { idle, walk, jump }

    [SerializeField] private AudioSource jumpSoundEffect;

    [SerializeField] public Transform keyFollowPoint;

    public Key followingKey;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    private void Update()
    {

        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(0, jumpSpeed);
        }
        if (Input.GetKeyDown(KeyCode.J)){
            health.damage();

        }

        UpdateAnimationState();


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
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    