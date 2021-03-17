using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climber : MonoBehaviour {

    public float gravity = 45.0f;
    public float sensitivity = 45.0f;

    private HandClimber currentHand;
    private CharacterController controller;

    void Awake() {
        controller = GetComponent<CharacterController>();
    }

    void Update() {
        CalculateMovement();
    }

    private void CalculateMovement() {
        Vector3 movement = Vector3.zero;

        if (currentHand) {
            movement = currentHand.Delta * sensitivity;
            print("Movement: " + movement);
		}

        if (movement == Vector3.zero) {
           // movement.y -= gravity * Time.deltaTime;
		}

        controller.Move(movement * Time.deltaTime);
	}

    public void SetHand(HandClimber hand) {
        if (currentHand) {
            currentHand.ReleasePoint();
		}

        currentHand = hand;
	}

    public void ClearHand() {
        currentHand = null;
	}
}
