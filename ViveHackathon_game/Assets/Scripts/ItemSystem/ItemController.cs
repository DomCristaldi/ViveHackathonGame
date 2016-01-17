using UnityEngine;
using System.Collections;

public class ItemController : MonoBehaviour {

    //public BlockingItemTriggerHandler blockTrigHandler;

    public Transform itemSocket;

    public BaseItem itemInHand;

    protected virtual void Awake() {
        //invHandler = GetComponent<InventoryHandler>();

        if (itemSocket == null) {
            Debug.LogWarningFormat(this, "No preassigned Item Socket. Assigning to this GameObject: {0}", gameObject.name);
        }
    }

	// Use this for initialization
	protected virtual void Start () {

	}
	
	// Update is called once per frame
	protected virtual void Update () {
	
	}

    public virtual bool EquipItem(BaseItem item) {

        if (item == null) { return false; }

        if (itemInHand != null) {
            UnequipItem();
        }

        item.transform.parent = itemSocket.transform;

        return true;

    }


    public virtual void UnequipItem() {

        if (itemInHand != null) {
            itemInHand.transform.parent = null;
        }

    }

}
