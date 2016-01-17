using UnityEngine;
using System.Collections;
using Valve;
using Valve.VR;

public class ViveControllerHand : MonoBehaviour {

    public Transform heldInRightHand;
    public Transform heldInLeftHand;

    public LayerMask raycastLayers;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        int leftDeviceIndex = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost);
        int rightDeviceIndex = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Rightmost);


        if (SteamVR_Controller.Input(rightDeviceIndex).GetPressDown(EVRButtonId.k_EButton_SteamVR_Trigger)) {

            RaycastHit hit;

            if (Physics.Raycast(SteamVR_Controller.Input(rightDeviceIndex).transform.pos,
                            SteamVR_Controller.Input(rightDeviceIndex).transform.rot * Vector3.forward,
                            out hit, raycastLayers))
            {
                heldInRightHand = hit.collider.gameObject.transform;
                heldInRightHand.parent = transform;
            }
        }

        if (SteamVR_Controller.Input(rightDeviceIndex).GetPressUp(EVRButtonId.k_EButton_SteamVR_Trigger)) {

            if (heldInRightHand != null) {
                heldInRightHand.transform.parent = null;
            }
        }


        if (SteamVR_Controller.Input(leftDeviceIndex).GetPressDown(EVRButtonId.k_EButton_SteamVR_Trigger)) {

        }
    }
}
