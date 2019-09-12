using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    public GameObject Tracker;

    [Header("--Status PLayer--")]
    public float speed = 3.0F;
    public float rotateSpeed = 3.0F;
    public bool InZoneMiniGame = false;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        if (!SceneManager.GetInstance().CameraPlayer.working || SceneManager.GetInstance().MiniGameActive)
            return;
        Move();

        if(InZoneMiniGame && Input.GetKeyDown(KeyCode.E)){
            this.gameObject.SetActive(false);
            SceneManager.GetInstance().CameraPlayer.ChangeCameraMode(CameraFollowMode.FollowMiniGame);
            SceneManager.GetInstance().MiniGameActive = true;
            SceneManager.GetInstance().CanClick = true;
        }

       

    }
    static public PlayerController GetInstance()
    {
        return (PlayerController)FindObjectOfType(typeof(PlayerController));
    }
    void Move()
    {   
        // Rotate around y - axis
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);

        // Move forward / backward
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");
        controller.SimpleMove(forward * curSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {

    }
    private void OnTriggerExit(Collider other)
    {
        
    }
}
