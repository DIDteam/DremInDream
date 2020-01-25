using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_MainMenuManager : MonoBehaviour
{
    public GameObject SettingObj;
    public GameObject RaodMap;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void StartButton()
    {
        RaodMap.SetActive(true);
        SettingObj.SetActive(false);
        // SceneManager.LoadScene("Gameplay");
        //  SceneManager.LoadScene("Map01", UnityEngine.SceneManagement.LoadSceneMode.Additive);
    }
    public void SettingButton()
    {
        RaodMap.SetActive(false);
        SettingObj.SetActive(true);
    }
    public void CloseButton()
    {
        Application.Quit();
    }
    public void CloseAll()
    {
        RaodMap.SetActive(false);
        SettingObj.SetActive(false);
    }
}