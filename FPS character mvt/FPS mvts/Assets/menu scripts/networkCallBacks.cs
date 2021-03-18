using UnityEngine;
using Bolt;

public class networkCallBacks : GlobalEventListener
{
    public GameObject spherePrefab;

    public override void SceneLoadLocalDone(string scene, IProtocolToken ipt)
    {
        var SpawnPos = new Vector3(Random.Range(-8, 8), 1, Random.Range(-8, 8));

        BoltNetwork.Instantiate(spherePrefab, SpawnPos, Quaternion.identity);

    }
}
