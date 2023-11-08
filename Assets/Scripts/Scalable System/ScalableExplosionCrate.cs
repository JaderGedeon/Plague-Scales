using UnityEngine;

public class ScalableExplosionCrate : BaseScalable
{
    [SerializeField] private Vector3 m_minScaleToExplode = new(0.6f, 0.6f, 1f);

    protected override void ApplyExpandEffect()
    {
        if (IsObjectContained())
            Destroy(gameObject);

        transform.localScale = Vector3.Lerp(transform.localScale, m_maxScale, Time.deltaTime * m_scaleSpeed);
    }

    protected override void ApplyRetractEffect()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, m_minScale, Time.deltaTime * m_scaleSpeed);

        if (transform.localScale.x < m_minScaleToExplode.x && transform.position.y < m_minScaleToExplode.y)
            Destroy(gameObject);
    }
}
