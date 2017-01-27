using UnityEngine;
using System.Collections;

public class powerUpScript : MonoBehaviour {

    public float growAmount;
    public float shrinkAmount;
    public float powerSpeed = 1;
    public GameObject ballHolder;

    private Vector3 defaultSize;


    void Start()
    {
        defaultSize = ballHolder.transform.localScale;
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

    public void scoreMultipliarInc()
    {
        ScoreScript.multipliar = 2;
    }

    public void scoreMultipliarFix()
    {
        ScoreScript.multipliar = 1;
    }
}
