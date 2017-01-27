using UnityEngine;
using System.Collections;
using Leap;

public class LeapVertSwipeDetection : MonoBehaviour
{

    Controller control;
    public BottomModeScript bms;
    private bool keyTap;

    // Use this for initialization
    void Start()
    {
        control = new Controller();
        control.EnableGesture(Gesture.GestureType.TYPE_SWIPE);
        control.Config.SetFloat("Gesture.Swipe.MinLength", 100.0f); // minimum swipe mesafesi
        control.Config.SetFloat("Gesture.Swipe.MinVelocity", 750f); // minimum swipe hizi
        control.Config.Save();

    }

    // Update is called once per frame
    void Update()
    {

        Frame myFrame = control.Frame(); //acessing controller's(control variable) frames
        GestureList myGesture = myFrame.Gestures();
        for (int i = 0; i < myGesture.Count; i++)
        {
            Gesture gesture = myGesture[i];

            switch (gesture.Type)
            {
                case Gesture.GestureType.TYPE_INVALID:
                    Debug.Log("gesture type is invalid.");
                    break;
                case Gesture.GestureType.TYPE_SWIPE:
                    Debug.Log("gesture detected, the type is swipe");
                    // bms.ballRotate();
                    SwipeGesture swipe = new SwipeGesture(gesture);
                    Vector swipeDirection = swipe.Direction;
                    //Debug.Log("swipeDirection is: "+swipe.Direction);

                    if (swipeDirection.y < 0)
                    {
                        Debug.Log("vertical swipe detected!");
                        keyTap = true;
                    }
                    break;


            }
        }

        if(keyTap)
        {
            keyTap = false;
            bms.ballRotate();
            bms.pullAnimRun();
        }
    }
}
