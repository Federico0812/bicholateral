using UnityEngine;
using System.Collections;

public class BehaviorFollow : MonoBehaviour {


	public GameObject followItem;
	public float movingvalue;
	public int counter;

	public Renderer rend;

	// Use this for initialization
	void Start () {

		rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
		//MIRAR JUGADOR
		Vector3 vectorItem = followItem.transform.position;
		Vector3 vectorSelf = transform.position;
		Vector3 direction = new Vector3(vectorItem.x - vectorSelf.x, vectorItem.y - vectorSelf.y, vectorItem.z - vectorSelf.z);
		direction.Normalize();

		float anglehorizontal = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + 180;

		float anglevertical = Mathf.Atan(direction.y) * Mathf.Rad2Deg + 90;
	
		transform.rotation = Quaternion.Euler(90, anglehorizontal,0);


		//CAMBIAR TEXTURA
		if (anglehorizontal < 45.0f) {
			rend.material.mainTexture = Resources.Load ("bichoizq", typeof(Texture2D)) as Texture;
		} else if (anglehorizontal > 360.0f - 45.0f) {
			rend.material.mainTexture = Resources.Load ("bichoizq", typeof(Texture2D)) as Texture;
		} else if (anglehorizontal > 135.0f && anglehorizontal < 225.0f) {
			rend.material.mainTexture = Resources.Load ("bichoder", typeof(Texture2D)) as Texture;
		} else if (anglehorizontal > 45.0f && anglehorizontal < 135.0f) {
			rend.material.mainTexture = Resources.Load ("bichoback", typeof(Texture2D)) as Texture;
		} else {
			rend.material.mainTexture = Resources.Load ("bicho", typeof(Texture2D)) as Texture;
		}


	}
}
