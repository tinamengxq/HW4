# HW4
## Devlog
In model-view-control pattern, View represents visuals and results, and Control represents pure game logic. Even though in Player.cs I included some view things to play the audio:
```
    private void DieSound()
    {
        _audioDie.Play();
    }
    // and other 2 audios
```
I still believe that my Player.cs represents the control pattern. And in my UI.cs, it controls the adding of the score. In my Pipe.cs, it controls the movement of the score. While in the view-control patter, I think my UI.cs refers to the view patter. My player class focused on controlling the movement of player and deciding whether player scored or died. I used three events in player.cs: 
```
    //"Jump" - Audio
    public delegate void Jumped();
    public event Jumped playerJumped;
```

This event links jump to audio. When the player hits space, playerJumped is fired.

```
    void Jump()
    {
        _rigidbody.velocity = Vector2.up * playerSpeed;
        playerJumped?.Invoke();
    }
```
```
    //"Score" - UI
    public delegate void Scored();
    public event Scored playerScored;
```
This event links score to audio and UI. By OnTriggerEnter2D, the controller decide whether the player scored or not. If this is scored, playerScored is fired. Then the "View" is informed in UI. In UI, I subscribed a method of AddPoint() to playerScored to change the view on screen. I used singleton in Locator.cs to enable other methods to be subscribed to events in player wherever I want. I also used singleton in UI.cs to make sure there is only one UI in the screen.
```
    //Player.cs
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("TriggerEnter2D");

        if (other.CompareTag("Test"))
        {
            Debug.Log("TriggerCompareTest");
            playerScored?.Invoke();
        }
    }

    //UI.cs
    void Start(){
        Locator.Instance.Player.playerScored += AddPoint;
    }
    public void AddPoint()
    {
        Debug.Log("AddPoint()");
        _score += 1;
        scoreUI.text = "Score : " + _score;
    }
```
```
    //"Die" - UI
    public delegate void Died();
    public event Died playerDied;
```
This event links die to audio, UI and pipe. By OnCollisionEnter2D, the controller decide whether the player died or not. If player died, playerDied is fired. I subscribed a method of GameOver() in UI. Once playerDied is fired, the counting of scores stops and final score is shown in the middle of the screen. I also subscribed a method of PipeDie() in Pipe.cs. The script of pipe is destroyed after the player died. This stops the game immediately. 
```
    //Player.cs
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

    //UI.cs
    void Start(){
        Locator.Instance.Player.playerDied += GameOver;
    }
    void GameOver()
    {
        gameOverUI.SetActive(true);
        finalscoreUI.text = "Your Final Score: " + _score;
        scoreUI.gameObject.SetActive(false);
    }

    //Pipe.cs
    void Start()
    {
        Locator.Instance.Player.playerDied += PipeDie;
    }
    void PipeDie()
    {
        Destroy(this);
    }
```




## Open-Source Assets
- [Brackey's Platformer Bundle](https://brackeysgames.itch.io/brackeys-platformer-bundle) - sound effects
- [2D pixel art seagull sprites](https://elthen.itch.io/2d-pixel-art-seagull-sprites) - seagull sprites
- [Free sound sources](https://freesound.org/)