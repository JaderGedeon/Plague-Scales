using UnityEngine;

public class Artifact : MonoBehaviour
{
    [field: SerializeField] public ArtifactType ArtifactType { get; private set; }

    [field: SerializeField] public Color32 Color { get; private set; }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if (collider.TryGetComponent(out PlayerArtifactManager artifactManager))
            {
                artifactManager.SetPlayerCurrentArtifact(this);
            }
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if (collider.TryGetComponent(out PlayerArtifactManager artifactManager))
            {
                artifactManager.SetPlayerCurrentArtifact(this);
            }
        }
    }
}