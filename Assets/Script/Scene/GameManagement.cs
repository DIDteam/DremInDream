using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    public float Timmer;
    public List<MiniGameTracker> MainListGame = new List<MiniGameTracker>();
    public List<MiniGameTracker> SubListGame = new List<MiniGameTracker>();
    // Start is called before the first frame update
    void Start()
    {
        Timmer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (SuccressGame())
        {
            SceneManagement.GetInstance().GameRunning = false;
        }
        
        if (SceneManagement.GetInstance().GameRunning == false && SuccressGame())
        {
            UIManager.GetInstance().FinishScore(Timmer);
        }
        else
        {
            Timmer += Time.deltaTime;
        }
    }

    static public GameManagement GetInstance()
    {
        return (GameManagement)FindObjectOfType(typeof(GameManagement));
    } 

    public void MainCollisionActive(bool Active)
    {
        foreach (MiniGameTracker obj in MainListGame)
        {
            GameObject parent = obj.gameObject;
            parent.GetComponent<BoxCollider>().enabled = Active;
        }
    }

    public void SubCollisionActive(bool Active)
    {
        foreach (MiniGameTracker obj in SubListGame)
        {
            GameObject parent = obj.gameObject;
            parent.GetComponent<BoxCollider>().enabled = Active;
        }
    }

    public void SetVisibleLight(MiniGameTracker current)
    {
        foreach (MiniGameTracker obj in MainListGame)
        {
            obj.Lighting.SetActive(obj == current);
        }
    }

    public bool SuccressGame()
    {
        foreach (MiniGameTracker obj in MainListGame)
        {
            if (obj.IsComplete == false)
                return false;
        }

        return true;
    }
}
