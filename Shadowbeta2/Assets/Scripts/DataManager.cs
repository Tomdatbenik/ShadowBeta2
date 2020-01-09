using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManager
{
    public static readonly Vector2 PlayerHome = new Vector2(-40, 0.36f);
    public static readonly Vector2 OldLady = new Vector2(-64, 0.36f);
    public static readonly Vector2 Shop = new Vector2(-9, 0.36f);
    public static readonly Vector2 CyberCafe = new Vector2(30, 0.36f);
    public static readonly Vector2 Alley = new Vector2(-3, 0.36f);
    public static readonly Vector2 Club = new Vector2(1.5f, 0.36f);
    public static readonly Vector2 InsideOldLady = new Vector2(-9f, 0f);
    public static readonly Vector2 InsideCyberCafe = new Vector2(-14, -1.75f);
    public static readonly Vector2 InsideAlley = new Vector2(-7, -1.08f);
    public static readonly Vector2 OutOfPc = new Vector2(-8.5f, -1.82f);

    public static Spawnloaction lastLocation = Spawnloaction.PLAYERHOME;
}

public enum Spawnloaction
{
    PLAYERHOME,
    OLDLADY,
    SHOP,
    CYBERCAFE,
    ALLEY,
    CLUB,
    INSIDEOLDLADY,
    INSIDEALLEY,
    INSIDECYBERCAFE,
    OUTOFPC
}
