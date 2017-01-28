using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class rotation : MonoBehaviour {
    public static bool rotationStart = false;

    public float rotateSpeed = 5;
    public float addSpeed = 5;
    public float addSpeedTime = 0.5f;
    public float speedMax = 1500;
    private bool tf = false;

    public GameObject ball1;
    public GameObject ball2;
    public GameObject ball3;
    public GameObject ball4;
    public GameObject ball1R;
    public GameObject ball2R;
    public GameObject ball3R;
    public GameObject ball4R;
    private float rotateBallsReady = 0;
    private float num1 = 0;
    private float num2 = 0;
    private float num3 = 0;
    private float num4 = 0;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (ball1 == null)
        {
            ball1R.GetComponent<Renderer>().enabled = true;
            num1 = 1;
        }
        if (ball2 == null)
        {
            ball2R.GetComponent<Renderer>().enabled = true;
            num2 = 1;
        }
        if (ball3 == null)
        {
            ball3R.GetComponent<Renderer>().enabled = true;
            num3 = 1;
        }
        if (ball4 == null)
        {
            ball4R.GetComponent<Renderer>().enabled = true;
            num4 = 1;
        }

        rotateBallsReady = num1 + num2 + num3 + num4;
        if(rotateBallsReady == 4)
        {
            rotationStart = true;
            gameObject.transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);

            if (tf == false)
            {
                Invoke("IncreaseSpeed", addSpeedTime);
                tf = true;
            }

            if (rotateSpeed >= speedMax)
            {
                Destroy(gameObject);
            }
        }
    }

    void IncreaseSpeed()
    {
        rotateSpeed += addSpeed;
        tf = false;
    }
}
