using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private int m_amountPoll = 10;
    [SerializeField] private GameObject m_bullet;

    private List<GameObject> m_pool = new List<GameObject>();

    public static ObjectPool Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < m_amountPoll; i++)
        {
            GameObject obj = Instantiate(m_bullet); 
            obj.SetActive(false);
            m_pool.Add(obj);
        }    
    }
    
    public GameObject GetPooledObject() 
    {
        for (int i = 0; i < m_pool.Count; i++)
        {
            if (!m_pool[i].activeInHierarchy)
                return m_pool[i];
        }
        return null;
    }
}
