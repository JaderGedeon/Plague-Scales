using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneyMove : MonoBehaviour
{
    //variaveis vizivies 
    [SerializeField] private Transform[] m_movePoints;
    [SerializeField] private int m_indexTarget;
    [SerializeField] private float m_speed;
    [SerializeField] private float m_jump;
    [SerializeField] private LayerMask m_enemyLayer;

    //variaveis privatas
    private Rigidbody m_Rb;
    private Transform m_wallCheck;

    void Start()
    {
        //procurar pelos objetos na cena
        m_wallCheck = GetComponentInChildren<Transform>().GetChild(0);
        m_Rb = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        //para mover de ponto A a ponto B e rotanionar o jogador
        if (transform.position == m_movePoints[m_indexTarget].position)
        {
            transform.rotation = Quaternion.Euler(0,180,0);
            IncreaseTargetInt();
        }
        //mover o inimigo!
        transform.position = Vector3.MoveTowards(transform.position, m_movePoints[m_indexTarget].position,m_speed * Time.deltaTime);

        //poder pular quando encontrar uma parede
        if (Physics.Raycast(m_wallCheck.position, -m_wallCheck.right, 1f, m_enemyLayer))
        {
            m_Rb.velocity = new Vector3(0,m_jump,0);
        }
    }

    //incrementar a array de pontos para ir por proximo ponto
    private void IncreaseTargetInt() 
    {
        m_indexTarget++;
        if (m_indexTarget >= m_movePoints.Length)
        {
            m_indexTarget = 0;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.DestroyAndLoadLevel();
        }
    }

}
