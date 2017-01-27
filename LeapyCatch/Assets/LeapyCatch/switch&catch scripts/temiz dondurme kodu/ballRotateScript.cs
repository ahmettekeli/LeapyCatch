using UnityEngine;
using System.Collections;

public class ballRotateScript : MonoBehaviour {
  
    public float speed = 440f;
    public Animator anim;
    public AudioClip rotationSound;

    [SerializeField]
    private bool rotating;
    private bool canRotate;
    private int count;
    private Vector3 curEuler;

    // Use this for initialization

    IEnumerator rotateAngle()
    {
        if (rotating)
        {
            yield break;
            Debug.Log("already rotating");
        }
        rotating = true;
        float newAngle = curEuler.z + 90f;
        while (curEuler.z < newAngle)
        {
            curEuler.z = Mathf.MoveTowards(curEuler.z, newAngle, speed * Time.deltaTime);
            transform.eulerAngles = curEuler;
            yield return null;
        }
        rotating = false;
    }

    public void OnMouseDown()
    {
        count++;
        canRotate = true;
        ballRotate();
        Debug.Log(count);
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
