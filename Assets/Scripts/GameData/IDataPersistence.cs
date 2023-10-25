using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Interface for DataPersistenceManager (DPM)
 * Any script that wants to save or load data will use this interface
 * Each time DPM starts up, it will gather and store references to any script
 * that implements this interface
 */
public interface IDataPersistence
{
    // functions used in logicManager.cs
    void LoadData(GameData data);

    void SaveData(ref GameData data);

}
