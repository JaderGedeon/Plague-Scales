using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoObj2D : MonoBehaviour
{
    private float horizontal;
    private float jump = 16f;
    private float velocidade = 8f;
    private bool isFacingRight = true;

    public Rigidbody2D rb;
    public Transform chao;
    public LayerMask layerChao;


    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && chaoDetecta())
        {
            rb.velocity = new Vector3(rb.velocity.x, jump);
        }

        if (Input.GetButtonDown("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector3(rb.velocity.x,rb.velocity.y *0.5f);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(horizontal * velocidade,rb.velocity.y);
 
    }

    private bool chaoDetecta() 
    {
        return Physics2D.OverlapCircle(chao.position,0.2f,layerChao);
    }

    private void Flip() 
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f) 
        {
            isFacingRight = !isFacingRight;
            Vector3 scalaLocal = transform.localScale;
            scalaLocal.x *= -1f; 
            transform.localScale = scalaLocal;
        }
    
    }
}
