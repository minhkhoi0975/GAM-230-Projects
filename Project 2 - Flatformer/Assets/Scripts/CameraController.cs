using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private Vector3 targetOffset = new Vector3(0, 3, -8);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Explain this better
        Vector3 targetXZ = target.transform.position;
        targetXZ.y = 0f;

        Vector3 sourceXZ = transform.position;
        sourceXZ.y = 0f;

        Vector3 toTarget = (targetXZ - sourceXZ).normalized;
        transform.rotation = Quaternion.LookRotation(toTarget);
        // TODO: Comment this better
        transform.position = target.transform.position + transform.rotation * targetOffset;
    }
}
