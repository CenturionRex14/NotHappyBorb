using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playButtonScript : MonoBehaviour
{
    //I really don't like this hard coded
    private enum myScenes
    {
        PlayScene,
        TitleScreen,
    }

    //When button is selected, load game scene:
    public void loadGame()
    {
        //SceneManager.UnloadSceneAsync(myScenes.TitleScreen.ToString()); //Unload title scene
        SceneManager.LoadSceneAsync(myScenes.PlayScene.ToString()); //load game scene
        
    }

    public void exitGame()
    {
        //DataPersistenceManager.instance.SaveGame(); // wont be needed once OnApplicationQuit is called
        Application.Quit();
    }
}
