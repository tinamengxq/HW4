# HW4
## Devlog
Write about how the model-view-control pattern is utilized in this project to keep the Player code decoupled from the other systems in this game. The model aspect of this game is less relevant, so you can skip describing it; however, the view and control aspects are very relevant, so you should describe which class defines the control side of this pattern, and which class defines the view side of this pattern.

Additionally, describe how events and a Singleton are used in your code to ensure the view and control aspects of your system are decoupled.

Make sure to cite your code (name specific classes, methods, and/or variables).


In model-view-control pattern, View represents visuals and results, and Control represents pure game logic. Even though in Player.cs I included some view things to play the audio:
```
    private void DieSound()
    {
        _audioDie.Play();
    }
    // and other 2 audios
```
I still believe that my Player.cs represents the control pattern. My player class focused on controlling the movement of player and deciding whether player scored or died. I used three events in player.cs: 
```
    //"Jump" - Audio
    public delegate void Jumped();
    public event Jumped playerJumped;

    //"Score" - UI
    public delegate void Scored();
    public event Scored playerScored;

    //"Die" - UI
    public delegate void Died();
    public event Died playerDied;
```


## Open-Source Assets
- [Brackey's Platformer Bundle](https://brackeysgames.itch.io/brackeys-platformer-bundle) - sound effects
- [2D pixel art seagull sprites](https://elthen.itch.io/2d-pixel-art-seagull-sprites) - seagull sprites
- [Free sound sources](https://freesound.org/)