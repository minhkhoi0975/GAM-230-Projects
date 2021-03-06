using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class Octahedron : MonoBehaviour
{
    private Mesh mesh;
    private MeshFilter meshFilter;

    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        meshFilter = GetComponent<MeshFilter>();

        meshFilter.mesh = mesh;

        UpdateMesh();
    }

    void UpdateMesh()
    {
        List<Vector3> vertices = new List<Vector3>();  // List of unique vertices.
        List<int> indices = new List<int>();
        List<Vector2> uvs = new List<Vector2>();

        // Define vertices.
        vertices.Add(new Vector3(-0.5f, 0.0f, -0.5f)); // Bottom left (xz plane)
        vertices.Add(new Vector3(-0.5f, 0.0f,  0.5f)); // Top left (xz plane)
        vertices.Add(new Vector3( 0.5f, 0.0f,  0.5f)); // Top right (xz plane)
        vertices.Add(new Vector3( 0.5f, 0.0f, -0.5f)); // Bottom right (xz plane)

        vertices.Add(new Vector3( 0.0f,  Mathf.Sqrt(2.0f) / 2.0f, 0.0f)); // Top (y axis)
        vertices.Add(new Vector3( 0.0f, -Mathf.Sqrt(2.0f) / 2.0f, 0.0f)); // Bottom (y axis)

        // Define triangles.
        indices.Add(4); indices.Add(0); indices.Add(1);
        indices.Add(4); indices.Add(1); indices.Add(2);
        indices.Add(4); indices.Add(2); indices.Add(3);
        indices.Add(4); indices.Add(3); indices.Add(0);

        indices.Add(1); indices.Add(0); indices.Add(5);
        indices.Add(2); indices.Add(1); indices.Add(5);
        indices.Add(3); indices.Add(2); indices.Add(5);
        indices.Add(0); indices.Add(3); indices.Add(5);


        List<Vector3> actualVertices = new List<Vector3>();
        for (int i = 0; i < indices.Count; i++)
        {
            actualVertices.Add(vertices[indices[i]]);
        }

        indices.Clear();
        for(int i = 0; i < actualVertices.Count; i++)
        {
            indices.Add(i);
        }

        
        /*
        uvs.Add(new Vector2(0.0f, 0.0f)); // Bottom left
        uvs.Add(new Vector2(0.0f, 1.0f)); // Top left
        uvs.Add(new Vector2(1.0f, 1.0f)); // Top right
        uvs.Add(new Vector2(1.0f, 0.0f)); // Bottom right
        uvs.Add(new Vector2(0.0f, 0.0f)); // Top
        */

        mesh.SetVertices(actualVertices);
        mesh.SetTriangles(indices, 0);
        // mesh.SetUVs(0, uvs);

        mesh.RecalculateNormals();
        mesh.RecalculateTangents();
    }
}
