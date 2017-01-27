using UnityEngine;
using System.Collections;
using Leap;

public class fistDetectScript : MonoBehaviour {

    Controller control;
    public BottomModeScript bms;
    bool isClenched;
    private bool leftSwipe;
    private bool rightSwipe;

    // Use this for initialization
    void Start () {
        control = new Controller();
        control.EnableGesture(Gesture.GestureType.TYPE_SWIPE);
        control.EnableGesture(Gesture.GestureType.TYPE_SCREEN_TAP);
        control.EnableGesture(Gesture.GestureType.TYPE_CIRCLE);
        control.EnableGesture(Gesture.GestureType.TYPE_KEY_TAP);
        control.Config.SetFloat("Gesture.Swipe.MinLength", 100.0f); // minimum swipe mesafesi
        control.Config.SetFloat("Gesture.Swipe.MinVelocity", 750f); // minimum swipe hizi
        control.Config.Save();
	
	}
	
	// Update is called once per frame
	void Update () {

        Frame myFrame = control.Frame(); //acessing controller's(control variable) frames
        GestureList myGesture = myFrame.Gestures();
        for(int i =0; i<myGesture.Count;i++)
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

                    if (swipeDirection.x<0)
                    {
                        Debug.Log("left swipe detected!");
                        leftSwipe = true;
                    }

                    else if(swipeDirection.x>0)
                    {
                        Debug.Log("right swipe detected!");
                        rightSwipe = true;
                    }

                    break;
                case Gesture.GestureType.TYPE_CIRCLE:
                    Debug.Log("gesture detected,the type is circle");
                    break;
                case Gesture.GestureType.TYPE_SCREEN_TAP:
                    Debug.Log("gesture detected,the type is screen tap");
                    break;
                case Gesture.GestureType.TYPE_KEY_TAP:
                    Debug.Log("gesture detected,the type is key tap");
                    break;

                default:
                    break;
            }
        }

        HandList allHands = myFrame.Hands;
        foreach(Hand hand in allHands)
        {
            float grab = hand.GrabStrength;
            if(grab <= 0.5f)
            {
                //Debug.Log("not grabbing/open palm" + grab);
            }

            else
            {
               // Debug.Log("Grabbing/closed palm" + grab);
                //isClenched = true;
                //bms.ballRotate();
                //bms.pullAnim();
            }
        }

        if(isClenched)
        {
            isClenched = false;
            //bms.ballRotate();
        }
	
	}

    void rotateClockWise()
    {
        BottomModeScript.rotationDirection = 1;
    }

    void rotateCounterClockWise()
    {
        BottomModeScript.rotationDirection = -1;
    }
}
