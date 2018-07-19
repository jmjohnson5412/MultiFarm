using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager : NetworkBehaviour {

    //HANDLERS
    public NetworkHandler[] handlerArray;
    
    public PlayerController[] playerArray;
    
	void Start() {
        print("GameManager start");
        if(isServer) {
            foreach(NetworkHandler handler in handlerArray) {
                handler.HandlerStart_S();
            }
        }
        if(isClient) {
            foreach(NetworkHandler handler in handlerArray) {
                handler.HandlerStart_C();
            }
        }
	}
	
	void Update() {
        print("GameManager update");
        if(isServer) {
            foreach(NetworkHandler handler in handlerArray) {
                handler.HandlerUpdate_S();
            }
        }
        if(isClient) {
            foreach(NetworkHandler handler in handlerArray) {
                handler.HandlerUpdate_C();
            }
        }
	}
}
