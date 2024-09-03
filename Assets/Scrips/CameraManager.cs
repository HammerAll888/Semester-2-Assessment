using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    //List of Cinemachine Cameras
    public CinemachineVirtualCamera[] cameras; //The type of Cinemachine camera we're using

    //Listing the two camera game objects we're using
    public CinemachineVirtualCamera cam1;
    public CinemachineVirtualCamera cam2;

    public CinemachineVirtualCamera startCam; //Dictates which camera the game will start on
    private CinemachineVirtualCamera currentCam; //Dictates which camera is currently being used

    //Sets the priority of the cameras
    private void Start()
    {
        currentCam = startCam;

        for(int i = 0; i < cameras.Length; i++)
        {
            if (cameras[i] == currentCam)
            {
                cameras[i].Priority = 20;
            }
            else
            {
                cameras[i].Priority = 10;
            }
        }
    }

    //This handles the camera switching
    public void SwitchCamera(CinemachineVirtualCamera newCam)
    {
        currentCam = newCam;

        currentCam.Priority = 20;

        for(int i = 0; i < cameras.Length; i++)
        {
            if (cameras[i] != currentCam)
            {
                cameras[i].Priority = 10;
            }
        }
    }
}
