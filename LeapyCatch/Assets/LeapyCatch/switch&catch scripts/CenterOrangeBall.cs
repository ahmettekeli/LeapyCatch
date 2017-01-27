using UnityEngine;
using System.Collections;

public class CenterOrangeBall : MonoBehaviour {

	public AudioClip destroySound, wrongSound, gameOverSound;
    public BottomModeScript bms;
    //public HalfScreenRotateScript hsrs;
    //public powerUpScript puS;

	public void OnCollisionEnter(Collision collision)
	{
		if (this.gameObject.tag == "orange" && collision.gameObject.tag == "orange") //when same color ball collides , score increases,audioclip plays
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
