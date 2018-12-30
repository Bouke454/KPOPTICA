using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    private Inventory inventory;
    public GameObject itemButton;
    public GameObject effect;
    private bool newItem;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Prevent multiple items of the same type stored inside the inventory
        foreach (GameObject slot in inventory.slots) {
            var children2 = slot.GetComponentsInChildren<Transform>();
            foreach (var child in children2) {

                string CurrentItem = child.name;
                if (child.name == itemButton.name + "(Clone)") {
                    newItem = true;
                }
            }
        }
        //Prevent the item from being grabbed while holding the same item
        string PickupItem = itemButton.name;
        string Holdingitem = PickupItem.Replace("Button", "Wep");
        var children3 = inventory.GetComponentsInChildren<Transform>();
        foreach (var child2 in children3) {
            if (child2.name == Holdingitem + "(Clone)") {
                newItem = true;
            }
        }


        if (other.CompareTag("Player") && newItem == false) {
            // spawn the item button at the first available inventory slot ! 
            for (int i = 0; i < inventory.items.Length; i++)
            {
                if (inventory.items[i] == 0) { // check whether the slot is EMPTY
                    Instantiate(effect, transform.position, Quaternion.identity);
                    inventory.items[i] = 1; // makes sure that the slot is now considered FULL
                    Instantiate(itemButton, inventory.slots[i].transform, false); // spawn the button so that the player can interact with it
                    Destroy(gameObject);
                    break;
                }
            }
        } 
        else if (newItem == true){
            newItem = false;
        }
        
        
    }
}
