using UnityEngine;
using System.Collections;
using Valve;
using Valve.VR;

public class ViveControllerHand : MonoBehaviour {

    public float grabDistnance = 1.0f;

    public Transform heldInRightHand;
    public Transform heldInLeftHand;

    public LayerMask raycastLayers;

    LineRenderer lineRen;

    void Awake() {
        lineRen = GetComponent<LineRenderer>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        int leftDeviceIndex = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost);
        int rightDeviceIndex = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Rightmost);

        Ray raycast = new Ray(transform.position, transform.forward);
        lineRen.SetPositions(new Vector3[] { transform.position, transform.position + raycast.direction * grabDistnance });

        if (SteamVR_Controller.Input(rightDeviceIndex).GetPressDown(EVRButtonId.k_EButton_SteamVR_Trigger)) {

            RaycastHit hit;
            /*
            if (Physics.Raycast(SteamVR_Controller.Input(rightDeviceIndex).transform.pos,
                            SteamVR_Controller.Input(rightDeviceIndex).transform.rot * Vector3.forward,
                            out hit, raycastLayers))
                            */
            if (Physics.Raycast(raycast, out hit, raycastLayers)) {
            
                if (hit.collider.GetComponent<ConstructionItem>() != null) {

                    heldInRightHand = hit.collider.gameObject.transform;
                    heldInRightHand.parent = transform;
                    heldInRightHand.GetComponent<ConstructionItem>().isHeld = true;
                }
            }
        }

        if (SteamVR_Controller.Input(rightDeviceIndex).GetPressUp(EVRButtonId.k_EButton_SteamVR_Trigger)) {

            if (heldInRightHand != null) {

                heldInRightHand.transform.parent = null;
                heldInRightHand.GetComponent<ConstructionItem>().isHeld = false;

                heldInRightHand.GetComponent<ConstructionItem>().canConnect = true;

                heldInRightHand = null;

                /*
                if (heldInRightHand.GetComponent<ConstructionItem>().canConnect == true) {
                    heldInRightHand.transform.parent = null;

                    heldInRightHand.GetComponent<ConstructionItem>().potentialConnection.ConnectToPotentialPoint();
                }
                else {
                    heldInRightHand.transform.parent = null;

                }
                */
            }
        }


        if (SteamVR_Controller.Input(leftDeviceIndex).GetPressDown(EVRButtonId.k_EButton_SteamVR_Trigger)) {

        }
    }
}
