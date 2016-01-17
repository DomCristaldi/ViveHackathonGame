using UnityEngine;
using System.Collections.Generic;

public class ItemConnectionPoint : MonoBehaviour {

    public enum ConnectionType {
        root,
        extension,
    }

    public Transform connectedObject;

    public ItemConnectionPoint rootConnector;
    public List<ItemConnectionPoint> extensionConnectorList;

    public ConnectionType thisConnectionType;

	// Use this for initialization
	void Start () {
	    if (thisConnectionType == ConnectionType.root) {
            foreach (ItemConnectionPoint connector in extensionConnectorList) {
                connector.ConnectToRoot();
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ConnectToRoot() {
        Vector3 connectionDistanceVec = connectedObject.position - transform.position;
        connectedObject.position = rootConnector.transform.position + connectionDistanceVec;


        connectedObject.parent = rootConnector.connectedObject;
    }

}
