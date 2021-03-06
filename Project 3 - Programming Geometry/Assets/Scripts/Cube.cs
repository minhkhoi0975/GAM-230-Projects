using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
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
        meshCollider.sharedMesh = mesh;

        UpdateMesh();
    }

    void UpdateMesh()
    {
        List<Vector3> vertices = new List<Vector3>();  // List of unique vertices.
        List<int> indices = new List<int>();
        List<Vector2> uvs = new List<Vector2>();

        // Define vertices.
        vertices.Add(new Vector3(-0.5f, 0.5f, -0.5f)); // Bottom left
        vertices.Add(new Vector3(-0.5f, 0.5f,  0.5f)); // Top left
        vertices.Add(new Vector3( 0.5f, 0.5f,  0.5f)); // Top right
        vertices.Add(new Vector3( 0.5f, 0.5f, -0.5f)); // Bottom right

        vertices.Add(new Vector3(-0.5f, -0.5f, -0.5f)); // Bottom left
        vertices.Add(new Vector3(-0.5f, -0.5f,  0.5f)); // Top left
        vertices.Add(new Vector3( 0.5f, -0.5f,  0.5f)); // Top right
        vertices.Add(new Vector3( 0.5f, -0.5f, -0.5f)); // Bottom right

        // Define triangles.
        indices.Add(1); indices.Add(2); indices.Add(3);
        indices.Add(3); indices.Add(0); indices.Add(1);
        
        indices.Add(1); indices.Add(0); indices.Add(4);
        indices.Add(4); indices.Add(5); indices.Add(1);

        indices.Add(2); indices.Add(1); indices.Add(5);
        indices.Add(5); indices.Add(6); indices.Add(2);

        indices.Add(3); indices.Add(2); indices.Add(6);
        indices.Add(6); indices.Add(7); indices.Add(3);

        indices.Add(0); indices.Add(3); indices.Add(7);
        indices.Add(7); indices.Add(4); indices.Add(0);

        indices.Add(7); indices.Add(6); indices.Add(5);
        indices.Add(5); indices.Add(4); indices.Add(7);


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
