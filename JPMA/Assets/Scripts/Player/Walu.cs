using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walu : MonoBehaviour
{
    public Transform bottom;
    public LayerMask ground;

    bool crouchedDown;
    bool inGround;
    bool run;
    bool turbo;
    float jump = 3000f;
    float radioBottom = 0.05f;
    float speed = 4f;
    float movement = 0;
    float drop;
    Rigidbody2D rb;
    Animator animator;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (GameManager.inGame)
        {
            if (!crouchedDown)
            {
                movement = Input.GetAxisRaw("Horizontal") * speed;
                animator.SetInteger("VelX", Mathf.RoundToInt(movement));

                if (movement < 0)
                    transform.localScale = new Vector3(-1, 1, 1);
                else if (movement > 0)
                    transform.localScale = new Vector3(1, 1, 1);

                rb.MovePosition(rb.position + Vector2.right * movement * Time.fixedDeltaTime);
            }

            inGround = Physics2D.OverlapCircle(bottom.position, radioBottom, ground);
            if (inGround)
            {
                animator.SetBool("InGround", true);
                if (Input.GetKeyDown(KeyCode.Space) && !crouchedDown)
                {
                    rb.AddForce(new Vector2(0, jump));
                    animator.SetBool("InGround", false);
                }
            }
            else
                animator.SetBool("InGround", false);

            if (inGround && Input.GetKey(KeyCode.DownArrow))
            {
                animator.SetBool("CrouchedDown", true);
                crouchedDown = true;
            }
            else
            {
                animator.SetBool("CrouchedDown", false);
                crouchedDown = false;
            }

            drop = rb.velocity.y;
            if (drop != 0 || drop == 0)
                animator.SetFloat("VelY", drop);
        }
    }
}
