using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArtifactManager : MonoBehaviour
{
    [SerializeField] private ArtifactHandler m_artifactHandler = new();

    [SerializeField] private MeshRenderer m_influenceRadiusRenderer;

    [SerializeField] private float m_droppedArtifactCooldown = 2f;

    private GameObject m_currentArtifact = null;

    public void SetPlayerCurrentArtifact(Artifact artifact)
    {
        if (m_currentArtifact != null)
            return;

        m_artifactHandler.ArtifactType = artifact.ArtifactType;
        m_currentArtifact = artifact.gameObject;
        m_influenceRadiusRenderer.enabled = true;
        m_influenceRadiusRenderer.material.SetColor("_GlowColor", artifact.Color);
        FindObjectOfType<AudioManager>().Play("Catch");
        m_currentArtifact.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (m_currentArtifact != null)
            {
                StartCoroutine(DropArtifact());
                FindObjectOfType<AudioManager>().Play("Drop");
                m_influenceRadiusRenderer.enabled = false;
                m_currentArtifact = null;
                m_artifactHandler.ArtifactType = ArtifactType.None;
            }
        }
    }

    private IEnumerator DropArtifact()
    {
        m_currentArtifact.transform.position = transform.position;
        m_currentArtifact.SetActive(true);

        if (m_currentArtifact.TryGetComponent(out BoxCollider collider))
        {
            collider.enabled = false;
        }

        yield return new WaitForSeconds(m_droppedArtifactCooldown);
        collider.enabled = true;
    }

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

[System.Serializable]
public class ArtifactHandler
{
    [SerializeField]
    public ArtifactType ArtifactType = ArtifactType.None;
}