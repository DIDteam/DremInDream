using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class UI_MainMenuManager : MonoBehaviour
{
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
        EditorSceneManager.LoadScene("Gameplay");
        EditorSceneManager.LoadScene("Map01", UnityEngine.SceneManagement.LoadSceneMode.Additive);
    }
    
}
