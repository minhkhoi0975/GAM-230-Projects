using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class ToggleMinimap : MonoBehaviour
{
    RawImage rawImage;

    // Start is called before the first frame update
    void Start()
    {
        rawImage = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("ToggleMinimap"))
        {
            rawImage.enabled = !rawImage.enabled;
        }
    }
}
