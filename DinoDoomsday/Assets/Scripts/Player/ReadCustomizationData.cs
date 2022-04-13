using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Player;

public class CustomizationDataObj {
    public Player.Color primaryColor;
    public Player.Color secondaryColor;
    public Player.Hat hat;
}

public class ReadCustomizationData
{
    public CustomizationDataObj readJson() {
        string jsonContents = this.getContentsOfFile();
        //convert json string to obj reference: https://docs.unity3d.com/ScriptReference/JsonUtility.FromJson.html
        return JsonUtility.FromJson<CustomizationDataObj>(jsonContents);
    }

    //Referenced for file reading: https://support.unity.com/hc/en-us/articles/115000341143-How-do-I-read-and-write-data-from-a-text-file-
    private string getContentsOfFile() {
        string path = Application.persistentDataPath + "/CustomizationData.json";
        StreamReader reader = new StreamReader(path);
        string jsonContents = reader.ReadToEnd();
        reader.Close();
        return jsonContents;
    }
}
