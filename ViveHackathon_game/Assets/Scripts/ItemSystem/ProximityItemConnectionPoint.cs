using UnityEngine;
using System.Collections;

public class ProximityItemConnectionPoint : ItemConnectionPoint {

    MeshRenderer meshRender;

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

        meshRender = GetComponent<MeshRenderer>();
    }

    protected override void Start() {
        //base.Start();
    }

    protected override void Update() {
        //base.Update();
    }

    public override bool ConnectToSuppliedPoint(ItemConnectionPoint otherPoint) {
        return base.ConnectToSuppliedPoint(otherPoint);
    }

}
