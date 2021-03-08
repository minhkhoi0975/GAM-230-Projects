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
        // The order of the triangles determines what number is attached to each triangle.
        indices.Add(0); indices.Add(4); indices.Add(3); // Top front face (negative z, positive y)
        indices.Add(0); indices.Add(5); indices.Add(1); // Bottom left face  (negative x, negative y)          
        indices.Add(1); indices.Add(4); indices.Add(0); // Top left face  (negative x, positive y)
        indices.Add(3); indices.Add(5); indices.Add(0); // Bottom front face (negative z, negative y)
        indices.Add(2); indices.Add(4); indices.Add(1); // Top back face  (positive z, positive y)    
        indices.Add(2); indices.Add(5); indices.Add(3); // Bottom right face (positive x, negative y)
        indices.Add(3); indices.Add(4); indices.Add(2); // Top right face (positive x, positive y)
        indices.Add(1); indices.Add(5); indices.Add(2); // Bottom back face  (positive z, negative y)  
        

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

            // No more numbers on the right? Move to the first number on the next row.
            if (offsetX >= 1.0f)
            {
                offsetX = 0.0f;
                offsetY -= 0.2f;
            }
        }

        mesh.SetVertices(actualVertices);
        mesh.SetTriangles(indices, 0);
        mesh.SetUVs(0, uvs);

        mesh.RecalculateNormals();
        mesh.RecalculateTangents();
    }
}
