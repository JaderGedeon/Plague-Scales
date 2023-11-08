using UnityEngine;

public class ScalableCrate : BaseScalable 
{
    protected override void ApplyExpandEffect()
    {
        if (IsObjectContained())
            return;

        transform.localScale = Vector3.Lerp(transform.localScale, m_maxScale, Time.deltaTime * m_scaleSpeed);
    }

    protected override void ApplyRetractEffect()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, m_minScale, Time.deltaTime * m_scaleSpeed);
    }
}