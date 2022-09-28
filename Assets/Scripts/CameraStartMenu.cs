using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStartMenu : MonoBehaviour
{
    private void Update() {
        if(LeanTween.isTweening(this.gameObject))
            return;

        TweenCam();
    }
 
    private void TweenCam() => LeanTween.moveSpline(this.gameObject, new Vector3[] { new Vector3(5f,8f,-55f),new Vector3(5f,8f,-55f), new Vector3(17f,8f,-55f), new Vector3(17.25f,8.5f,-55.5f), new Vector3(5.25f,8.25f,-55.1f), new Vector3(5f,8f,-55f), new Vector3(5f,8f,-55f)}, 30f);
}
