using UnityEngine;
using System.Collections;
public class AnimateScore : MonoBehaviour {
	IEnumerator fadeOut(GameObject inputGameObject) {
		float targetX = inputGameObject.transform.position.x;
		float targetY = inputGameObject.transform.position.y;
		float targetZ = inputGameObject.transform.position.z;
		for (float f = 1.0f; f >= 0.0f; f -= 0.1f) {
			// move up
			targetY += f * 2.5f;
			Vector3 targetPosition = new Vector3(targetX, targetY, targetZ);  
			Vector3 currentPosition = inputGameObject.transform.position;  
			inputGameObject.transform.position = targetPosition;
			Color inputColor = inputGameObject.GetComponent<Renderer>().material.color;
			inputColor.a = f;
			inputColor.r += f;
			inputGameObject.GetComponent<Renderer>().material.color = inputColor;
			yield return new WaitForSeconds(0.0f);
		}
	}
	public void callFadeOut(GameObject inputGameObject) {
		StartCoroutine ("fadeOut", inputGameObject);
	}
}