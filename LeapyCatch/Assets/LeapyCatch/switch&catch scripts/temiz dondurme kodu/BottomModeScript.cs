using UnityEngine;
using System.Collections;
using System;

public class BottomModeScript : MonoBehaviour {

    public static float rotationDirection;
    public float speed = 440f;
    public AudioClip rotationSound;
    public float powerSpeed = 1;
    public Animator anim;

    [SerializeField]
    private bool rotating;
    private Vector3 curEuler;


    void Update()
    {
        if (ScoreScript.gameLife % 2 == 0)
            rotationDirection = -1f;
        else if (ScoreScript.gameLife % 2 == 1)
            rotationDirection = 1f;
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
                curEuler.z = Mathf.MoveTowards(curEuler.z, newAngle, speed * Time.deltaTime * powerSpeed);
                transform.eulerAngles = curEuler;
                yield return null;
            }
        }

        else if(rotationDirection ==1)
        {
            float newAngle = curEuler.z - 90f;
            while (curEuler.z>newAngle)
            {
                curEuler.z = Mathf.MoveTowards(curEuler.z,newAngle,speed*Time.deltaTime * powerSpeed);
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
    public void pullAnimRun()
    {
        anim.SetTrigger("pull");
    }
}
