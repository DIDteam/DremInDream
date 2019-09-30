using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour
{

    public GameObject PrefabPlayer;
    public GameObject SpawnPoint;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPlayer()
    {
        //Debug.Log("Spawn Player");
       // player = Instantiate(PrefabPlayer, SpawnPoint.transform);
    }
}
