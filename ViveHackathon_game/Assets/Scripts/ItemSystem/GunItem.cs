using UnityEngine;
using System.Collections;

public class GunItem : BaseItem {

    Animator itemAnimations;

    //private Animator animatorOnHand;

    public LayerMask collisionLayers;

    private int collidingTriggers = 0;

    /*
    void OnTriggerEnter(Collider other) {

        if (collisionLayers == (collisionLayers | (1 << other.gameObject.layer))) { 

            if (collidingTriggers == 0) {

                Debug.LogFormat("Other: {0}",  other.gameObject.layer);

                ItemUpState(true);
            }

            ++collidingTriggers;

        }

    }

    void OnTriggerExit(Collider other) {

        if (collisionLayers == (collisionLayers | (1 << other.gameObject.layer))) {

            --collidingTriggers;

            if (collidingTriggers == 0) {
                ItemUpState(false);
            }
        }
    }
    */

    protected override void Awake() {
        base.Awake();

        itemAnimations = GetComponent<Animator>();
    }

    // Use this for initialization
    protected override void Start () {
	    
	}
	
	// Update is called once per frame
	protected override void Update () {
	    
	}

    public void ItemUpState(bool state) {

        Debug.Log("blamo");

        itemAnimations.SetBool("PointUpBool", state);
    }

    public override void BlockedAction() {
        base.BlockedAction();

        ItemUpState(true);

    }

    public override void UnblockedAction() {
        base.UnblockedAction();

        ItemUpState(false);
    }
}
