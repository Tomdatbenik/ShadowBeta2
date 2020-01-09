using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        setPlayerLocation();
    }

    private void setPlayerLocation()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(DataManager.lastLocation);
        switch (DataManager.lastLocation)
        {
            case SpawnLocation.PLAYERHOME:
                player.transform.position = DataManager.PlayerHome;
                break;
            case SpawnLocation.CYBERCAFE:
                player.transform.position = DataManager.CyberCafe;
                break;
            case SpawnLocation.CLUB:
                player.transform.position = DataManager.Club;
                break;
            case SpawnLocation.ALLEY:
                player.transform.position = DataManager.Alley;
                break;
            case SpawnLocation.SHOP:
                player.transform.position = DataManager.Shop;
                break;
            case SpawnLocation.OLDLADY:
                player.transform.position = DataManager.OldLady;
                break;
            case SpawnLocation.INSIDEOLDLADY:
                player.transform.position = DataManager.InsideOldLady;
                break;
            case SpawnLocation.INSIDEALLEY:
                player.transform.position = DataManager.InsideAlley;
                break;
            case SpawnLocation.INSIDECYBERCAFE:
                player.transform.position = DataManager.InsideCyberCafe;
                break;
            case SpawnLocation.OUTOFPC:
                player.transform.position = DataManager.OutOfPc;
                break;
            case SpawnLocation.STARTROOM:
                player.transform.position = DataManager.StartRoom;
                break;
        }
    }

}
