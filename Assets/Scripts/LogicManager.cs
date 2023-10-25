using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Xml.Serialization;

public class LogicManager : MonoBehaviour, IDataPersistence
{
    public int playerScore = 0;
    public Text scoreText;
    public Text highScoreText;
    public GameObject gameOverScreen;
    public AudioSource audioSource;

    private int highScore = 0;


    private enum myScenes
    {
        PlayScene,
        TitleScreen,
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
        audioSource.Play();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(myScenes.PlayScene.ToString());
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        updateHighScore();
    }

    public void loadMenu()
    {
        //SceneManager.UnloadSceneAsync(myScenes.PlayScene.ToString()); //Unload play scene
        SceneManager.LoadSceneAsync(myScenes.TitleScreen.ToString()); //load title scene
        DataPersistenceManager.instance.SaveGame();
    }

    private void updateHighScore()
    {
        if (playerScore > highScore)
        {
            highScore = playerScore;
        }
    }

    public void LoadData(GameData gameData) // from IDataPersistence
    {
        highScore = gameData.highScore; // get saved high score
        highScoreText.text = highScore.ToString();
    }

    public void SaveData(ref GameData gameData) // from IDataPersistence
    {
        if ( playerScore > highScore)
        {
            highScore = playerScore;
        }
        gameData.highScore = highScore;
    }
}
