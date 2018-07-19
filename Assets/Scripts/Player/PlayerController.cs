using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkEntityController {

    [SyncVar]
    Vector3 syncPosition;

    private float speed = 1;

    public void Start() {
        if(isServer) {
            ControllerStart_S();
        }
        if(isClient) {
            ControllerStart_C();
        }
    }

    public void Update() {
        if(isServer) {
            ControllerUpdate_S();
        }
        if(isClient) {
            ControllerUpdate_C();
        }
    }
    public override void ControllerStart_C() {

    }

    public override void ControllerStart_S() {

    }

    public override void ControllerUpdate_C() {
        if(!isLocalPlayer) {
            UpdateToSyncVars();
            return;
        }
        HandleInput();
    }

    public override void ControllerUpdate_S() {
        UpdateToSyncVars();
    }

    private void HandleInput() {
        Vector2 movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if(movementInput.x != 0) {
            Vector3 proposedMovement = transform.position + new Vector3(movementInput.x * speed, 0, 0);
            transform.position = Vector3.Lerp(transform.position, proposedMovement, Time.deltaTime);
        }
        if(movementInput.y != 0) {
            Vector3 proposedMovement = transform.position + new Vector3(0, 0, movementInput.y * speed);
            transform.position = Vector3.Lerp(transform.position, proposedMovement, Time.deltaTime);
        }

        if(Input.GetKeyDown(KeyCode.E)) {

        }

        CmdSyncPosition(transform.position);
    }

    private void UpdateToSyncVars() {
        transform.position = Vector3.Lerp(transform.position, syncPosition, Time.deltaTime);
    }

    [Command]
    public void CmdSyncPosition(Vector3 position) {
        syncPosition = position;
    }
}
