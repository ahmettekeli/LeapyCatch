using UnityEngine;
using System.Collections;

public class HalfScreenRotateScript : MonoBehaviour {

    public float speed = 440f;
    public Animator anim;
    public float growAmount;
    public float shrinkAmount;
    public float powerSpeed = 1;
    public static int rotationDirection;

    [SerializeField]
    private bool rotating;
    private bool canRotate;
    private Vector3 curEuler;
    private Vector3 defaultSize;

    void Start()
    {
        defaultSize = transform.localScale;
    }


    IEnumerator rotateAngle()
    {
        if (rotating)
        {
            yield break;
            //ignore rotate requests while rotating
        }
        rotating = true;

        if (rotationDirection == 1)
        {
            float newAngle = curEuler.z + (90f * rotationDirection);
            while (curEuler.z < newAngle)
            {
                curEuler.z = Mathf.MoveTowards(curEuler.z, newAngle, speed * Time.deltaTime);
                transform.eulerAngles = curEuler;
                yield return null;
            }
        }

        if(rotationDirection ==-1)
        {
            float newAngle = curEuler.z + (90f * rotationDirection);
            while (curEuler.z > newAngle)
            {
                curEuler.z = Mathf.MoveTowards(curEuler.z, newAngle, speed * Time.deltaTime);
                transform.eulerAngles = curEuler;
                yield return null;
            }
        }
        rotating = false;
    }

    public void OnMouseDown()
    {
       // count++;
        canRotate = true;
       // ballRotate();
       // Debug.Log(count);
    }
    public void ballRotate()
    {
        StartCoroutine(rotateAngle());
    }

    public void pullAnim()
    {
        anim.SetTrigger("pull");
    }
    public void grow()
    {
        while (transform.localScale.x < growAmount)
        {
            transform.localScale += new Vector3(1.0f, 1.0f, 1.0f) * Time.deltaTime;
        }
    }

    public void shrink()
    {
        while (transform.localScale.x > shrinkAmount)
        {
            transform.localScale -= new Vector3(1f, 1f, 1f) * Time.deltaTime;
        }
    }

    public void backToNormalSize()
    {
        if (transform.localScale.x < defaultSize.x)
        {
            while (transform.localScale.x < defaultSize.x)
            {
                transform.localScale += new Vector3(1f, 1f, 1f) * Time.deltaTime;
            }
        }

        else if (transform.localScale.x > defaultSize.x)
        {
            while (transform.localScale.x > defaultSize.x)
            {
                transform.localScale -= new Vector3(1f, 1f, 1f) * Time.deltaTime;
            }
        }
    }

    public void speedUp()
    {
        powerSpeed = 4f;
    }

    public void speedDown()
    {
        powerSpeed = 0.4f;
    }

    public void speedFix()
    {
        powerSpeed = 1;
    }


}
