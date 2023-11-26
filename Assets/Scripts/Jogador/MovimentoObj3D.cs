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
    private bool m_airjumping = false;
    private Rigidbody m_rb;
    private Transform m_model;
    private float m_timer = .5f;
    private float m_temptime;

    private const string k_Horizontal = "Horizontal";
    private const string k_Jump = "Jump";

    [Header("Parametros Groundcheck")]
    [SerializeField] private LayerMask m_layerMask;

    private void Start()
    {
        m_temptime = m_timer;
        m_model = GetComponent<Transform>().GetChild(0);
        m_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.IsPaused)
        {
            // raycast do jogador
            bool raycast = Physics.Raycast(transform.position, -transform.up, m_jumpCheck, m_layerMask);
            //função para rotacionar o player
            RotatePlayer();
            //movimentação e pulo
            m_horizontal = Input.GetAxisRaw(k_Horizontal);

            //test de pular
            if (Input.GetButtonDown(k_Jump))
            {
                if (!m_airjumping)
                {
                    m_timer = m_temptime;
                    m_airjumping = true;
                    m_rb.velocity = new Vector3(m_rb.velocity.x, m_jump, 0);
                }
                if (m_rb.velocity.y > 0f)
                {
                    m_rb.velocity = new Vector3(m_rb.velocity.x, m_rb.velocity.y * 0.5f, 0);
                }
            }
            if (m_airjumping)
            {
                //timer de testar para poder pular quando sai de um objeto!
                m_timer -= Time.deltaTime;
                if (m_timer < 0 && raycast)
                {
                    m_airjumping = false;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        //adicionando velocidade para a movimentação do jogador
        m_rb.velocity = new Vector3(m_horizontal * m_velocidade,m_rb.velocity.y, m_rb.velocity.z);
    }

    private void RotatePlayer() 
    {
        //mover o modelo diacordo com a direção!
        if (Input.GetKeyDown(KeyCode.D) && !Input.GetKeyDown(KeyCode.A))
            m_model.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        if (Input.GetKeyDown(KeyCode.A) && !Input.GetKeyDown(KeyCode.D))
            m_model.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
        if(Input.GetKeyDown(KeyCode.RightArrow) && !Input.GetKeyDown(KeyCode.LeftArrow))
            m_model.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !Input.GetKeyDown(KeyCode.RightArrow))
            m_model.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
    }
}
