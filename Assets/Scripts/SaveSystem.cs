using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveData (TImer timerScript){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/firing-range.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        Data data = new Data(timerScript);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static Data LoadData(){
        string path = Application.persistentDataPath + "/firing-range.data";
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Data data = formatter.Deserialize(stream) as Data;
            stream.Close();
            
            return data;
        }else{
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
