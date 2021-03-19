using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceMaintainSize : OVRGrabbable {

	private Transform base_parent;
	private Vector3 scale;

	protected override void Start() {
		base.Start();

		base_parent = transform.parent;
		scale = transform.localScale;
	}

	// Update is called once per frame
	public override void GrabBegin(OVRGrabber hand, Collider grabPoint) {
		base.GrabBegin(hand, grabPoint);

		transform.parent = hand.transform;
		transform.localScale = scale;
		transform.localPosition = new Vector3(0, 0, 0);

		if (transform.name.Equals("Virus Sample")) {

			GameObject.Find("Target").transform.position = new Vector3(-14.368f, 1.054f, 9.129f);
		}
    }

	public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity) {
		base.GrabEnd(linearVelocity, angularVelocity);

		transform.parent = base_parent;
		transform.localScale = scale;
	}
}
