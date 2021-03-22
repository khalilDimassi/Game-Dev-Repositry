using UnityEngine;

public class playerJoinLog : Bolt.EntityBehaviour<IcustomSphereS>
{
    public override void Attached()
    {
        var joinEvent = playerJoinedEvent.Create();
        joinEvent.joinLog = "i joined";
        joinEvent.Send();
    }
}
