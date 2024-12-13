using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : ScriptableObject
{
    public int BoardSizeX = 5;

    public int BoardSizeY = 5;

    public int MatchesMin = 3;

    public int LevelMoves = 16;

    public float LevelTime = 30f;

    public float TimeForHint = 5f;

    public GameAssets[] assets;

    public Sprite GetItemSprite(int theme, int index)
    {
        if (assets.Length > theme)
        {
            if (assets[theme].itemSprs.Length > index)
            {
                return assets[theme].itemSprs[index];
            }
        }
        return null;
    }
}

[System.Serializable]
public class GameAssets
{
    public Sprite[] itemSprs;
}
