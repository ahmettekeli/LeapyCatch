using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Leap;

public class StartScene : MonoBehaviour
{

    Controller control;
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

                    if (swipeDirection.x < 0 || swipeDirection.x > 0)
                    {
                        SceneManager.LoadScene("");
                    }

                    else if (swipeDirection.y > 0 || swipeDirection.y > 0)
                    {
                        SceneManager.LoadScene("");
                    }
                    break;
            }
        }
    }
}