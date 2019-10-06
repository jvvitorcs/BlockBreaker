using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	[SerializeField] AudioClip[] SoundsBall;
	[SerializeField] float randomFactor = 0.5f;
	Paddle paddle;
	LevelManager level;
	GameSession gameSession;
	Lose lose;
	//private Vector3 original;
	//private Objects upgrades;
	Vector3 paddleToBallVector;
	Rigidbody2D rb2;
	bool moreBalls, ballsCount;
	AudioSource myAudioSource;
	[SerializeField] bool hasStarted = false;
	[SerializeField] float minV = 2f, maxV = 10f;
	[SerializeField] static int countBalls = 1;

	void Start () {
        Camera gameCamera = Camera.main;
		//upgrades = FindObjectOfType<Objects>();
        level = FindObjectOfType<LevelManager>();
		gameSession = FindObjectOfType<GameSession>();
		lose = FindObjectOfType<Lose>();
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		rb2 = GetComponent<Rigidbody2D> ();
		myAudioSource = GetComponent<AudioSource>();
    }
	
	void Update () {
		TheStart ();
       
    }	
	
	public void TheStart(){
		if (!hasStarted) {
			transform.position = paddle.transform.position + paddleToBallVector;
			if (Input.GetButtonDown("Fire1")) {
				hasStarted = true;
				rb2.velocity = new Vector2 (minV, maxV);
			}
		}
	}
    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Lose")
        {
            hasStarted = false;
            Time.timeScale = 1f;
            paddle.Normal();
			level.TakeLife();
		}
		else if (trigger.gameObject.tag == "Destroy")
        {

            Destroy(gameObject);
            level.BallDestroyed();

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
		{       
			Vector2 velocityTweak = new Vector2(randomFactor, randomFactor);		
			if(hasStarted)
			{
				AudioClip clip = SoundsBall[Random.Range(0, SoundsBall.Length)];
				myAudioSource.PlayOneShot(clip);
				rb2.velocity += velocityTweak;
		
			}

		}

    public void InstantiateMoreBalls()
    {
        Instantiate(gameObject, transform.position, Quaternion.identity);
        Instantiate(gameObject, transform.position, Quaternion.identity);

    }
}