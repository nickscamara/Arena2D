using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{

    public float speed;
    public float jump;
    public GameObject rayOrigin;
    public float rayCheckDistance;
    Rigidbody2D rb;
    private bool facingRight = true;




    private bool isGrounded;
    public Transform gcheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;
    public ParticleSystem ps;


    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        if (Input.GetKeyDown("space"))
        {
            rb.velocity = Vector2.up * jump;
        }
    }

    void Update()
    {
        if (isGrounded && extraJumps < 2)
        {
            ps.Play();
        }
        if (isGrounded)
        {
            extraJumps = 2;
        }
        if (Input.GetKeyDown("space") && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jump;
            extraJumps--;
        }
        else if (Input.GetKeyDown("space") && extraJumps == 0 && isGrounded)
        {
            rb.velocity = Vector2.up * jump;
            
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(gcheck.position, checkRadius, whatIsGround);
        float x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(x * speed, rb.velocity.y);

        if (facingRight == false && x > 0)
        {
            Flip();
        }
        else if (facingRight == true && x < 0)
        {
            Flip();
        }

       
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

    }
}