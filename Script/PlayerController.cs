using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody;
    float axisH = 0.0f;
    public float speed = 3.0f; //移動速度
    public float jump = 9.0f;
    public LayerMask groundLayer;
    public float groundSenser = 1.3f;

    public float respawn_x ;
    public float respawn_y ;

    bool goJump = false;
    bool onGround = false;
    bool isMoving = false;

    Animator animator;
    public string IdleAnime = "PlayerIdle";
    public string WalkAnime = "PlayerWalk";
    public string JumpAnime = "PlayerJump";
    public string FallAnime = "PlayerFall";
    string NowAnime = "";
    string OldAnime = "";


    public static bool IsAFK = false;
    int AFKTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        rbody = this.GetComponent<Rigidbody2D>();
        respawn();
        transform.localScale = new Vector2(4.0f,4.0f);
        
        animator = GetComponent<Animator>();
        NowAnime = IdleAnime;
        OldAnime = IdleAnime;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(rbody.velocity.y);
        
        //水平方向の入力
        if(isMoving == false){
            axisH = Input.GetAxisRaw("Horizontal");
        }

        if(axisH > 0.0f){
            //右移動
            transform.localScale = new Vector2(4.0f,4.0f);
        }
        else if(axisH < 0.0f){
            //左移動
            transform.localScale = new Vector2(-4.0f,4.0f);
        }

        //ジャンプ
        if( Input.GetButtonDown("Jump") ) {Jump();}
    }
    void FixedUpdate()
    {
        //地上判定
        onGround = Physics2D.Linecast(transform.position ,transform.position - (transform.up * groundSenser), groundLayer);

        //RaycastHit2D hit = Physics2D.Raycast(transform.position, (Vector2)ray.direction, transform.position - (transform.up * groundSenser), groundLayer);
  
        //速度を反映させる 
        if (axisH == 0){rbody.velocity = new Vector2(0, rbody.velocity.y);}
        else{rbody.velocity = new Vector2(axisH * speed, rbody.velocity.y);}
        if (onGround && goJump){
            //ジャンプを反映させる
            Vector2 jumpPw = new Vector2(0, jump);
            rbody.AddForce(jumpPw, ForceMode2D.Impulse);
            goJump = false;
        }

        //穴に落ちたら戻す
        if(transform.position.y < -10){
            respawn();
        }

        //アニメーション
        if(onGround){
            if(axisH == 0){NowAnime = IdleAnime;}
            else{NowAnime = WalkAnime;}
        }
        else{
            if(rbody.velocity.y > 0) {NowAnime = JumpAnime;}
            else{NowAnime = FallAnime;}
        }

        if(!IsAFK && NowAnime == IdleAnime){
            AFKTimer++;
        }

        
        //Debug.Log(AFKTimer);
        if(AFKTimer > 60){
            IsAFK = true;
            AFKTimer = 0;
            //Debug.Log("放置");
            GameObject UICanvas = GameObject.FindGameObjectWithTag("UICanvas");
            GameManager nanikore = UICanvas.GetComponent<GameManager>();
            //Debug.Log(nanikore);
            nanikore.AFKBarEffect(1);
        }

        if(NowAnime != OldAnime){
            if(OldAnime == IdleAnime){
                if(IsAFK){
                    IsAFK = false;
                    //Debug.Log("離脱");
                    GameObject UICanvas = GameObject.FindGameObjectWithTag("UICanvas");
                    GameManager nanikore = UICanvas.GetComponent<GameManager>();
                    nanikore.AFKBarEffect(2);
                }
                else{AFKTimer = 0;}
            }
            OldAnime = NowAnime;
            animator.Play(NowAnime);
        }
    }
    public void Jump(){
        goJump = true;
    }
    public void respawn(){
        transform.position = new Vector2(respawn_x, respawn_y);
    }
    

    public string SceneName;

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "TestPortal"){
            transform.position = new Vector2 (23, 10);
        }
    }

    public void SetAxis(float h,float v){
        axisH = h;
        if(axisH == 0){isMoving = false;}
        else{isMoving = true;}
    }
}