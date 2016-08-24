using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour 
{
    public GameObject MoveMarker;

    public float PlayerSpeed;

    private Vector2 v2PlayerPosition;
    private Vector2 v2MovePosition;
    private Vector2 v2MoveTarget;
    private Vector2 v2PlayerDirection;
    private Vector2 v2MoveMarkerInitialPos;

    private bool bIsPlayerMoving = false;

    private Ray rayTarget;

    private Touch firstTouch;

    private Animator animPlayerAnimator;

    private Rigidbody2D rb2DPlayer;

	void Start ()
    {
        animPlayerAnimator = this.gameObject.GetComponent<Animator>();
        rb2DPlayer = this.gameObject.GetComponent<Rigidbody2D>();
        v2PlayerPosition = new Vector2(this.transform.position.x, this.transform.position.y);
        v2MoveMarkerInitialPos = MoveMarker.transform.position;
	}
	
	void Update () 
    {
        if (Input.touchCount > 0)  //If screen was touched
        {
            firstTouch = Input.GetTouch(0);    //Detect only first finger
            bIsPlayerMoving = true;

            rayTarget = Camera.main.ScreenPointToRay(firstTouch.position);  //firstTouch.position is inaccurate, convert to a ray to get proper position at its origin
        }

        //Update player movement information here to increase accuracy
        v2PlayerPosition = new Vector2(this.transform.position.x, this.transform.position.y);
        v2MoveTarget = rayTarget.origin;
        v2PlayerDirection = v2MoveTarget - v2PlayerPosition;

        AnimatePlayer();
	}

    void FixedUpdate()
    {
        if (bIsPlayerMoving == true) //Move player
        {
            rb2DPlayer.velocity = v2PlayerDirection.normalized * PlayerSpeed;
            MoveMarker.transform.position = v2MoveTarget; //Indicate where the player touched to let player know sprite is moving towards target

            if (Vector2.Distance(v2PlayerPosition, v2MoveTarget) <= 10f) //If close to target, stop moving
            {
                MoveMarker.transform.position = v2MoveMarkerInitialPos;
                rb2DPlayer.velocity = Vector2.zero;
                bIsPlayerMoving = false;
            }
        }
    }

    void AnimatePlayer()  //Animates the sprite to face either left or right during movement
    {
        if (Input.touchCount > 0 || bIsPlayerMoving == true)
        {
            if (v2PlayerDirection.x >= 0)     //Animates player depending on facing left or right
            {
                animPlayerAnimator.SetTrigger("PlayerRunRight");
            }
            else if (v2PlayerDirection.x < 0)
            {
                animPlayerAnimator.SetTrigger("PlayerRunLeft");
            }
        }
        else if (Input.touchCount <= 0)
        {
            if ( v2PlayerDirection.x >= 0)  //Animates player depending on facing left or right
            {
                animPlayerAnimator.SetTrigger("PlayerIdleRight");
            }
            else if (v2PlayerDirection.x < 0)
            {
                animPlayerAnimator.SetTrigger("PlayerIdleLeft");
            }
        }
    }
       
}
