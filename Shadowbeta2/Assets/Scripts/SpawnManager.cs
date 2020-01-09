using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public PlayerSpawnLocation spawnLocation;
    public Spawn DefaultSpawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        if (spawnIsNull())
        {
            transform.position = DefaultSpawnLocation.position;
        }
        else
        {
            setPlayerLocation();
        }
    }

    private bool spawnIsNull()
    {
        if (spawnLocation.spawn == null)
            return true;
        return false;
    }

    private void setPlayerLocation()
    {
        if(!spawnIsNull())
            transform.position = spawnLocation.spawn.position;
    }
}
