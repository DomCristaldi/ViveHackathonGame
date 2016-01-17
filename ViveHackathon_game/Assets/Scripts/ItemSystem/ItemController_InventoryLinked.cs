using UnityEngine;
using System.Collections;

public class ItemController_InventoryLinked : ItemController {

    public InventoryHandler invHandler;

    protected override void Awake() {

    }

	// Use this for initialization
	protected override void Start () {
	
	}
	
	// Update is called once per frame
	protected override void Update () {
        EquipItem(invHandler.ownedItemList[0]);

    }

    public override bool EquipItem(BaseItem item) {

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

    public override void UnequipItem() {
        base.UnequipItem();
    }
}
