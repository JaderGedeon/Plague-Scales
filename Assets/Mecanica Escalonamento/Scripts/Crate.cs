using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour, IScalable
{
    [SerializeField] private float m_scaleSpeed = 1f;
    [SerializeField] private Vector3 m_maxScale = new Vector3(5f, 5f, 1f);
    [SerializeField] private Vector3 m_minScale = new Vector3(0.5f, 0.5f, 1f);

    public Coroutine CoroutineHandler { get; set; }

    private Transform m_transform;

    private void Awake()
    {
        m_transform = transform;
    }

    public void StartScaling(ArtifactType artifactType)
    {
        CoroutineHandler = StartCoroutine(ScalingCoroutine(artifactType));
    }

    public IEnumerator ScalingCoroutine(ArtifactType artifactType)
    {
        Vector3 startScale = m_transform.localScale;
        float timeElapsed = 0f;

        while (true)
        {
            Vector3 scaleValue = artifactType switch
            {
                ArtifactType.Expand => Vector3.Lerp(startScale, m_maxScale, timeElapsed / m_scaleSpeed),
                ArtifactType.Retract => Vector3.Lerp(startScale, m_minScale, timeElapsed / m_scaleSpeed),
                _ => m_transform.localScale,
            };

            timeElapsed += Time.deltaTime;
            m_transform.localScale = scaleValue;
            yield return null;
        }
    }

    public void StopScaling()
    {
        StopCoroutine(CoroutineHandler);
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (Vector3.Dot(contact.normal, Vector3.down) > 0.5f)
            {
                Debug.Log("Teto");

                if (Vector3.Dot(contact.normal, Vector3.up) > 0.5f)
                {
                    Debug.Log("Colisão no eixo Y inteiro");
                }
            }

             //&& Vector3.Dot(contact.normal, Vector3.up) > 0.5f
        }
    }

    void OnTriggerStay(Collision collisionInfo)
    {
        // Debug-draw all contact points and normals
        foreach (ContactPoint contact in collisionInfo.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal * 10, Color.white);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (Vector3.Dot(contact.normal, Vector3.up) > 0.5f)
            {
                // Colisão na parte superior saiu
                Debug.Log("SAIU TETO");
            }
            else if (Vector3.Dot(contact.normal, Vector3.down) > 0.5f)
            {
                // Colisão na parte inferior saiu
                Debug.Log("SAIU CHÃO");
            }
        }
    }
}
