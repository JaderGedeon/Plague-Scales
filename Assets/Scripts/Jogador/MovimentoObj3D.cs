using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class MovimentoObj3D : MonoBehaviour
{
    [Header("valores Pulo e Velocidade")]
    [SerializeField]private float jump = 16f;
    [SerializeField]private float jumpCheck;
    [SerializeField]private float velocidade = 8f;
    [SerializeField]private bool grounded = false;
    private float horizontal;

    [Header("Parametros Groundcheck e rb")]
    public Rigidbody rb;
    public Transform chao;
    public LayerMask layerMask;


    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jump, 0);
        }

        if (Input.GetButtonDown("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y * 0.5f, 0);
        }
        print(grounded);


        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, jumpCheck, layerMask))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(horizontal * velocidade,rb.velocity.y, rb.velocity.z);
    }

}
