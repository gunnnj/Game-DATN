using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent
{
    public delegate void CollectGold();
    public static CollectGold collectGold;

    public delegate void MinustGold();
    public static MinustGold minustGold;

    public delegate void UpdateHealthHouse(float ratio);
    public static UpdateHealthHouse updateHealthHouse;

    public delegate void CompleteBuildHouse();
    public static CompleteBuildHouse completeBuildHouse;

    public delegate void WinGame();
    public static WinGame winGame;
    public static bool isWin = false;

    public delegate void LoseGame(int type);
    public static LoseGame loseGame;
    public static bool isLose = false;
}
