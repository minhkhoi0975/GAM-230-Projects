using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private AudioClip buttonPresseSFX;   // The sound effect when the player clicks the button.

    [SerializeField] private GameObject[] affectedGameObjects;

    [SerializeField] private float cooldown = 5.0f; // How long before the switch can be pressed again.
    private float currentCoolDown = 0.0f;

    private void Update()
    {
        if(currentCoolDown > 0f)
        {
            currentCoolDown -= Time.deltaTime;
        }
        else
        {
            currentCoolDown = 0.0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && currentCoolDown == 0.0f)
        {
            foreach(GameObject gameObject in affectedGameObjects)
            {
                MeshRenderer meshRender = gameObject.GetComponent<MeshRenderer>();
                if (meshRender != null)
                {
                    meshRender.enabled = !meshRender.enabled;
                }

                MeshCollider meshCollider = gameObject.GetComponent<MeshCollider>();
                if (meshCollider != null)
                {
                    meshCollider.enabled = !meshCollider.enabled;
                }
            }

            currentCoolDown = cooldown;

            other.gameObject.GetComponent<AudioSource>().PlayOneShot(buttonPresseSFX, 1.0f);
        }
    }
}
