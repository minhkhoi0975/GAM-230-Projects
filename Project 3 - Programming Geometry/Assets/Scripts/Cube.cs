using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class Cube: MonoBehaviour
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

        // ---- Define Vertices ----

        // Top vertices (positive y)
        vertices.Add(new Vector3(-0.5f, 0.5f, -0.5f)); // Bottom left
        vertices.Add(new Vector3(-0.5f, 0.5f,  0.5f)); // Top left
        vertices.Add(new Vector3( 0.5f, 0.5f,  0.5f)); // Top right
        vertices.Add(new Vector3( 0.5f, 0.5f, -0.5f)); // Bottom right

        // Bottom vertices (negative y)
        vertices.Add(new Vector3(-0.5f, -0.5f, -0.5f)); // Bottom left
        vertices.Add(new Vector3(-0.5f, -0.5f,  0.5f)); // Top left
        vertices.Add(new Vector3( 0.5f, -0.5f,  0.5f)); // Top right
        vertices.Add(new Vector3( 0.5f, -0.5f, -0.5f)); // Bottom right

        // -------------------------

        // ----Define triangles.---- 

        // Top face (positive y)
        indices.Add(0); indices.Add(1); indices.Add(2);
        indices.Add(2); indices.Add(3); indices.Add(0);

        // Front face (negative z)
        indices.Add(4); indices.Add(0); indices.Add(3);
        indices.Add(3); indices.Add(7); indices.Add(4);

        // Right face (positive x)
        indices.Add(7); indices.Add(3); indices.Add(2);
        indices.Add(2); indices.Add(6); indices.Add(7);

        // Left face (negative x)
        indices.Add(5); indices.Add(1); indices.Add(0);
        indices.Add(0); indices.Add(4); indices.Add(5);

        // Back face (positive z)
        indices.Add(6); indices.Add(2); indices.Add(1);
        indices.Add(1); indices.Add(5); indices.Add(6);

        // Bottom face (negative y)
        indices.Add(7); indices.Add(6); indices.Add(5);
        indices.Add(5); indices.Add(4); indices.Add(7);

        // -------------------------

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

        for (int i = 0; i < actualVertices.Count / 6; i++)
        {
            // Set UV for top left triangle.
            uvs.Add(new Vector2(offsetX, offsetY));
            uvs.Add(new Vector2(offsetX, offsetY + 0.2f));
            uvs.Add(new Vector2(offsetX + 0.2f, offsetY + 0.2f));

            // Set UV for bottom right triangle.
            uvs.Add(new Vector2(offsetX + 0.2f, offsetY + 0.2f));
            uvs.Add(new Vector2(offsetX + 0.2f, offsetY));
            uvs.Add(new Vector2(offsetX, offsetY));

            // Move to the next number on the right.
            offsetX += 0.2f;

            // No more numbers on the right? Move to the first number on the next row.
            if(offsetX >= 1.0f)
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
