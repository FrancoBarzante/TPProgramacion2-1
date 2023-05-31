using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraScript : MonoBehaviour
{
    public Transform player;

    private CinemachineVirtualCamera virtualCamera;

    // Start is called before the first frame update
    private void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        virtualCamera.Follow = player;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
