using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public static EnemyBullet Instance { get; private set; }
    //True = Left False = Right
    //public bool SideBullet;
    [field: SerializeField] public BulletSide SideBullets { get; private set; }
    [SerializeField] private Transform m_bulletPosition;

    private float m_timer = 3f;
    private float m_temptime;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
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
                bullet.transform.position = m_bulletPosition.position;
                bullet.SetActive(true);
                m_timer = m_temptime;
            }

        }
    }

}
