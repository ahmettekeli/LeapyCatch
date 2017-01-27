using UnityEngine;
using System.Collections;
using Leap;

public class LeapSwipeDetection : MonoBehaviour
{

    Controller control;
    public SwipyCatchScript SC;
    private bool leftSwipe;
    private bool rightSwipe;

    // Use this for initialization
    void Start()
    {
        control = new Controller();
        control.EnableGesture(Gesture.GestureType.TYPE_SWIPE);
        control.Config.SetFloat("Gesture.Swipe.MinLength", 200.0f); // minimum swipe mesafesi
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

                    if (swipeDirection.x < 0)
                    {
                        Debug.Log("left swipe detected!");
                        leftSwipe = true;
                    }

                    else if (swipeDirection.x > 0)
                    {
                        Debug.Log("right swipe detected!");
                        rightSwipe = true;
                    }
                    break;


            }
        }

        if(rightSwipe)
        {
            rightSwipe = false;
            SwipyCatchScript.rotationDirection = 1;
            SC.ballRotate();
            //right swipe
        }

        if(leftSwipe)
        {
            leftSwipe = false;
            SwipyCatchScript.rotationDirection = -1;
            SC.ballRotate();
            SC.pullAnimRun();
            //left swipe
        }
    }
}
