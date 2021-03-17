using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Bolt;
using Bolt.Matchmaking;
using UdpKit;

public class menu : GlobalEventListener
{   

    //called from host game button
    public void startServer()
    {
        BoltLauncher.StartServer();
    }

    //start session
    public override void BoltStartDone()
    {
        BoltMatchmaking.CreateSession(sessionID: "testSession", sceneToLoad: "testGame");
    }

    //called from join game button
    public void startClient()
    {
        BoltLauncher.StartClient();
    }

    //client loop through session and join the first available one
    public override void SessionListUpdated(Map<Guid, UdpSession> sessionList)
    {
        foreach (var session in sessionList)
        {
            UdpSession photonSession = session.Value as UdpSession;

            if (photonSession.Source == UdpSessionSource.Photon)
            {
                BoltMatchmaking.JoinSession(photonSession);
            }
        }
    }
}
