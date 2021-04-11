using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public class MNetworkManager : NetworkManager
{
        public override void OnStartServer()
        {
            base.OnStartServer();

            Debug.Log("Server started!");
        }

        public override void OnStopServer()
        {
            base.OnStopServer();

            Debug.Log("Server stopped!");
        }

        public override void OnClientDisconnect(NetworkConnection conn)
        {
            base.OnClientDisconnect(conn);


            Debug.Log("Disconnnected from Server");

        }

    }
 