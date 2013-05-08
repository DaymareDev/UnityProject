using UnityEngine;
using System.Collections;

namespace UnityProject{
	
	public class ThrowBall : MonoBehaviour {
	
		private bool _holdingBall = false;
		public GameObject ball;
		
		void OnAwake()
		{
			ball = null;	
		}
		
		 void OnControllerColliderHit(ControllerColliderHit obj)  
		{
		
			if(obj.gameObject.name == "Ball" && !_holdingBall)
			{
				HoldBall( obj.gameObject );	
			}
		}
		
		void HoldBall(GameObject obj)
		{
			obj.rigidbody.useGravity = false;
			obj.transform.parent = this.transform;
			obj.transform.localPosition = new Vector3(1,1,1);
			
			_holdingBall = true;
			
			ball = obj;
		}
		
		void Update()
		{
			
			Vector3 throwDirection = this.transform.forward;
			
			if(_holdingBall)
				if(Input.GetMouseButtonDown(0))
				{
					ball.transform.parent = null;
					ball.rigidbody.useGravity = true;
					ball.rigidbody.AddForce(throwDirection * 1000);
				
				ball = null;
				_holdingBall = false;
				}
		}
	}
}
