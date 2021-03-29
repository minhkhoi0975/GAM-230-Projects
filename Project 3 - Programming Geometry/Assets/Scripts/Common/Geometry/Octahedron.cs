/**
 * Octahedron.cs
 * Programmer: Khoi Ho
 * Description: This script generates the mesh of an octahedral dice.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class Octahedron : MonoBehaviour
{
    private Mesh mesh;
    private MeshFilter meshFilter;
    private MeshCollider meshCollider;

    private Rigidbody rigidBody;

    private List<Vector3> faceNormals = new List<Vector3>();
    private List<Vector3> faceCenters = new List<Vector3>();

    public int diceValue = 0; // Stores the value of the die.
    public int DiceValue { get { return diceValue; } }

    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        meshFilter = GetComponent<MeshFilter>();
        meshCollider = GetComponent<MeshCollider>();

        meshFilter.mesh = mesh;

        UpdateMesh();

        meshCollider.sharedMesh = mesh;

        rigidBody = GetComponent<Rigidbody>();
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
            uvs.Add(new Vector2(offsetX, offsetY));                // Bottom left
            uvs.Add(new Vector2(offsetX + 0.1f, offsetY + 0.2f));  // Middle
            uvs.Add(new Vector2(offsetX + 0.2f, offsetY));         // Bottom right

            // Move to the next number on the right.
            offsetX += 0.2f;

            // No more numbers on the right? Move to the first number on the next row.
            if (offsetX >= 1.0f)
            {
                offsetX = 0.0f;
                offsetY -= 0.2f;
            }
        }

        // Find the center and the normal of each face.
        for(int i = 0; i < indices.Count/3; i++)
        {
            Vector3 a = actualVertices[i * 3];
            Vector3 b = actualVertices[i * 3 + 1];
            Vector3 c = actualVertices[i * 3 + 2];

            faceCenters.Add(0.95f * (a + b + c) / 3f);

            Vector3 normal = Vector3.Cross(a - b, a - c).normalized;
            faceNormals.Add(normal);
        }

        mesh.SetVertices(actualVertices);
        mesh.SetTriangles(indices, 0);
        mesh.SetUVs(0, uvs);

        mesh.RecalculateNormals();
        mesh.RecalculateTangents();
    }

    private void Update()
    {
        for (int f = 0; f < faceCenters.Count; ++f)
        {
            // Get the normal of the face (since the die rotates, the normal of the face must be recalculated). 
            Vector3 faceDirection = transform.rotation * faceNormals[f];

            // Check if the normal of the face points downward. If it is, get the value on the opposite face.
            float alignment = Vector3.Dot(Vector3.down, faceDirection);
            if (alignment > 0.8f && rigidBody.IsSleeping())
            {
                diceValue = 9 - (f + 1);
            }
        }
    }

    // Used for debugging.
    void OnDrawGizmos()
    {
        for (int f = 0; f < faceCenters.Count; ++f)
        {
            // Draw a red ray if the normal of the face does not point downward. Otherwise, draw a white ray.
            if (Physics.Raycast(transform.rotation * faceCenters[f] + transform.position, transform.rotation * faceNormals[f], 0.3f))
            {
                Gizmos.color = Color.red;
            }
            else
            {
                Gizmos.color = Color.white;
            }
            Gizmos.DrawRay(transform.rotation * faceCenters[f] + transform.position, transform.rotation * faceNormals[f]);
        }
    }
}
