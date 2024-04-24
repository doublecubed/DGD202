using UnityEngine;

public class InteractionAI : MonoBehaviour
{
    public float interactionDistance = 3.0f;  // Distance within which the player can interact
    private GameObject currentInteractableObject = null;  // Store the current interactable object
    public LayerMask layerMask;
    
    void Update()
    {
        DetectNearbyInteractable();
        
        if (Input.GetKeyDown(KeyCode.E) && currentInteractableObject != null)
        {
            InteractWithObject();
        }
    }

    // Detect objects within interaction range
    void DetectNearbyInteractable()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance, layerMask))
        {
            if (hit.collider.gameObject != currentInteractableObject)
            {
                
                currentInteractableObject = hit.collider.gameObject;
                Debug.Log("Approached " + currentInteractableObject.name);
            }
        }
        else
        {
            if (currentInteractableObject != null)
            {
                currentInteractableObject = null;
            }
        }
    }

    // Handle interaction with the object
    void InteractWithObject()
    {
        Debug.Log("Interacted with " + currentInteractableObject.name);
    }
}