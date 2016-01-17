using UnityEngine;
using System.Collections.Generic;

public class BaseItem : MonoBehaviour {

    public Transform handSocket;

    protected virtual void Awake() {

    }

	// Use this for initialization
	protected virtual void Start () {
	
	}
	
	// Update is called once per frame
	protected virtual void Update () {
	
	}

    public virtual void BlockedAction() { }

    public virtual void UnblockedAction() { }
}
