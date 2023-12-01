using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    [field: SerializeField] public BulletSide SideBullets { get; private set; }

    private float m_timer = 3f;
    private float m_temptime;
    private Transform m_Right;
    private Transform m_Left;
    private Transform m_model;
    // Start is called before the first frame update
    void Start()
    {
        m_Left = GetComponentInChildren<Transform>().GetChild(0);
        m_Right = GetComponentInChildren<Transform>().GetChild(1);
        m_model = GetComponentInChildren<Transform>().GetChild(2);
        m_temptime = m_timer;

    }

    // Update is called once per frame
    void Update()
    {
        m_timer -= Time.deltaTime;
        if (m_timer < 0)
        {
            GameObject bullet = ObjectPool.Instance.GetPooledObject();

            if (bullet != null)
            {
                switch (SideBullets)
                {
                    case BulletSide.Left:
                        bullet.transform.position = m_Left.position;
                        m_model.rotation = Quaternion.Euler(0, 180, 0);
                        break;
                    case BulletSide.Right:
                        bullet.transform.position = m_Right.position;
                        m_model.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                    default:
                        break;
                }
                
                bullet.SetActive(true);
                m_timer = m_temptime;
            }

        }
    }

}
