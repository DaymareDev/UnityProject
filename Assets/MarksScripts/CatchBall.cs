using UnityEngine;
using System.Collections;

namespace UnityProject{

	public class CatchBall : MonoBehaviour {
		
		public ThrowBall throwBall;
		
		// Use this for initialization
		void Awake () {
			throwBall = (ThrowBall) transform.parent.GetComponent<ThrowBall>();
		}
		
		void OnTriggerEnter(Collider obj)
		{
			Debug.Log("i have hit" + obj.gameObject.name);
			throwBall.CheckWhatsHit(obj.gameObject);
		}
	}
}
