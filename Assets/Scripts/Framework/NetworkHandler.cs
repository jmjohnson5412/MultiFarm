using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public abstract class NetworkHandler : NetworkBehaviour {

    public abstract void HandlerStart_S();

    public abstract void HandlerStart_C();

    public abstract void HandlerUpdate_S();

    public abstract void HandlerUpdate_C();
}
