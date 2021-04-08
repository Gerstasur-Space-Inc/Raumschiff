using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;
public class MNetworkPlayer : NetworkBehaviour
{
    [SyncVar] [SerializeField] private string displayName = "Kein Name";
    [SerializeField] private TMP_Text displayNameText = null;
    [SerializeField] private Renderer displayColourRenderer = null;

    /// <summary>
    /// Here comes everything about the player, wich is controlled by the server
    /// </summary>
    public MNetworkPlayer() { }
    #region Server
    [Server] public void SetDisplayName(string newDisplayName)
    {
        displayName = newDisplayName;
    }


    [Command] private void CmdSetDisplayName(string newDisplayName)
    {//Server validation missing

        if(newDisplayName.Length < 3|| newDisplayName.Length>10) { return; }
        RpcLogNewName(newDisplayName);
        SetDisplayName(newDisplayName);
    }
    #endregion

    #region Client

    [ContextMenu("Set My Name")]//to set in in the editor
    public void SetMyName()
    {
        CmdSetDisplayName("My New Name");
    }

    [ClientRpc] private void RpcLogNewName(string newDisplayName)
    {
        Debug.Log(newDisplayName);
    }

    #endregion




}
