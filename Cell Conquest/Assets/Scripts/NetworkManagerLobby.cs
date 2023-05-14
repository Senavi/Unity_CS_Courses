using Mirror;
using UnityEngine;

public class NetworkManagerLobby : NetworkManager
{
    public override void OnStartServer() { }

    public override void OnStopServer() { }

    public override void OnStartClient() { }

    public override void OnStopClient() { }

    public void OnServerAddPlayer(NetworkConnection conn) { }

    public void OnServerDisconnect(NetworkConnection conn) { }
}
