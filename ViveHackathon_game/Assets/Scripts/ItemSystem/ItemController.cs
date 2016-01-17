using UnityEngine;
using System.Collections;

public class ItemController : MonoBehaviour {

    public InventoryHandler invHandler;

    //public BlockingItemTriggerHandler blockTrigHandler;

    public Transform itemSocket;

    public BaseItem itemInHand;

    void Awake() {
        //invHandler = GetComponent<InventoryHandler>();

        if (itemSocket == null) {
            Debug.LogWarningFormat(this, "No preassigned Item Socket. Assigning to this GameObject: ", gameObject.name);
        }
    }

	// Use this for initialization
	void Start () {
        EquipItem(invHandler.ownedItemList[0]);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool EquipItem(BaseItem item) {

        if (item == null) { return false; }//don't do anything if there was no item supplied

        if (invHandler.ownedItemList.Contains(item)) {
            if (itemInHand != null) {//if we have an item equipped, get rid of it

                //blockTrigHandler.FlushBockFunc();

                UnequipItem();
            }

            //EQUIP THE ITEM
            itemInHand = item;

            itemInHand.transform.position = itemSocket.transform.position;
            itemInHand.transform.rotation = itemSocket.transform.rotation;
            itemInHand.transform.parent = itemSocket;


            //blockTrigHandler.SubscribeToBlockFunc(itemInHand.BlockedAction, itemInHand.UnblockedAction);

        }

        return false;

    }

    public void UnequipItem() {

        if (itemInHand != null) {
            itemInHand.transform.parent = null;
        }

    }

}
