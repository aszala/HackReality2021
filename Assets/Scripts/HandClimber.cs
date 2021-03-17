using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandClimber : MonoBehaviour {

    public Climber climber;
    public OVRInput.Controller controller = OVRInput.Controller.None;

    public Vector3 Delta { private set; get; }

    private Vector3 lastPosition = Vector3.zero;

    private GameObject currentPoint;
    private List<GameObject> contactPoints = new List<GameObject>();

    void Awake() {
    }

	private void Start() {
        lastPosition = transform.position;
	}

	void Update() {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, controller)) {
            GrabPoint();
        }

        if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger, controller)) {
            ReleasePoint();
		}
    }

	private void FixedUpdate() {
        lastPosition = transform.position;
	}

	private void LateUpdate() {
        Delta = lastPosition - transform.position;
	}

	private void GrabPoint() {
        currentPoint = GetNearest(transform.position, contactPoints);

        if (currentPoint) {
            print("test");
            climber.SetHand(this);
		}
	}

    public void ReleasePoint() {
        if (currentPoint) {
            climber.ClearHand();
		}

        currentPoint = null;
	}

	private void OnTriggerEnter(Collider other) {
        AddPoint(other.gameObject);
	}

    private void AddPoint(GameObject newObject) {
        if (newObject.CompareTag("ClimbPoint")) {
            contactPoints.Add(newObject);
        }
	}

	private void OnTriggerExit(Collider other) {
        RemovePoint(other.gameObject);
	}

    private void RemovePoint(GameObject newObject) {
        if (newObject.CompareTag("ClimbPoint")) {
            contactPoints.Remove(newObject);
        }
    }

	private static GameObject GetNearest(Vector3 origin, List<GameObject> collection) {
        GameObject nearest = null;
        float minDistnace = float.MaxValue;
        float distance = 0.0f;

        foreach (GameObject entity in collection) {
            distance = (entity.gameObject.transform.position - origin).sqrMagnitude;

            if (distance < minDistnace) {
                minDistnace = distance;
                nearest = entity;
			}
		}

        return nearest;
	}
}
