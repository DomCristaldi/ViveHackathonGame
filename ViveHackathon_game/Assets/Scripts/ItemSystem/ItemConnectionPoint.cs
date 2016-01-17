using UnityEngine;
using System.Collections.Generic;

public class ItemConnectionPoint : MonoBehaviour {

    public enum ConnectionType {
        bidirectional,
        root,
        extension,
    }

    public Transform connectedObject;

    public ItemConnectionPoint rootConnector;
    public List<ItemConnectionPoint> extensionConnectorList;

    public ConnectionType thisConnectionType;


    public bool canConnect = true;
    public bool isConnected = false;

    protected virtual void Awake() {

    }

	// Use this for initialization
	protected virtual void Start () {
	    if (thisConnectionType == ConnectionType.root) {
            foreach (ItemConnectionPoint connector in extensionConnectorList) {
                connector.ConnectToRoot();
            }
        }
	}
	
	// Update is called once per frame
	protected virtual void Update () {
	
	}

    public void ConnectToRoot() {
        ConnectToSuppliedPoint(rootConnector);

        /*
        Vector3 connectionDistanceVec = connectedObject.position - transform.position;
        connectedObject.position = rootConnector.transform.position + connectionDistanceVec;


        connectedObject.parent = rootConnector.connectedObject;
        */
    }

    public virtual bool ConnectToSuppliedPoint(ItemConnectionPoint otherPoint) {

        if (otherPoint.canConnect == false || otherPoint.isConnected == true) { return false; }


        Vector3 connectionDistanceVec = connectedObject.position - transform.position;
        connectedObject.position = otherPoint.transform.position + connectionDistanceVec;

        //connectedObject.rotation = 

        connectedObject.parent = otherPoint.connectedObject.transform;

        return true;
    }

    public virtual void DisconnectFromPoint() {
        connectedObject.parent = null;
    }

}
