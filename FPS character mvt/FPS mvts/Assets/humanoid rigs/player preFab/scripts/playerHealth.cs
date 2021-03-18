using UnityEngine;

public class playerHealth : Bolt.EntityBehaviour<IcustomSphereS>
{
    public int localHealth = 3;

    //void start():
    public override void Attached()
    {
        state.health = localHealth;
        state.AddCallback("health", healthCallback);
    }

    //syncronise local health with the network
    private void healthCallback()
    {
        localHealth = state.health;

        if (localHealth <= 0)
        {
            BoltNetwork.Destroy(gameObject);
        }
    }

    //change health locally
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            state.health -= 1;
        }
    }
}
