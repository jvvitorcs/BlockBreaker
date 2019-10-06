using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
	float xMin; 
	float xMax;
    float speed = 15f;
    [SerializeField]float screenWidthInUnits = 16f;
    [SerializeField] float padding = 0.6f;
    GameSession theGameSession;
	Ball theBall;
	private EdgeCollider2D col;
    private LevelManager level;
	private GameSession gameSession;
    private Lose lose;
	public List<Vector2> newVerticies = new List<Vector2>();
	public Sprite sprite1, sprite2, sprite3;
	public SpriteRenderer spriteRenderer;
    public int countTheBall;

    void Start () {
        SetUpMoveBoundaries();
        theBall = FindObjectOfType<Ball> ();
		theGameSession = FindObjectOfType<GameSession>();
		gameSession = FindObjectOfType<GameSession>();
		col = GetComponent<EdgeCollider2D>();
		spriteRenderer = GetComponent<SpriteRenderer>(); 
		lose = FindObjectOfType<Lose>();
        level = FindObjectOfType<LevelManager>();

    }
    void Update () {
        Movimentar();
        //Vector2 paddlePos = new Vector2 (transform.position.x, transform.position.y);
		//paddlePos.x = Mathf.Clamp (GetXPos(), minX, maxX);
		//transform.position = paddlePos;				
	}

    void Movimentar(){
		   var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
           var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
           transform.position = new Vector2 (newXPos, 0.5f);        
	}

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;       
    }


    /* private float GetXPos(){  
             return Input.mousePosition.x / Screen.width * screenWidthInUnits;	
         
     }*/



    void OnTriggerEnter2D (Collider2D collid){
		if (collid.gameObject.tag == "3Balls") {
            theBall.InstantiateMoreBalls();
            level.CountBalls();
        } else if (collid.gameObject.tag == "Diminute") {
			newVerticies.Clear();
			SmallVectors();
			spriteRenderer.sprite = sprite3;
        } else if (collid.gameObject.tag == "Grow") {
			newVerticies.Clear();
			NewVectors();
            spriteRenderer.sprite = sprite2;        
		} else if(collid.gameObject.tag == "Normal") {
			Normal ();
		} else if (collid.gameObject.tag == "Fast" && Time.timeScale <= 1) {
			Time.timeScale += 0.5f;
		} else if (collid.gameObject.tag == "Slow" && Time.timeScale >= 1) {				
			Time.timeScale -= 0.2f;
		} else if (collid.gameObject.tag == "Hearth") {
			level.AddToLife();
		}					
	}

	public void Normal(){
		newVerticies.Clear();
		CurrentVectors();
		spriteRenderer.sprite = sprite1; 
	}

	void CurrentVectors(){
		newVerticies.Add(new Vector2(-2.4f, -0.2f) );
		newVerticies.Add(new Vector2(-1.9f, 0.6f) );
		newVerticies.Add(new Vector2(1.9f, 0.6f) );
		newVerticies.Add(new Vector2(2.4f, -0.2f) );
		SetPoints ();
	}

    void NewVectors(){
		newVerticies.Add( new Vector2(-3.4f, -0.2f) );
		newVerticies.Add( new Vector2(-2.6f, 0.6f) );
		newVerticies.Add( new Vector2(2.6f, 0.6f) );
		newVerticies.Add( new Vector2(3.4f, -0.2f) );
		SetPoints ();
	}

	void SmallVectors(){
		newVerticies.Add( new Vector2(-1.1f, -0.2f) );
		newVerticies.Add( new Vector2(-0.6f, 0.6f) );
		newVerticies.Add( new Vector2(0.6f, 0.6f) );
		newVerticies.Add( new Vector2(1.1f, -0.2f) );
		SetPoints ();
	}

	void SetPoints(){
		
		col.points = newVerticies.ToArray ();
	}
}
