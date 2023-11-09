using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovimentoObj3D : MonoBehaviour
{
    [Header("valores Pulo e Velocidade")]
    [SerializeField] private float m_jump = 16f;
    [SerializeField] private float m_jumpCheck = 1f;
    [SerializeField] private float m_velocidade = 8f;
    private float m_horizontal;
    private Rigidbody m_rb;

    private const string k_Horizontal = "Horizontal";
    private const string k_Jump = "Jump";

    [Header("Parametros Groundcheck")]
    [SerializeField]
    private LayerMask m_layerMask;

    private void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //movimenta��o e pulo
        m_horizontal = Input.GetAxisRaw(k_Horizontal);

        if (!Input.GetButtonDown(k_Jump))
            return;

        if (Physics.Raycast(transform.position, -transform.up, m_jumpCheck, m_layerMask))
        {
            m_rb.velocity = new Vector3(m_rb.velocity.x, m_jump, 0);
        }

        if (m_rb.velocity.y > 0f)
        {
            m_rb.velocity = new Vector3(m_rb.velocity.x, m_rb.velocity.y * 0.5f, 0);
        }
    }

    private void FixedUpdate()
    {
        //adicionando velocidade para a movimenta��o do jogador
        m_rb.velocity = new Vector3(m_horizontal * m_velocidade,m_rb.velocity.y, m_rb.velocity.z);
    }
}
