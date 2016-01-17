using UnityEngine;
using System.Collections.Generic;

public class ConstructionItem : BaseItem {

    public ConstructionItem parentConstruct;

    public List<ConstructionItem> childConstructList;

    public List<ProximityItemConnectionPoint> connectionPointList;

    public ProximityItemConnectionPoint potentialConnection;

    public bool isHeld = false;

    public bool seekingConnections = false;
    public bool canConnect = false;

    protected override void Start() {
        base.Start();

        if (childConstructList == null) {
            childConstructList = new List<ConstructionItem>();
        }
        if (connectionPointList == null) {
            connectionPointList = new List<ProximityItemConnectionPoint>();
        }

        RecurseGetAllConnectionPoints(transform);
    }

    private void RecurseGetAllConnectionPoints(Transform child) {
        ProximityItemConnectionPoint hasPoint = child.GetComponent<ProximityItemConnectionPoint>();

        if (hasPoint != null) {
            connectionPointList.Add(hasPoint);
        }

        foreach (Transform tf in child) {
            RecurseGetAllConnectionPoints(tf);
        }
    }

}
