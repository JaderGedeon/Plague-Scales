using UnityEngine;

public class Artifact : MonoBehaviour
{
    [field: SerializeField]
    public ArtifactType ArtifactType { get; private set; }
}