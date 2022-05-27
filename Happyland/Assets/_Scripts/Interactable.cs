using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactionTransform;

    public virtual void Interact ()
    {
        Debug.Log("Interactuando con" + transform.name);
    }

    private void OnDrawGizmosSelected()
    {
        if (interactionTransform != null)
            interactionTransform = transform;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
