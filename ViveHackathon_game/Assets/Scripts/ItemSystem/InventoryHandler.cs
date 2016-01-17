using UnityEngine;
using System.Collections.Generic;

public class InventoryHandler : MonoBehaviour {

    public Transform handSocket;

    public BaseItem itemInHand;
    public List<BaseItem> ownedItemList;

	// Use this for initialization
	void Start () {
        //EquipItem(itemInHand);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /*
    public bool EquipItem(BaseItem item) {

        if (item == null) { return false; }

        if (ownedItemList.Contains(item)) {
            if (itemInHand != null) {
                UnequipItem(itemInHand);
            }

            itemInHand = item;

            itemInHand.transform.position = handSocket.transform.position;
            itemInHand.transform.rotation = handSocket.transform.rotation;
            itemInHand.transform.parent = handSocket;

        }

        return false;
        
    }

    public void UnequipItem(BaseItem item) {

    }
    */

    public void AddItemToInventory(BaseItem item) {
        ownedItemList.Add(item);
    }

    public void DropItemFromInventory(BaseItem item) {

    }
}
