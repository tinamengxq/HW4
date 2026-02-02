using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private float playerSpeed = 4f;
    [SerializeField]private Rigidbody2D _rigidbody;
    [SerializeField]private AudioSource _audioJump;
    [SerializeField]private AudioSource _audioScore;
    [SerializeField]private AudioSource _audioDie;
    private bool dead;

    //"Jump" - Audio
    public delegate void Jumped();
    public event Jumped playerJumped;

    //"Score" - UI
    public delegate void Scored();
    public event Scored playerScored;

    //"Die" - UI
    public delegate void Died();
    public event Died playerDied;

    void Start()
    {
        dead = false;
        Locator.Instance.Player.playerDied += DieSound;
        Locator.Instance.Player.playerJumped += JumpSound;
        Locator.Instance.Player.playerScored += ScoreSound;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && dead != true)
        {
            Jump();
        }

        if (dead == true)
        {
            Debug.Log("Dead");
            return;
        }
    }

    //Player - Jump

    void Jump()
    {
        _rigidbody.velocity = Vector2.up * playerSpeed;
        playerJumped?.Invoke();
    }

    //Pipe - Score & Die

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (dead)
        {
            return;
        }
        if (collision.gameObject.CompareTag("Pipe"))
        {
            dead = true;
            playerDied?.Invoke();
            Destroy(this);
        }
    }

        void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("TriggerEnter2D");

        if (other.CompareTag("Test"))
        {
            Debug.Log("TriggerCompareTest");
            playerScored?.Invoke();
        }
    }

    //Audio

    private void DieSound()
    {
        _audioDie.Play();
    }

    private void JumpSound()
    {
        _audioJump.Play();
    }
    
    private void ScoreSound()
    {
        _audioScore.Play();
    }

    public void FromChecker()
    {
        playerScored?.Invoke();
    }
}
