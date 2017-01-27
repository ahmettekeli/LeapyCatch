using UnityEngine;
using System.Collections;

public class CenterYellowBall : MonoBehaviour {

    public AudioClip destroySound, wrongSound, gameOverSound;

    public void OnCollisionEnter(Collision collision)
	{
		if (this.gameObject.tag == "yellow" && collision.gameObject.tag == "yellow")
		{
			Destroy(collision.gameObject);
            AudioSource.PlayClipAtPoint(destroySound, transform.position);
			ScoreScript.scoreIncrease();
		}

		else
		{
			Destroy(collision.gameObject);
            AudioSource.PlayClipAtPoint(wrongSound, transform.position);
			ScoreScript.lifeDecrease();
        }

		if (ScoreScript.gameLife == 0)
		{
            //AudioSource.PlayClipAtPoint(gameOverSound, transform.position);
            soundSourceScript.soundPlayable = true;
            gameFinish();
		}
	}

    public void gameFinish()
    {
        ScoreScript.gameOver = true;
    }
}
