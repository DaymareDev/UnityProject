using UnityEngine;
using System.Collections;

namespace UnityProject{
	
	public class ThrowBall : MonoBehaviour {
	
		private bool _holdingBall = false;
		
		 void OnCollisionEnter(Collision obj) 
		{
			print (obj.gameObject.name);
			if(obj.gameObject.name == "Ball")
			{
				HoldBall( obj.gameObject );	
			}
		}
		
		void HoldBall(GameObject obj)
		{
			obj.transform.parent = this.transform;
		}
	}
}
