using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Camera Stuff
    public Camera[] cameras;
    public Camera topCamera;
    private int currentCameraIndex;
    #endregion

    void Start ()
    {
        #region Camera Indexing and setting up Main Camera
        currentCameraIndex = 0;
        for (int i = 1; i < cameras.Length; i++)    // Setting all cameras to false
        {
            cameras[i].gameObject.SetActive(false);
        }
        if (cameras.Length > 0)     // Setting the default camera to active 
        {
            cameras[0].gameObject.SetActive(true);
        }
        #endregion
    }
	
	void Update ()
    {
        #region Camera Rotation (left & right)
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentCameraIndex++;   // add one to the index value
            if (currentCameraIndex < cameras.Length)    // if Index number < total number of cams...
            {
                cameras[currentCameraIndex - 1].gameObject.SetActive(false);    // disable the camera before this one
                cameras[currentCameraIndex].gameObject.SetActive(true);     // set the current camera to active
            }   
            else    // is you want to go from last camera to first camera
            {
                cameras[currentCameraIndex - 1].gameObject.SetActive(false);    // set the previous camera to false
                currentCameraIndex = 0; // set the camera index to the first camera in list
                cameras[currentCameraIndex].gameObject.SetActive(true); // set the current activated camera to true
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(currentCameraIndex == 0) // if the list of the cameras is on 0 ie. the first camera
            { 
                currentCameraIndex = cameras.Length - 1;    // brings the camera index to the last camera
                cameras[0].gameObject.SetActive(false);     // disables the first camera
                cameras[currentCameraIndex].gameObject.SetActive(true); // enables the current camera in the index
            }

            else
            {
                currentCameraIndex--;   // bring the camera index back by one
                cameras[currentCameraIndex + 1].gameObject.SetActive(false);    // set the current camera in the index to false
                cameras[currentCameraIndex].gameObject.SetActive(true); // enables the current camera in the index
            }
        }
        #endregion
        #region Camera Rotation (up)
        if (Input.GetKeyDown(KeyCode.UpArrow))  // up arrow pressed
        {
            topCamera.gameObject.SetActive(true);   // set the top camera to active
            cameras[currentCameraIndex].gameObject.SetActive(false);    // deactive the current camera
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))    //down arrow pressed
        {
            topCamera.gameObject.SetActive(false);  // disable the top camera
            cameras[currentCameraIndex].gameObject.SetActive(true); // set the previous camera to true
        }
        #endregion 
    }
} 
