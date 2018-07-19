using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CustomNetworkManager : NetworkManager {
    
	void Start () {
		networkAddress = "127.0.0.1";
        networkPort = 10002;
	}
	
	void Update () {
		
	}

    public void ButtonTrigger_StartHost() {
        StartHost();
    }

    public void ButtonTrigger_StartClient() {
        StartClient();
    }
}
