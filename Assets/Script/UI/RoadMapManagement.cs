using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoadMapManagement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Map01Button()
    {
        SceneManager.LoadScene("Gameplay");
        SceneManager.LoadScene("Map01", UnityEngine.SceneManagement.LoadSceneMode.Additive);
    }
    public void Map02Button()
    {
        //SceneManager.LoadScene("Gameplay");
        //SceneManager.LoadScene("Map01", UnityEngine.SceneManagement.LoadSceneMode.Additive);
    }
    public void Map03Button()
    {
        //SceneManager.LoadScene("Gameplay");
        //SceneManager.LoadScene("Map01", UnityEngine.SceneManagement.LoadSceneMode.Additive);
    }
}
