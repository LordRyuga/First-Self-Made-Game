using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveSystem
{
    public static void SavePlayer (gameManager manager)
    {
        BinaryFormatter formatter = new BinaryFormatter();                      //Initiate the binary formatter for save file
        string path = Application.persistentDataPath + "/player.virus";         //Set the path to the persistent data path
        FileStream stream = new FileStream(path, FileMode.Create);              //Using create filemode, create a new stream at the path

        PlayerData data = new PlayerData(manager);                              // init a player data object by passing in the reference to
                                                                                // The gameManager script which consists of most game
                                                                                // Functionalites related to player.

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.virus";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream (path, FileMode.Open);           //Open the file saved at the specified path.

            PlayerData data = formatter.Deserialize(stream) as PlayerData;      // create a new playerdata object and return it.
            stream.Close();

            return data;
        }else
        {
            Debug.Log("No saved data");                     //If no saved file was found, then return null.
            return null;
        }
    }
}
