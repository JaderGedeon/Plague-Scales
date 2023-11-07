using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfluenceRadiusDetection : MonoBehaviour
{
    // [SerializableField]
    // private ArtifactScript artifactScript;

    [SerializeField]
    private ArtifactType PROVISORIO_artifactType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IScalable scalableObject))
        {
            scalableObject.StartScaling(PROVISORIO_artifactType);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IScalable iScalable))
        {
            iScalable.StopScaling();
        }
    }
}
