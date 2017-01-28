using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	//移動
	public float walkSpeed = 140; //移動速度係数
	//private float gravity = 0.01f;//重力加速度
	private Vector3 velocity;//現在の移動速度


	//回転
	private float RotSpeed = 30; //回転速度係数
	private float LimitRotX = 50f; //回転可能限界


	//CharacterController
	private CharacterController controller;


	//==================================
	//初期化
	//==================================


	void Start () {

		//CharacterControllerを取得
		controller = GetComponent<CharacterController>();

	}


	//==================================
	// ループ
	//==================================

	void PlayerMove(){

		//速度初期化
		velocity = Vector3.zero;


		//キー入力確認 各キーが押されているか
		if (Input.GetKey(KeyCode.A)){
			velocity -= transform.right;
		}
		else if (Input.GetKey(KeyCode.D)){
			velocity += transform.right;
		}
		if (Input.GetKey(KeyCode.W)){
			velocity += transform.forward;
		}
		else if (Input.GetKey(KeyCode.S)){
			velocity -= transform.forward;
		}

		//移動スピード設定
		velocity *= walkSpeed;


		//下を向いていても上に飛ばないように重力を代入
		//velocity.y = -gravity;//重力設定


		//キャラクターコントローラーの移動
		controller.Move(velocity * Time.deltaTime);

	}

	//キャラクター回転
	void PlayerRotation(){


		//回転速度
		float RotX = 0f , RotY = 0f;

		/////キー入力確認 各キーが押されているか
		if (Input.GetKey(KeyCode.LeftArrow)){
			RotY = -1f;
		}
		else if (Input.GetKey(KeyCode.RightArrow)){
			RotY = 1f;
		}else if (Input.GetKey(KeyCode.UpArrow)){
			RotX = -1f;
		}else if (Input.GetKey(KeyCode.DownArrow)){
			RotX = 1f;
		}
		//回転予定角度X
		float NextRotX = transform.eulerAngles.x + RotX * RotSpeed *Time.deltaTime;


		//回転
		transform.rotation = Quaternion.Euler( 
			NextRotX, 
			transform.eulerAngles.y + RotY * RotSpeed *Time.deltaTime ,
			transform.eulerAngles.z
		) ;


	}

	void speedup(){
		walkSpeed = 300.0f;
	}
		

	//フレーム毎に呼び出される
	void Update () {

		//キャラクター回転
		PlayerRotation ();

		//キャラクター移動
		PlayerMove ();

	}
}