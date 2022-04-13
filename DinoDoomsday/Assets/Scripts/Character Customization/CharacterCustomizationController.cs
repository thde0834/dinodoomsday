using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCustomizationController : MonoBehaviour
{
    string primaryColor;
    string secondaryColor;
    string hat;
    public Transform dropdownPrimary;
    public Transform dropdownSecondary;
    public Transform dropdownHat;
    public SaveCustomizationData dataSavingObj;

    // Start is called before the first frame update
    void Start()
    {
        primaryColor = "Blue";
        secondaryColor = "Red";
        hat = "None";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //referenced to get text value from dropdown: https://answers.unity.com/questions/1167834/how-do-you-access-the-text-value-of-the-dropdown-u.html
    public void changePrimaryColor() {
        string color =  dropdownPrimary.GetComponent<Dropdown>().options[dropdownPrimary.GetComponent<Dropdown>().value].text;
        Debug.Log(color);
        primaryColor = color;
    }

    //referenced to get text value from dropdown: https://answers.unity.com/questions/1167834/how-do-you-access-the-text-value-of-the-dropdown-u.html
    public void changeSecondaryColor() {
        string color =  dropdownSecondary.GetComponent<Dropdown>().options[dropdownSecondary.GetComponent<Dropdown>().value].text;
        Debug.Log(color);
        secondaryColor = color;
    }

    //referenced to get text value from dropdown: https://answers.unity.com/questions/1167834/how-do-you-access-the-text-value-of-the-dropdown-u.html
    public void changeHat() {
        string hat =  dropdownHat.GetComponent<Dropdown>().options[dropdownHat.GetComponent<Dropdown>().value].text;
        Debug.Log(hat);
        this.hat = hat;
    }

    public void save() {
        string[] arr = {primaryColor, secondaryColor, hat};
        Debug.Log("arr to save" + arr[0] + arr[1] + arr[2]);
        this.dataSavingObj.saveToJson(arr);
    }
}
