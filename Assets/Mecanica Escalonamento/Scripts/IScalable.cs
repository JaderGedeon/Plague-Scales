using System.Collections;
using UnityEngine;

public interface IScalable
{
    Coroutine CoroutineHandler { get; set; }
    public void StartScaling(ArtifactType artifactType);
    public IEnumerator ScalingCoroutine(ArtifactType artifactType);
    public void StopScaling();
}
