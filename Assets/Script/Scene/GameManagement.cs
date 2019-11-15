using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    public List<MiniGameTracker> MainListGame = new List<MiniGameTracker>();
    public List<MiniGameTracker> SubListGame = new List<MiniGameTracker>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
