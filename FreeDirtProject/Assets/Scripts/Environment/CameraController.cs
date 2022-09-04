using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*CameraController is responsible for making a list of all existing cameras
 * in the public game list. It also contains methods for all camera manipulations
 * which will be called from the CommandManager.
 */
public class CameraController : MonoBehaviour
{
    public CameraCommand camCommand;
    public List<Camera> camList;
    private List<CameraCommand> worldCams;

    void Start()
    {
        //Disables all but the first camera at the start of the program. 
        //Rearranging the public camera list in scene will change the default camera.
        camList[0].enabled = true;
        for(int i = 1; i < camList.Count; i++) {
            camList[i].enabled = false;
        }

        //Makes a list of cameras from the unity cameras with their names, number, and GameObject.
        worldCams = new List<CameraCommand>();
        int camCounter = 0;

        foreach (Camera camera in camList) {
            camCounter++;
            camCommand = new CameraCommand(camera, camCounter);
            worldCams.Add(camCommand);
            string camInfo = camCommand.ToString;
            if (worldCams != null) {
                Debug.Log("Camera created: " + camInfo);
            } 
        }
    }

    public void SwitchCamera(int camNum)
    {
        //Turns off all cameras in the scene, and enables the camera that was passed to it. 
        //Right now it only accepts the camera number as valid input. 
        if (camNum <= camList.Count && camNum > 0) {
            foreach (Camera cam in camList) {
                if (cam.enabled) {
                    cam.enabled = false;
                }
            }
            camList[camNum - 1].enabled = true; 
        }
        else {
            Debug.Log("User tried to switch the camera to an invalid number");
        } 
    }


}
