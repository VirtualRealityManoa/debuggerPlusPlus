using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{

    public int score;
    public int life;
    public Slider slider;
    public bool include_slider = false;
    public GameObject sfx;
    private GameObject sfxClone;

    // Use this for initialization
    void Start()
    {
        if (include_slider) slider = GameObject.Find("Slider").GetComponent<Slider>();
        sfx = GameObject.Find("explosion!");
    }

    // Update is called once per frame
    void Update()
    {

    }

	// Show points of damage above the bug that has been swatted.
	public void showDamageInflicted(int inputDamage) 
	{
		GameObject score = (GameObject)Instantiate (Resources.Load("score"), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
		score.GetComponent<TextMesh>().text = inputDamage.ToString();
		StartCoroutine ("moveUpFadeOut", score);
	}

	IEnumerator moveUpFadeOut(GameObject inputGameObject) 
	{
		float targetX = inputGameObject.transform.position.x;
		float targetY = inputGameObject.transform.position.y;
		float targetZ = inputGameObject.transform.position.z;

		for (float i = 1.0f; i > 0.0f; i -= 0.1f) 
		{
			// move up
			targetY += i * 5.0f;
			Vector3 targetPosition = new Vector3(targetX, targetY, targetZ);  
			Vector3 currentPosition = inputGameObject.transform.position;  
			inputGameObject.transform.position = targetPosition;
			// fade out
			Color inputColor = inputGameObject.GetComponent<Renderer>().material.color;
			inputColor.a = i;
			inputColor.r += i;
			inputGameObject.GetComponent<Renderer>().material.color = inputColor;
			yield return new WaitForSeconds(0.05f);
		}
		Destroy (inputGameObject);
		this.gameObject.SetActive(false);
		Destroy(this.gameObject);
	}

    public int attacked(int damage)
    {
		showDamageInflicted (damage);

        life = life - damage;
        if (include_slider) slider.value = life;
        if (life <= 0)
        {
            //Application.LoadLevel ("Clear");

            sfxClone = Instantiate(sfx, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
            gamescore theGameScore = GameObject.Find("Game Score").GetComponent<gamescore>();
            theGameScore.addKillPoint();
            theGameScore.addPoints(score);
            return 100;

            //OperationCanvas a = GetComponent<OperationCanvas> ();
            //a.Disable();
		
        }
        return 0;
    }
}
