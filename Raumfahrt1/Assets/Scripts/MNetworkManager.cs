using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MNetworkManager : NetworkManager
{
 

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        base.OnServerAddPlayer(conn);

        
        MNetworkPlayer player =conn.identity.GetComponent<MNetworkPlayer>();//Get the script

        player.SetDisplayName($"Spieler {numPlayers} ");//Set the Name

    }
}
