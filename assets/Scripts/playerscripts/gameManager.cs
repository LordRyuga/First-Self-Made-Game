using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.Playables;

public class gameManager : MonoBehaviour
{
    // Debug the pause screen popping up at start of game when player did not press new or load yet.


    

    // References to different timelines in the game
    [SerializeField] PlayableDirector openingScene;

    // Pieces of eternity
    [HideInInspector]
    public int[] PiecesOfEternity = new int[4];     //Array containing total number of pieces.
    [HideInInspector]
    public bool[] flagPiecesOfEternity = new bool[4];       //A flag array which will be saved to mark which pieces are collected.
                                                            // This flag will be used to stop dupes from spawning everytime we reload scene 
                                                            // from a savepoint.
    [HideInInspector]
    public float timeFactor = 1f;               // The factor in which player's health (time remaining) will decrease.
    [HideInInspector]
    public int numberOfPieces;
    // the number of pieces of eternity spread out in the entire game.

    //Reference to questsData so that the saving scripts can access it.
    public quests questsScriptReference;

    //health variables (time remaining)
    [SerializeField] Canvas DeadCanvas;
    bool isDead;
    public float health;
    public bool shouldDie;                              //If player is not in rest zone, set to true, else set to false.
    [SerializeField] TextMeshProUGUI healthText;          //TMP displaying health.
    float seconds = 1f;
    float TimerOfDeathTimeline;

    //References to the player's gameobject.
    public Transform player;
    public CharacterController playerController;
    public Animator playerAnimator;

    //Variables relating to damage of player.
    public float basicAttack = 5f;
    public float boostedAttack;
    public float attack;

    // shooting and slashing related variables
    bool shouldDamage;
    bool slashing;
    public bool HasMagic;

    // Since game is incomplete right now, I had already implemented a logic in this script to check for enemies while slashing, 
    // But I did not get to implementing melee combat system yet, so will be done later, and thus shoulDamage and slashing bools 
    // Are irrelevent as of now.

    bool shooting;

    //Blocking related variables
    bool blocking;

    //Due to same reason as above, even this is irrelevant.

    //Canvas of new and load
    public Canvas newLoad;          //At start of gaame user will be prompted to load from previous latest save file or start a new game.


    //Potions 
    public int strPots;             
    public int speedPots;
    public bool isStrong;
    public bool isFast;
    public float potion_duration = 5f;
    float cooldown;
    float cooldown_speed;
    public movement movementScript;             // Reference to movement script so that I can change the movement speeds when potion is used
    public TextMeshProUGUI speedCount;
    public TextMeshProUGUI strCount;

    void Start()
    {
        PiecesOfEternity[0] = 0;
        PiecesOfEternity[1] = 0;
        PiecesOfEternity[2] = 0;
        PiecesOfEternity[3] = 0;
        // Init all pieces as not collected.
        health = 60 * 45f;
        // Init health
        shouldDie = true;                   
        Cursor.lockState = CursorLockMode.None;
        slashing = false;   
        blocking = false;
        isStrong = false;
        isFast = false;
        shouldDamage = false;
        attack = basicAttack;
        cooldown = potion_duration;
        cooldown_speed = potion_duration;
        strPots = 0;
        speedPots = 0;
        newLoad.enabled = true;
        Time.timeScale = 0f;
        Debug.Log("Debug things mentioned in gamemanager script");
    }

