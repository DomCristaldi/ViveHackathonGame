using UnityEngine;
using System.Collections;

using Valve;
using Valve.VR;

public class ProximityItemConnectionPoint : ItemConnectionPoint {

    MeshRenderer meshRender;

    Collider physicalCollider;

    ConstructionItem constructControl;

    public ProximityItemConnectionPoint connectToPoint;

    public bool inConnectionRange = false;

    void OnTriggerEnter(Collider other) {

        ProximityItemConnectionPoint otherPoint = other.GetComponent<ProximityItemConnectionPoint>();


        if (otherPoint == null) { return; }

        //Debug.Log("Detected Collision");

        inConnectionRange = true;
        connectToPoint = otherPoint;

        /*
        if (otherPoint != false && constructControl.isHeld == true) {
            //ConnectToSuppliedPoint(otherPoint);

            inConnectionRange = true;
            constructControl.canConnect = true;
            connectToPoint = otherPoint;
            constructControl.potentialConnection = this;
        }
        */
    }

    void OnTriggerExit(Collider other) {

        if (other.GetComponent<ProximityItemConnectionPoint>() != null) {
            inConnectionRange = false;
            connectToPoint = null;
        }

        /*
        if (inConnectionRange == true) {
            connectToPoint = null;
            constructControl.canConnect = false;
            inConnectionRange = false;
            constructControl.potentialConnection = null;
        }
        */
    }


    protected override void Awake() {
        //base.Awake();

        meshRender = transform.parent.GetComponent<MeshRenderer>();

        physicalCollider = GetComponent<Collider>();

        connectedObject = transform.root;
        constructControl = connectedObject.GetComponent<ConstructionItem>();
    }

    protected override void Start() {
        //base.Start();
    }

    protected override void Update() {
        //base.Update();

        //int rightDeviceIndex = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Rightmost);

        /*
        if (SteamVR_Controller.Input(rightDeviceIndex).GetPressUp(EVRButtonId.k_EButton_SteamVR_Trigger)) {

            if (inConnectionRange == true && constructControl.isHeld == true) {
                ConnectToSuppliedPoint(connectToPoint);
            }
            else {

            }
            
        }
        */

        
        if (canConnect == true && constructControl.canConnect == true && inConnectionRange == true && constructControl.isHeld == false && connectToPoint != null) {
            ConnectToSuppliedPoint(connectToPoint);
            inConnectionRange = false;
            //canConnect = false;
            constructControl.canConnect = false;
        }
        
    }

    public void ConnectToPotentialPoint() {
        ConnectToSuppliedPoint(connectToPoint);
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
