using UnityEngine;

public class Player : MonoBehaviour
{
    public bool enSuelo;
    public Transform pie;
    public LayerMask suelo;
    public float fuerzaSalto = 100f;
    public float radioPie;

    float speed = 4f;
    float movement = 0;
  
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer sr;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {

    }

    void Update()
    {
       
    }

    void FixedUpdate()
    {
        movement = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetInteger("VelX", Mathf.RoundToInt(movement));

        if (movement < 0)
            sr.flipX = true;
        else if(movement > 0)
            sr.flipX = false;

        rb.MovePosition(rb.position + Vector2.right * movement * Time.fixedDeltaTime);
      
        enSuelo = Physics2D.OverlapCircle(pie.position, radioPie, suelo);
        if (enSuelo)
        {
            animator.SetBool("Jump", false);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector2(0, fuerzaSalto));
                animator.SetBool("Jump", true);
            }
        }
        else
            animator.SetBool("Jump", false);    
    }
}
