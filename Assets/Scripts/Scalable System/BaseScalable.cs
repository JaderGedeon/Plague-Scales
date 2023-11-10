using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseScalable : MonoBehaviour
{
    public ArtifactHandler Artifact { get; set; } = new();

    [Range(0.1f, 1f)]
    [SerializeField] protected float m_scaleSpeed = 1f;
    [SerializeField] protected Vector3 m_maxScale = new(5f, 5f, 1f);
    [SerializeField] protected Vector3 m_minScale = new(0.5f, 0.5f, 1f);

    protected readonly List<Collider> m_colliderList = new();

    private void FixedUpdate()
    {
        switch (Artifact.ArtifactType)
        {
            case ArtifactType.None:
                ApplyNoneEffect();
                break;

            case ArtifactType.Expand:
                ApplyExpandEffect();
                break;

            case ArtifactType.Retract:
                ApplyRetractEffect();
                break;
        }
    }

    protected virtual void ApplyNoneEffect() { }

    protected virtual void ApplyExpandEffect() { }

    protected virtual void ApplyRetractEffect() { }

    protected bool IsObjectContained()
    {
        Vector2 minMaxXAxis = Vector2.zero;
        Vector2 minMaxYAxis = Vector2.zero;

        foreach (Collider collider in m_colliderList)
        {
            Vector3 collisionPoint = collider.ClosestPoint(transform.position);
            Vector3 collisionNormal = transform.position - collisionPoint;

            float absX = Mathf.Abs(collisionNormal.x);
            float absY = Mathf.Abs(collisionNormal.y);

            if (absX > absY)
            {
                if (collisionNormal.x < 0)
                    minMaxXAxis.x = collisionNormal.x;
                else
                    minMaxXAxis.y = collisionNormal.x;
            }
            else
            {
                if (collisionNormal.y < 0)
                    minMaxYAxis.x = collisionNormal.y;
                else
                    minMaxYAxis.y = collisionNormal.y;
            }
        }

        bool xCondition = (minMaxXAxis.x != 0) && (minMaxXAxis.y != 0);
        bool yCondition = (minMaxYAxis.x != 0) && (minMaxYAxis.y != 0);

        //Debug.Log($"X: {minMaxXAxis}, Y: {minMaxYAxis}");

        return xCondition || yCondition;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.isTrigger)
            return;

        if (!m_colliderList.Contains(collider))
            m_colliderList.Add(collider);
    }

    void OnTriggerExit(Collider collider)
    {
        if (m_colliderList.Contains(collider))
            m_colliderList.Remove(collider);
    }
}