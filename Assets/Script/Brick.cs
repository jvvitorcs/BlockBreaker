using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
	private int maxHits;
	private int timesHit;
	private LevelManager level;
	public Sprite[] hitSprites;
	public static int breakbleCount = 0;
    [SerializeField] int pointsPerBlockDestroyed = 80;
    bool isBreakble;
	bool isBreakbleduo;
	[SerializeField] AudioClip breakSound;
	[SerializeField] GameObject blockSparklesVFX;
	[SerializeField] GameObject[] randomObjects;

	void Start () {
		level = FindObjectOfType<LevelManager>();
		isBreakble = (this.tag == "Breakble");
		isBreakbleduo = (this.tag == "Breakbleduo");
		if (isBreakble || isBreakbleduo) {
			level.CountBlocks ();
		}
		timesHit = 0;	
	}	

	void OnCollisionEnter2D (Collision2D col){
		if (isBreakble || isBreakbleduo) {
			HandleHits ();
			}

	}


	void HandleHits () {
		timesHit++;
		maxHits = hitSprites.Length + 1;
		if (timesHit == maxHits) {
			breakbleCount--;
			level.BlockDestroyed();
			Destroy (gameObject);				
			PlayBlockDestroySFX ();
			if (isBreakbleduo) {
				NewItem ();
			}
		} else {
			LoadSprites ();
		}
	}


	void NewItem(){
		GameObject randomItem = randomObjects[Random.Range (0, randomObjects.Length)];
		Instantiate(randomItem, transform.position, Quaternion.Euler(0, 0, 0));
	}



	void PlayBlockDestroySFX ()
	{
		FindObjectOfType<GameSession>().AddToScore(pointsPerBlockDestroyed);
		AudioSource.PlayClipAtPoint (breakSound, Camera.main.transform.position);

	}

	void LoadSprites() {
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex]){
		this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	}
}