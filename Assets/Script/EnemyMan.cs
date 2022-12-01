using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMan : Enemy
{
   /* [SerializeField] float moveSpeed = 1f;
    Rigidbody2D rb;
   

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       

    }

    // Update is called once per frame
    void Update()
    {
        if(isFancingRight())
        {
            rb.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, 0f);
        }
    }
    private bool isFancingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)), transform.localScale.y);
    }
   */
    protected override void Collision()
    {
        Player_Movement.MyInstance.PlayerHit(damage);
    }
}
