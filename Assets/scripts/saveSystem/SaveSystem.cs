using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem {

    public static void SavePlayer(MainPlayerStatus mainPlayerStatus, PlayerMovement playerMovement) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.continue";
        FileStream stream = new FileStream(path, FileMode.Create);

        MainPlayerData data = new MainPlayerData(mainPlayerStatus, playerMovement);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static MainPlayerData LoadPlayer() {
        string path = Application.persistentDataPath + "/player.continue";
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            MainPlayerData data = formatter.Deserialize(stream) as MainPlayerData;
            stream.Close();

            return data;
        }
        else {
            Debug.LogError("Save file not found" + path);
            return null;
        }
    }
}
