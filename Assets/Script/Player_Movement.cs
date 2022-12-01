using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private float dirX = 0f;
    private Vector3 respawnPoint;
    private float hp = 3;

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float Jump = 14f;
    [SerializeField] private LayerMask jumpableGround;

    private enum MovementState { idle, Jump, Run, Fall }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(this);
        }
    }
    private static Player_Movement instance;

    public static Player_Movement MyInstance
    {
        get
        {
            if (instance == null)
                instance = new Player_Movement();
            return instance;

        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed ,rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, Jump);
        }

        UpdateAnimation();


    }
    private void UpdateAnimation()
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.Run;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.Run;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }
        if (rb.velocity.y > 1f)
        {
            state = MovementState.Jump;
        }
        if (rb.velocity.y < -1f)
        {
            state = MovementState.Fall;
        }
        anim.SetInteger("state", (int)state);
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "FallDitective")
        {
            transform.position = respawnPoint;
        }
        else if(collision.tag == "Checkpoint")
        {
            respawnPoint = transform.position;
        }
    }
    public void PlayerHit(float _damage)
    {
        hp -= _damage;
        Debug.Log("Hp: " + hp);

        if(hp <= 0)
        {
            SceneManager.LoadScene("Level1");
        }
    }
}