    // Update is called once per frame
    void Update()
    {
  
        //Debug.Log(Cursor.lockState);
        for (int i = 0; i < 4; i++)
        {
            if (PiecesOfEternity[i] > 0 && flagPiecesOfEternity[i] == false)
            {
                flagPiecesOfEternity[i] = true;
                numberOfPieces++;
            }
        }

        //Logic to implement time factor for reduced speed of health loss if Pieces of eternity are obtained.
        timeFactor = 1f - (0.25f * numberOfPieces); 

        boostedAttack = basicAttack * 2;

        // Search how to stop slashing once animation ends later.
        if (Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Joystick1Button2))
        {
            shooting = true;            //Slash animation initiate
            slashing = true;
            //Debug.Log(attack);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0) || Input.GetKey(KeyCode.Joystick1Button2))
        {
            slashing = false;           // on releasing mouse button, stop damaging
            shooting = false;
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            blocking = true;            //block animation
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            blocking = false;           //unblock animation
        }
        if (blocking)
        {
            attack = 0;
            // Remember to implement invulnerable status when implementing health
        }else
        {
            if (isStrong)
            {
                attack = boostedAttack;
            }
            else
            {
                attack = basicAttack;
            }
        }

        // Potions Logic
        if (Input.GetKeyDown(KeyCode.Alpha2) && strPots > 0)
        {
            strPots--;
            isStrong = true;    //check if attack is boosted
        }
        if (isStrong)
        {
            cooldown -= Time.deltaTime;
            attack = boostedAttack;
            if (cooldown < 0)
            {
                isStrong = false;
                attack = basicAttack;
                cooldown = potion_duration;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && speedPots > 0)
        {
            speedPots--;
            isFast = true;    //check if speed is boosted
            //Debug.Log(isFast);
        }
        if (isFast)
        {
            cooldown_speed -= Time.deltaTime;
            movementScript.speed = 2 * movementScript.walk;
            if (cooldown_speed < 0)
            {
                isFast = false;
                //Debug.Log(isFast);
                movementScript.speed = movementScript.walk;
                cooldown_speed = potion_duration;
            }
        }
        speedCount.text = speedPots.ToString();
        strCount.text = strPots.ToString();
        if (playerAnimator != null)
        { 
            playerAnimator.SetBool("shooting", shooting);
        }

        if(shouldDie)
        {
            health -= (Time.deltaTime * timeFactor);
        }
        else
        {
            //health = health;
        }

        
        if (seconds > 0)
        {
            seconds -= Time.deltaTime;
        }
        else
        {
            seconds = 1f;
            float minutesLeft = health / 60f;
            int minutesLeftInt = (int)(minutesLeft);
            float secondsLeft = health % 60f;
            int secondsLeftInt = (int)(secondsLeft);
            healthText.text = "Time left : " + minutesLeftInt.ToString() + " m " + secondsLeftInt.ToString() + "s";  
        }

        if(health < 0 && !isDead)
        {
            isDead = true;
            health = 0;
            DeadCanvas.enabled = true;
            movementScript.ShouldMove = false;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
        

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            shouldDamage = true;
            Health OpponentHealth;
            OpponentHealth = other.GetComponent<Health>();
            if (OpponentHealth != null && slashing && shouldDamage)
            {
                OpponentHealth.health -= attack;
            }
        }else
        {
            shouldDamage = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "enemy")
        {
            shouldDamage = false;
        }
    }

    public void LoadData()
    {
        playerController.enabled = false;
        PlayerData data = SaveSystem.LoadPlayer();

        this.strPots = data.strPots;
        this.speedPots = data.speedPots;
        this.basicAttack = data.basicAttack;
        this.health = data.Health;
        this.PiecesOfEternity = data.piecesOfEternity;
        this.flagPiecesOfEternity = data.flagPiecesOfEternity;
        this.timeFactor = data.timeFactor;
        this.numberOfPieces = data.numberOfPieces;
        this.HasMagic = data.HasMagic;

        questsScriptReference.questsData = data.questStatus;
        questsScriptReference.items = data.questItems;
        Debug.Log(data.position[0]);
        Debug.Log(questsScriptReference.items[0]);

        Vector3 savedPosition;
        savedPosition.x = data.position[0];
        savedPosition.y = data.position[1];
        savedPosition.z = data.position[2];
        Vector3 savedRotation;
        savedRotation.x = data.rotation[0];
        savedRotation.y = data.rotation[1];
        savedRotation.z = data.rotation[2];

        //Debug.Log(savedPosition.x);
        //Debug.Log(savedPosition.y);
        //Debug.Log(savedPosition.z);

        Time.timeScale= 1f;
        Cursor.lockState = CursorLockMode.Locked;
        player.position = savedPosition;
        player.rotation = Quaternion.Euler(savedRotation);
        newLoad.enabled = false;
        playerController.enabled = true;  
        openingScene.time = openingScene.duration;
        openingScene.Evaluate();
        DeadCanvas.enabled = false;
        movementScript.ShouldMove = true;
        isDead = false;
    }

    public void NewGame()
    {
        Time.timeScale = 1f;
        newLoad.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        openingScene.Play();
        movementScript.ShouldMove = true;
        isDead = false;
    }

    public void AddStrPots()
    {
        strPots += 3;
    }

    public void AddSpeedPots()
    {
        speedPots += 3;
    }

}
