using UnityEngine;

public class InfluenceRadiusDetection : MonoBehaviour
{
    [SerializeField]
    private ArtifactHandler m_artifactHandler = new();

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.isTrigger)
            return;

        if (collider.TryGetComponent(out BaseScalable scalableClass))
        {
            scalableClass.Artifact = m_artifactHandler;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.isTrigger)
            return;

        if (collider.TryGetComponent(out BaseScalable scalableClass))
        {
            scalableClass.Artifact = new ArtifactHandler();
        }
    }
}