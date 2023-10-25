using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; // needed for .OfType method in FindAllDataPersistenceObjects()
/**
 * Keeps track of the state of our game data
 */
public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")] // for use in the inspector
    [SerializeField] private string fileName;

    /*
     * Static instance means there will only ever be one object.
     * This makes this class a 'singleton' class.
     * The '{ get; private set; }' means that anyone can get from this instance
     *  but can only set privtely within this instance
     */
    public static DataPersistenceManager instance { get; private set; }

    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects; // new list of type IDataPersistence
    private FileDataHandler fileDataHandler;

    /*
     * Initializes our instance.
     * Checks if there is already a data manager in scene
     */
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one data persist manager in scene lol.");
        }
        instance = this;
    }

    // TODO - call start when game is opened
    private void Start()
    {
        // pretty much always use Application.persistentDataPath for where to save data
        this.fileDataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    // TODO - call when game is closed
    private void OnApplicationQuit()
    {
        SaveGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        // Load any saved data from a file using data handler
        this.gameData = fileDataHandler.Load(); // will be null if no data/file

        // If no data can be loaded, initialize to new game
        if (this.gameData == null)
        {
            NewGame();
        }

        // push all loaded data to all scripts that need it
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData); // have each instance load game data
        }

        Debug.Log("Loaded high score = " + gameData.highScore); // remove
    }

    public void SaveGame()
    {
        // pass the data to other scripts so they can update it
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData); // have each instance load game data
        }
        Debug.Log("Saved high score = " + gameData.highScore); // remove

        // save that data to a file using the data handler
        fileDataHandler.Save(gameData);
    }

    /*
     * Method that returns a list of all IDataPersistence objects
     */
    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        // this does not match tutorial, but maybe it will work?
        IEnumerable<IDataPersistence> dataPersistenceObjects = Object.FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistence>(); // does this not use System.Linq then?
        return new List<IDataPersistence>(dataPersistenceObjects); // create new list and pass in objects found above
    }
}
