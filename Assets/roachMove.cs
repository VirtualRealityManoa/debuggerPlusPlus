using UnityEngine;
using System.Collections;

public class roachMove : MonoBehaviour {

	public Transform player;    //プレイヤーを代入
	public float speed; //移動速度
    private bool swarm;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		speed = 80;
        swarm = false;
	}

	// Update is called once per frame
	void Update () {
		Vector3 playerPos = player.position;    //プレイヤーの位置
		Vector3 direction = playerPos - transform.position; //方向
		
        direction = direction.normalized;   //単位化（距離要素を取り除く）
        //Debug.Log("Direction " + direction.x);
        if (direction.x >= 0.03 || direction.x <= -0.03)
        {
            swarm = true;
        }
       

        if(swarm == true)
        {
            direction = Quaternion.AngleAxis(Time.deltaTime * speed, Vector3.forward) * direction;
            transform.position = playerPos + direction;
            //Debug.Log("swarming!");
        }
        else
        {
            transform.position = transform.position + (direction * speed * Time.deltaTime);
            transform.LookAt(player);   //プレイヤーの方を向く
        }
	}
}