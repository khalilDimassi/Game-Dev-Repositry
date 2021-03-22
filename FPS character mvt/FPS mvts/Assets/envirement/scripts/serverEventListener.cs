using UnityEngine;

public class serverEventListener : Bolt.GlobalEventListener
{
    public override void OnEvent(playerJoinedEvent joinEvent)
    {
        Debug.Log(joinEvent.joinLog);
    }
}
