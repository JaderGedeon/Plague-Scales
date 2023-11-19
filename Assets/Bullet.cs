using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float m_speed = 10;

    private Rigidbody m_rb;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (EnemyBullet.Instance.SideBullet)
        {
            m_rb.velocity = -Vector3.right * m_speed;
        }
        else
        {
            m_rb.velocity = Vector3.right * m_speed;
        }

    }
    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision == null)
            return;

        if (collision.gameObject.layer == 6)
            gameObject.SetActive(false);
        
        if (collision.gameObject.CompareTag("Player")) 
        {
            print("morreu");
        }
    }
}
