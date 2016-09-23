using UnityEngine;
using System.Collections;

public class clsPlayerScript : MonoBehaviour 
{
    public GameObject goMoveMarker;          //Used to indicate where player character moves to

    public float fPlayerSpeed;              //Speed of player

    private bool bIsPlayerMoving = false;   //Check if player is moving

    private Vector2 v2PlayerPosition;       //Vector2 version of player's transform
    private Vector2 v2MoveTarget;           //Vector2 version of position touched on screen
    private Vector2 v2PlayerDirection;      //Direction player is moving from player's position to goMoveMarker
    private Vector2 v2MoveMarkerInitialPos; //goMoveMarker's starting position, which is offscreen

    private Ray rayTarget;                  //Ray is required for converting screen coordinates

    private Touch firstTouch;

    private Animator animPlayerAnimator;    

    private Rigidbody2D rb2DPlayer;

	void Start ()
    {
        animPlayerAnimator      = this.gameObject.GetComponent<Animator>();
        rb2DPlayer              = this.gameObject.GetComponent<Rigidbody2D>();

        v2PlayerPosition        = new Vector2(this.transform.position.x, this.transform.position.y);
        v2MoveMarkerInitialPos  = goMoveMarker.transform.position;
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
        if (bIsPlayerMoving == true)
        {
            rb2DPlayer.velocity = v2PlayerDirection.normalized * fPlayerSpeed;  //Move player
            goMoveMarker.transform.position = v2MoveTarget; //Indicate where the player touched to let player know sprite is moving towards target

            if (Vector2.Distance(v2PlayerPosition, v2MoveTarget) <= 10f) //If close to target, stop moving
            {
                goMoveMarker.transform.position = v2MoveMarkerInitialPos;
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
