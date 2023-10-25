using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class titleScript : MonoBehaviour, IDataPersistence
{
    public Text highScoreText;
    public int highScore = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadData(GameData gameData) // from IDataPersistence
    {
        highScore = gameData.highScore;   // get high score
        highScoreText.text = highScore.ToString(); // set text
    }

    public void SaveData(ref GameData gameData) // from IDataPersistence
    {
        // Do nothing - title screen will not edit high score
    }
}
