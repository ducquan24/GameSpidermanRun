using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public float speedForce;
    private float jumpForce;
    public bool isJumping;
    private float moveVertical;
    private Animator animate;
    public UIController uiController;
    private int coinScore;
    private float runScore;
    public Text coinScoreText;
    public Text totalCoinScoreText;
    public Text runScoreText;
    public Text totalRunScoreText;
    [SerializeField] private AudioSource jumpSound; 
    [SerializeField] private AudioSource pickCoinSound; 
    [SerializeField] private AudioSource deathSound; 
    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        animate = gameObject.GetComponent<Animator>();
        speedForce = 1f;
        jumpForce = 40f;
        isJumping = false;
        coinScore = 0;
        coinScoreText.text = coinScore.ToString();
        
    }
    // Update is called once per frameO
    void Update()
    {
        moveVertical = Input.GetAxisRaw("Vertical");
        animate.SetBool("isJumping", isJumping);
        animate.SetFloat("yVelocity",rb2D.velocity.y);
        coinScoreText.text = coinScore.ToString();

        runScore += Time.deltaTime * 10;
        runScoreText.text = (int)runScore + "";

    }
    void FixedUpdate()
    {
        rb2D.AddForce(new Vector2(speedForce, 0f), ForceMode2D.Impulse);
        if(moveVertical > 0 && !isJumping){
            jumpSound.Play();
            rb2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Platform"){
            isJumping = false;
        }

        if(other.gameObject.tag == "DeadZone"){
            totalRunScoreText.text = (int)runScore+"";
            totalCoinScoreText.text = coinScore+"";
            deathSound.Play();
            uiController.GameOver();
        }

        if(other.gameObject.tag == "Gold"){
            coinScore++;
            pickCoinSound.Play();
        }

    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Platform"){
            isJumping = true;
        }
        
    }
}
