using UnityEngine;
using System.Collections;

public class leftHalfScript : MonoBehaviour
{

    public HalfScreenRotateScript ballrotate;
    

    public void OnMouseDown()
    {
        HalfScreenRotateScript.rotationDirection = -1;
        ballrotate.ballRotate();
        ballrotate.pullAnim();


    }
}
