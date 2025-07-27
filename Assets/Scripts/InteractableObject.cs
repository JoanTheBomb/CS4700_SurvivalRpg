using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{

    public bool playerInRange;
    public string ItemName;

    public string GetItemName()
    {
        return ItemName;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && playerInRange && SelectionManager.Instance.onTarget)
        {

            // Check if the inventory is not full before adding the item
            if (!InventorySystem.Instance.CheckIfFull())
            {
                InventorySystem.Instance.AddToInventory(ItemName);
                Destroy(gameObject); // Example action: destroy the object after interaction
            }
            else
            {
                Debug.Log("Inventory is full, cannot pick up item.");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false; 
        }
          
    }
}