using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterCustomizationButtons : MonoBehaviour
{
    //referenced https://www.youtube.com/watch?v=zObWVOv1GlE for hiding and creating character customization object
    public GameObject CharacterCustomization;
    public CharacterCustomizationController controllerRef;
    //referenced https://www.youtube.com/watch?v=zObWVOv1GlE for loading new scenes
    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();
    // Start is called before the first frame update
    void Start()
    {
        CharacterCustomization.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //referenced https://www.youtube.com/watch?v=zObWVOv1GlE for loading new scenes
    public void back() {
        Debug.Log("pressed back");
        hideCharacterCustomization();
        scenesToLoad.Add(SceneManager.LoadSceneAsync("Main Menu"));
    }

    public void save() {
        Debug.Log("pressed save");
        controllerRef.save();
        hideCharacterCustomization();
        scenesToLoad.Add(SceneManager.LoadSceneAsync("Main Menu"));
    }
    //referenced https://www.youtube.com/watch?v=zObWVOv1GlE for hiding and creating menu object
    private void hideCharacterCustomization() {
        CharacterCustomization.SetActive(false);
    }
}
