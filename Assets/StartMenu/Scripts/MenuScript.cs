using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using System.Collections;

public class MenuScript : MonoBehaviour {

    public Canvas quitMenu;                                     //quitMenu is set to move along with the direction the player is looking when using Oculus
    public Button startText;
    public Button exitText;
    public GameObject startTextObject;
    public GameObject exitTextObject;
    public GameObject spawnSystem;
    public GameObject startingRoach;

    private bool quitMenuOpened = false;
    private float interval = 0f;
   // private float disappearRate = 3f;
   // private float nextDisappearTime;

	// Use this for initialization
	void Start () 
    {
        quitMenu = quitMenu.GetComponent<Canvas>();             //we want the canvas on the quitMenu obj
        startText = startText.GetComponent<Button>();           //grabbing button comp attached to start/exit text
        exitText = exitText.GetComponent<Button>();
        quitMenu.enabled = false;                               //disable quit menu at intialization of game
        spawnSystem.SetActive(false);
	}
	
    /**
        Function: Update() function for the StartMenu/QuitMenu Canvas/UI. **NOTE: Update is used here because Time.timeScale disables FixedUpdate if 0

        Description: Contains the code for enabling the options/quit menu AND pausing the gamewhen pressing "escape" button on keyboard.
                     When esc is pressed, timeScale is set to 0 which pauses the game and opens up the quit menu.
                     When esc is pressed while the quit menu is opened, quitMenu closes and game resumes.
    */
    void Update()
    {
        //Input.GetKeyDown(KeyCode.Space)  previously it was being checked if space was pressed instead of startingRoach dying, but this is more immersive

        if (startingRoach == null || startingRoach.activeSelf == false)         //checking for startingRoach == null is just a safety precaution
        {
            StartLevel();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            quitMenuOpened = !quitMenuOpened;                   //Required in order to switch the values of quitMenuOpened, otherwise doesn't work when timeScale == 0
            quitMenu.enabled = quitMenuOpened;

            Debug.Log("quitMenuOpened = " + quitMenuOpened);

            Time.timeScale = 0;
            Debug.Log("Game is paused");

            if (quitMenuOpened == false)
            {
                Debug.Log("Game is un-paused");
                Time.timeScale = 1;                             //This ensures that Time.timeScale is reset after the game becomes un-paused
            }
        }

        if (exitTextObject.activeSelf == true && quitMenuOpened == false)
        {
            InvokeRepeating("FlashLabel", 0, interval);
        }
    }

    //Seperate function that opens the QuitMenu ON CLICK instead of pressing esc
	public void ExitPress()
    {
            startTextObject.SetActive(false);
            quitMenuOpened = true;
            quitMenu.enabled = true;
            startText.enabled = false;
            exitText.enabled = false;

            Time.timeScale = 0;
            Debug.Log("Game paused via Exit click");
    }

    //Disables quitMenu if you click "NO"
    public void NoPress()
    {
        if(exitTextObject.activeSelf == true) 
        {
            startTextObject.SetActive(true);
        }
        Time.timeScale = 1;
        Debug.Log("Clicked 'NO' to unpause");

        quitMenuOpened = false;
        quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
    }

    //StartLevel function is used if I want to load a seperate scene for play
    //code taken off of start menu tutorial https://www.youtube.com/watch?v=pT4uca2bSgc
    //do not use this code
    /**
    public void StartLevel()                //uses Unity SceneManagement
    {
        SceneManager.LoadScene("MySceneName");
    }
    */

    //When Pressing Start/any button to begin the game
    //we don't destroy start or exit text because we still reference them when pressing 'esc' button for quit
    //we set exit text to false because we don't want it to clog our player HUD, can still use 'esc' to quit
    public void StartLevel()
    {
        //level starts, you killed the starting Roach (oh no!), Roaches start to spawn
        startTextObject.SetActive(false);                 
        exitTextObject.SetActive(false);

        /*
        nextDisappearTime = Time.time + disappearRate;
        while(Time.time != nextDisappearTime)
        {
            if (startingRoach.activeSelf)
            {
                startingRoach.SetActive(false);
            }
            else
            {
                startingRoach.SetActive(true);
            }
        }
        */

        startingRoach.SetActive(false);
        spawnSystem.SetActive(true);       
    }

    //makes our start text look like it's blinking
    void FlashLabel()
    {
        if(startTextObject.activeSelf)
        {
            startTextObject.SetActive(false);
        }
        else
        {
            startTextObject.SetActive(true);
        }
    }
    //Closes the application when you want to quit game
    public void ExitGame()
    {
        Application.Quit();
    }
}

