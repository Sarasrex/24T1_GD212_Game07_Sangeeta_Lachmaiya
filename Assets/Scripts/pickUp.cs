using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject holdPosOne;
    public GameObject pizzaPrefab; // Prefab of the object to pick up
    public float throwForce = 10f;

    private GameObject heldObject; // Object that is picked up and held
    private Rigidbody heldObjectRb;

    void Start()
    {
        // Deactivate the hold position initially
        //holdPosOne.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Create a new object to visually represent the held object
                heldObject = Instantiate(pizzaPrefab, transform.position, Quaternion.identity);

                // Disable physics for the held object
                heldObjectRb = heldObject.GetComponent<Rigidbody>();
                if (heldObjectRb != null)
                    heldObjectRb.isKinematic = true;

                // Set the position of the held object to the hold position
                heldObject.transform.parent = holdPosOne.transform;

                // Activate the hold position
                holdPosOne.SetActive(true);

                // Deactivate the object that was picked up
                gameObject.SetActive(false);
            }
        }
    }

    void Update()
    {
        // Check if the player wants to throw the held object
        if (Input.GetKeyDown(KeyCode.Q) && heldObject != null)
        {
            Debug.Log("Throwing held object");
            // Release the held object
            heldObject.transform.parent = null;
            if (heldObjectRb != null)
            {
                heldObjectRb.isKinematic = false;

                // Apply a forward force to the object
                heldObjectRb.AddForce(transform.forward * throwForce);
            }

            // Clear the held object reference
            Destroy(heldObject); // Destroy the visual representation of the held object

            // Deactivate the hold position
            holdPosOne.SetActive(false);
        }
    }
}