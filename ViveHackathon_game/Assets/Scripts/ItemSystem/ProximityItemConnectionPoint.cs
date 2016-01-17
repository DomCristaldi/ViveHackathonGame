using UnityEngine;
using System.Collections;

public class ProximityItemConnectionPoint : ItemConnectionPoint {

    MeshRenderer meshRender;

    Collider physicalCollider;

    void OnTriggerEnter(Collider other) {

        ProximityItemConnectionPoint otherPoint = other.GetComponent<ProximityItemConnectionPoint>();


        if (otherPoint == null) { return; }

        //Debug.Log("Detected Collision");


        if (otherPoint != false) {
            ConnectToSuppliedPoint(otherPoint);
            
        }
    }


    protected override void Awake() {
        //base.Awake();

        meshRender = transform.parent.GetComponent<MeshRenderer>();

        physicalCollider = GetComponent<Collider>();

        connectedObject = transform.root;
    }

    protected override void Start() {
        //base.Start();
    }

    protected override void Update() {
        //base.Update();
    }

    public override bool ConnectToSuppliedPoint(ItemConnectionPoint otherPoint) {



        bool result = base.ConnectToSuppliedPoint(otherPoint);

        if (result == true) {
            physicalCollider.enabled = false;

            otherPoint.connectedObject.GetComponent<ConstructionItem>().childConstructList.Add(this.connectedObject.GetComponent<ConstructionItem>());
            this.connectedObject.GetComponent<ConstructionItem>().parentConstruct = otherPoint.connectedObject.GetComponent<ConstructionItem>();

            return true;
        }
        return false;

    }

    public override void DisconnectFromPoint() {

        base.DisconnectFromPoint();

        foreach (ConstructionItem cItem in connectedObject.GetComponent<ConstructionItem>().childConstructList) {
            cItem.transform.parent = null;
        }

        physicalCollider.enabled = true;
    }

}
