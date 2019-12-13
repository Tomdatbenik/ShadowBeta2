using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        switch(DataManager.lastLocation)
        {
            case Spawnloaction.PLAYERHOME:
                player.transform.position = DataManager.PlayerHome;
                break;
            case Spawnloaction.CYBERCAFE:
                player.transform.position = DataManager.CyberCafe;
                break;
            case Spawnloaction.CLUB:
                player.transform.position = DataManager.Club;
                break;
            case Spawnloaction.ALLEY:
                player.transform.position = DataManager.Alley;
                break;
            case Spawnloaction.SHOP:
                player.transform.position = DataManager.Shop;
                break;
            case Spawnloaction.OLDLADY:
                player.transform.position = DataManager.OldLady;
                break;
            case Spawnloaction.INSIDEOLDLADY:
                player.transform.position = DataManager.InsideOldLady;
                break;
            case Spawnloaction.INSIDEALLEY:
                player.transform.position = DataManager.InsideAlley;
                break;
            case Spawnloaction.INSIDECYBERCAFE:
                player.transform.position = DataManager.InsideCyberCafe;
                break;

        }

    }

}
