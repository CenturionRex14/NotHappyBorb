using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int highScore;

    /*
     * Constructor that initializes all game data.
     * For this project, only needs to be called on new game.
     */
    public GameData()
    {
        highScore = 0; 
        // TODO - save to high score from logicManager
    }
}
