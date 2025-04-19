using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent
{
    public delegate void CollectGold();
    public static CollectGold collectGold;

    public delegate void MinustGold();
    public static MinustGold minustGold;
    public delegate void WinGame();
    public static WinGame winGame;

    public delegate void LoseGame();
    public static LoseGame loseGame;
}
