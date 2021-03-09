using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class Tetrahedron : MonoBehaviour
{
    private Mesh mesh;
    private MeshFilter meshFilter;
    private MeshCollider meshCollider;

    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        meshFilter = GetComponent<MeshFilter>();
        meshCollider = GetComponent<MeshCollider>();

        meshFilter.mesh = mesh;

        UpdateMesh();

        meshCollider.sharedMesh = mesh;
    }

    void UpdateMesh()
    {
        List<Vector3> vertices = new List<Vector3>();  // List of unique vertices.
        List<int> indices = new List<int>();
        List<Vector2> uvs = new List<Vector2>();

        // Define vertices.
        vertices.Add(new Vector3(-0.5f, 0.0f, -Mathf.Sqrt(3.0f) / 6.0f)); // Bottom left (xz plane)
        vertices.Add(new Vector3( 0.0f, 0.0f,  Mathf.Sqrt(3.0f) / 3.0f)); // Middle (xz plane)
        vertices.Add(new Vector3( 0.5f, 0.0f, -Mathf.Sqrt(3.0f) / 6.0f)); // Bottom right (xz plane)
        vertices.Add(new Vector3( 0.0f, Mathf.Sqrt(6.0f) / 3.0f, 0.0f));  // Top (y axis)

        // Define triangles.
        indices.Add(0); indices.Add(3); indices.Add(2);
        indices.Add(2); indices.Add(3); indices.Add(1);
        indices.Add(1); indices.Add(3); indices.Add(0);
        indices.Add(2); indices.Add(1); indices.Add(0);

        // Vertices must be duplicated so that they have different normals.
        List<Vector3> actualVertices = new List<Vector3>();
        for (int i = 0; i < indices.Count; i++)
        {
            actualVertices.Add(vertices[indices[i]]);
        }

        // Set the indices again to match actualVertices.
        indices.Clear();
        for(int i = 0; i < actualVertices.Count; i++)
        {
            indices.Add(i);
        }

        // Set UVs
        float offsetX = 0.0f;
        float offsetY = 0.8f;

        for (int i = 0; i < actualVertices.Count / 3; i++)
        {
            uvs.Add(new Vector2(offsetX, offsetY));
            uvs.Add(new Vector2(offsetX + 0.1f, offsetY + 0.2f));
            uvs.Add(new Vector2(offsetX + 0.2f, offsetY));

            // Move to the next number on the right.
            offsetX += 0.2f;
        }

        mesh.SetVertices(actualVertices);
        mesh.SetTriangles(indices, 0);
        mesh.SetUVs(0, uvs);

        mesh.RecalculateNormals();
        mesh.RecalculateTangents();
    }
}
