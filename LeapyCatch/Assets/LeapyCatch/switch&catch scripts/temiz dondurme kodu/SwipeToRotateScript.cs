using UnityEngine;
using System.Collections;

public class SwipeToRotateScript : MonoBehaviour
{

    public float minSwipeDist, maxSwipeTime;
    public AudioClip rotationSound;
    public int rotationDirection;
    public Vector3 currentRotation, targetRotation;
    public Animator anim;
    public float speed = 440f;
    private Vector3 curEuler;

    private Vector3 startPos;
    private float swipeStartTime;
    private float minSwipeDistX;
    private float minSwipeDistY;
    [SerializeField]
    private bool rotating;

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        if (Input.touchCount > 0)

        {

            Touch touch = Input.touches[0];



            switch (touch.phase)

            {

                case TouchPhase.Began:

                    startPos = touch.position;

                    break;



                case TouchPhase.Ended:

                    float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;

                    if (swipeDistVertical > minSwipeDistY)

                    {

                        float swipeValue = Mathf.Sign(touch.position.y - startPos.y);

                        if (swipeValue > 0) { }//up swipe

                        //Jump ();

                        else if (swipeValue < 0) { }//down swipe

                        //Shrink ();

                    }

                    float swipeDistHorizontal = (new Vector3(touch.position.x, 0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;

                    if (swipeDistHorizontal > minSwipeDistX)

                    {

                        float swipeValue = Mathf.Sign(touch.position.x - startPos.x);

                        if (swipeValue > 0)
                        {
                            Debug.Log("Sag");
                            rotationDirection = 1;
                            ballRotate();
                            pullAnim();

                            //transform.position = new Vector3(transform.position.x + 0.03f, transform.position.y, transform.position.z);
                        }

                        //MoveRight ();

                        else if (swipeValue < 0)
                        {
                            Debug.Log("Sol");
                            rotationDirection = -1;
                            ballRotate();
                            pullAnim();

                        }

                        //MoveLeft ();

                    }
                    break;
            }
        }
    }

    IEnumerator rotateAngle()
    {
        if (rotating)
        {
            yield break;
        }
        rotating = true;
        if (rotationDirection == -1)
        {
            float newAngle = curEuler.z + 90f;
            while (curEuler.z < newAngle) // cıkarma işleminde while sartı saglanmıyor.
            {
                curEuler.z = Mathf.MoveTowards(curEuler.z, newAngle, speed * Time.deltaTime);
                transform.eulerAngles = curEuler;
                yield return null;
            }
        }

        else if (rotationDirection == 1)
        {
            float newAngle = curEuler.z - 90f;
            while (curEuler.z > newAngle)
            {
                curEuler.z = Mathf.MoveTowards(curEuler.z, newAngle, speed * Time.deltaTime);
                transform.eulerAngles = curEuler;
                yield return null;
            }
        }

        rotating = false;
    }

    public void ballRotate()
    {
        StartCoroutine("rotateAngle");
    }

    public void pullAnim()
    {
        anim.SetTrigger("pull");
    }
}
