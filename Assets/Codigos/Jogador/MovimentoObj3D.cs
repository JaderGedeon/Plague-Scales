using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoObj3D : MonoBehaviour
{
    [Header("valores Pulo e Velocidade")]
    [SerializeField]private float jump = 16f;
    [SerializeField]private float velocidade = 8f;
    private float horizontal;

    [Header("Parametros Groundcheck e rb")]
    public Rigidbody rb;
    public Transform chao;
    public LayerMask layerChao;


    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && !isGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jump,0);
        }

        if (Input.GetButtonDown("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector3(rb.velocity.x,rb.velocity.y *0.5f,0);
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(horizontal * velocidade,rb.velocity.y, rb.velocity.z);
        //estaNoChao = !estaNoChao;
    }

    private bool isGrounded() 
    {
        RaycastHit hit;
        return Physics.Raycast(chao.position, transform.TransformDirection(Vector3.down),out hit, layerChao);
    }
}
