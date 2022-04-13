using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveCustomizationData : MonoBehaviour
{
    //Reference for writing data to json file: https://prasetion.medium.com/saving-data-as-json-in-unity-4419042d1334
    public void saveToJson(string[] data) {
        string toWrite = "{ \"primaryColor\" : \"" + data[0] + "\",";
        toWrite += "{ \"secondaryColor\" : \"" + data[1] + "\",";
        toWrite += "{ \"hat\" : \"" + data[2] + "\"}";
        System.IO.File.WriteAllText(Application.persistentDataPath + "/CustomizationData.json", toWrite);
        Debug.Log("saved data");
    }
}
