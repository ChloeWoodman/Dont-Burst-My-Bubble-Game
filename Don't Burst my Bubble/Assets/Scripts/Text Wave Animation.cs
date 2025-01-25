using System.Collections;
using UnityEngine;
using TMPro;

public class TextWaveAnimation : MonoBehaviour
{
    public TMP_Text textMeshPro;
    public float amplitude = 5f;
    public float frequency = 2f;
    public float speed = 1f;

    private TMP_TextInfo textInfo;
    private Vector3[] originalVertices;

    void Start()
    {
        if (textMeshPro == null)
        {
            textMeshPro = GetComponent<TMP_Text>();
        }

        if (textMeshPro != null)
        {
            textInfo = textMeshPro.textInfo;
        }
    }

    void Update()
    {
        if (textMeshPro == null || textInfo == null) return;

        textMeshPro.ForceMeshUpdate(); // Force the mesh to update
        textInfo = textMeshPro.textInfo; // Get updated text info

        for (int i = 0; i < textInfo.characterCount; i++)
        {
            TMP_CharacterInfo charInfo = textInfo.characterInfo[i];
            if (!charInfo.isVisible) continue; // Skip invisible characters

            int vertexIndex = charInfo.vertexIndex;
            Vector3[] vertices = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;

            if (originalVertices == null || originalVertices.Length != vertices.Length)
            {
                originalVertices = (Vector3[])vertices.Clone();
            }

            // Calculate offset for the wave
            float offset = Mathf.Sin(Time.time * speed + i * frequency) * amplitude;

            // Apply offset to each vertex of the character
            vertices[vertexIndex + 0] = originalVertices[vertexIndex + 0] + new Vector3(0, offset, 0);
            vertices[vertexIndex + 1] = originalVertices[vertexIndex + 1] + new Vector3(0, offset, 0);
            vertices[vertexIndex + 2] = originalVertices[vertexIndex + 2] + new Vector3(0, offset, 0);
            vertices[vertexIndex + 3] = originalVertices[vertexIndex + 3] + new Vector3(0, offset, 0);
        }

        // Push the updated vertices back to the mesh
        for (int i = 0; i < textInfo.meshInfo.Length; i++)
        {
            textInfo.meshInfo[i].mesh.vertices = textInfo.meshInfo[i].vertices;
            textMeshPro.UpdateGeometry(textInfo.meshInfo[i].mesh, i);
        }
    }
}
