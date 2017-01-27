using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

    public GameObject[] balls;
    public GameObject[] nballs;
    public int i;
    public GameObject nextBall;

    private float nextSpawnTime;
    private float spawnPeriod;
    private Vector3 pos;
    private GameObject nextBall1, nextBall2, nextBall3, nextBall4,nextBall5,nextBall6,nextBall7,nextBall8;

    // Use this for initialization
    void Start()
    {
        pos = nextBall.transform.position;
        //InvokeRepeating("Spawn", 0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreScript.score >= 30)
            spawnPeriod = Random.RandomRange(0.6f, 1.1f);
        if (ScoreScript.score >= 20 && ScoreScript.score<30)
            spawnPeriod = Random.Range(1f, 1.5f);
        if (ScoreScript.score >= 15 && ScoreScript.score < 20)
            spawnPeriod = Random.Range(1.4f, 1.9f);
        if (ScoreScript.score >= 10 && ScoreScript.score < 15)
            spawnPeriod = Random.Range(1.6f, 2.1f);
        if (ScoreScript.score >= 5 && ScoreScript.score < 10)
            spawnPeriod = Random.Range(1.7f, 2.3f);
        if (ScoreScript.score <= 4)
            spawnPeriod = Random.Range(1.9f, 2.5f);


        if (Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + spawnPeriod;
            Spawn();
            nextBallShow();
        }
        

    }

    void Spawn()
    {
        i = Random.Range(0,100);
        if (i >= 0 && i < 100)
        {
            if (i >= 0 && i < 25)
            {
                if (nextBall1 != null)
                    Destroy(nextBall1);
                if (nextBall2 != null)
                    Destroy(nextBall2);
                if (nextBall3 != null)
                    Destroy(nextBall3);
                if (nextBall4 != null)
                    Destroy(nextBall4);
                if (nextBall5 != null)
                    Destroy(nextBall5);


                GameObject Ball = Instantiate(balls[0], transform.position, Quaternion.identity) as GameObject;
            }

            else if (i >= 25 && i < 50)
            {
                if (nextBall1 != null)
                    Destroy(nextBall1);
                if (nextBall2 != null)
                    Destroy(nextBall2);
                if (nextBall3 != null)
                    Destroy(nextBall3);
                if (nextBall4 != null)
                    Destroy(nextBall4);
                if (nextBall5 != null)
                    Destroy(nextBall5);
                GameObject Ball2 = Instantiate(balls[1], transform.position, Quaternion.identity) as GameObject;
            }

            else if (i >= 50 && i < 75)
            {
                if (nextBall1 != null)
                    Destroy(nextBall1);
                if (nextBall2 != null)
                    Destroy(nextBall2);
                if (nextBall3 != null)
                    Destroy(nextBall3);
                if (nextBall4 != null)
                    Destroy(nextBall4);
                if (nextBall5 != null)
                    Destroy(nextBall5);

                GameObject Ball3 = Instantiate(balls[2], transform.position, Quaternion.identity) as GameObject;
            }

            else if (i >= 75 && i < 100)
            {
                if (nextBall1 != null)
                    Destroy(nextBall1);
                if (nextBall2 != null)
                    Destroy(nextBall2);
                if (nextBall3 != null)
                    Destroy(nextBall3);
                if (nextBall4 != null)
                    Destroy(nextBall4);
                if (nextBall5 != null)
                    Destroy(nextBall5);

                GameObject Ball4 = Instantiate(balls[3], transform.position, Quaternion.identity) as GameObject;
            }
        }
        //else if (i >= 80 && i < 100)
        //{
        //    //power up grow
        //    if (i >= 80 && i < 84)
        //    {
        //        if (nextBall1 != null)
        //            Destroy(nextBall1);
        //        if (nextBall2 != null)
        //            Destroy(nextBall2);
        //        if (nextBall3 != null)
        //            Destroy(nextBall3);
        //        if (nextBall4 != null)
        //            Destroy(nextBall4);
        //        if (nextBall5 != null)
        //            Destroy(nextBall5);

        //        GameObject Ball5 = Instantiate(balls[4], transform.position, Quaternion.identity) as GameObject;

        //    }

        //    //power up shrink
        //    else if (i >= 84 && i < 88)
        //    {
        //        if (nextBall1 != null)
        //            Destroy(nextBall1);
        //        if (nextBall2 != null)
        //            Destroy(nextBall2);
        //        if (nextBall3 != null)
        //            Destroy(nextBall3);
        //        if (nextBall4 != null)
        //            Destroy(nextBall4);
        //        if (nextBall5 != null)
        //            Destroy(nextBall5);

        //        GameObject Ball6 = Instantiate(balls[5], transform.position, Quaternion.identity) as GameObject;
        //    }

        //    //power up speedup
        //    else if (i >= 88 && i < 92)
        //    {
        //        if (nextBall1 != null)
        //            Destroy(nextBall1);
        //        if (nextBall2 != null)
        //            Destroy(nextBall2);
        //        if (nextBall3 != null)
        //            Destroy(nextBall3);
        //        if (nextBall4 != null)
        //            Destroy(nextBall4);
        //        if (nextBall5 != null)
        //            Destroy(nextBall5);

        //        GameObject Ball7 = Instantiate(balls[6], transform.position, Quaternion.identity) as GameObject;
        //    }

        //    //power up speeddown
        //    else if (i >= 92 && i < 96)
        //    {
        //        if (nextBall1 != null)
        //            Destroy(nextBall1);
        //        if (nextBall2 != null)
        //            Destroy(nextBall2);
        //        if (nextBall3 != null)
        //            Destroy(nextBall3);
        //        if (nextBall4 != null)
        //            Destroy(nextBall4);
        //        if (nextBall5 != null)
        //            Destroy(nextBall5);

        //        GameObject Ball8 = Instantiate(balls[7], transform.position, Quaternion.identity) as GameObject;
        //    }

        //    else if (i>=96 && i<100)
        //    {
        //        if (nextBall1 != null)
        //            Destroy(nextBall1);
        //        if (nextBall2 != null)
        //            Destroy(nextBall2);
        //        if (nextBall3 != null)
        //            Destroy(nextBall3);
        //        if (nextBall4 != null)
        //            Destroy(nextBall4);
        //        if (nextBall5 != null)
        //            Destroy(nextBall5);

        //        GameObject Ball9 = Instantiate(balls[8], transform.position, Quaternion.identity) as GameObject;
        //    }
        

    }
            

    void nextBallShow()
    {
        if (i >= 0 && i < 25)
        {
            nextBall1 = Instantiate(nballs[0], pos, Quaternion.identity) as GameObject;
        }

        else if (i >= 25 && i < 50)
        {
            nextBall2 = Instantiate(nballs[1], pos, Quaternion.identity) as GameObject;
        }

        else if (i >= 50 && i < 75)
        {
            nextBall3 = Instantiate(nballs[2], pos, Quaternion.identity) as GameObject;
        }

        else if (i >= 75 && i < 100)
        {
            nextBall4 = Instantiate(nballs[3], pos, Quaternion.identity) as GameObject;
        }

        //else if (i >= 80 && i < 100)
        //{
        //    nextBall5 = Instantiate(nballs[4], pos, Quaternion.identity) as GameObject;
        //}

     }

}