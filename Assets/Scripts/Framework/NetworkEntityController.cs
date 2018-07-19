using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public abstract  class NetworkEntityController : NetworkBehaviour {

    public abstract void ControllerStart_S();

    public abstract void ControllerStart_C();

    public abstract void ControllerUpdate_S();

    public abstract void ControllerUpdate_C();
}
