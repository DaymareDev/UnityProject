using UnityEngine;
using System.Collections;

namespace UnityProject{
	
	public class ThrowBall : MonoBehaviour {
	
		private bool _holdingBall = false;
		public GameObject ball;
		private Vector3 _ballPosition;
		
		void Start()
		{
			ball = GameObject.Find("Ball");	
			_ballPosition = ball.transform.position;
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
			obj.transform.collider.enabled = false;
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
					ball.transform.collider.enabled = true;
				
				_holdingBall = false;
				}
			
			if(Input.GetKeyDown(KeyCode.R))
			{
				ResetBall();
			}
		}
		
		void ResetHoldingBall()
		{
			ball.transform.parent = null;
			_holdingBall = false;
			Debug.Log ("The reset has been pressed!!!!!!!!!!!!!");
		}
			
			void ResetBall()
			{
				ball.rigidbody.useGravity = true;
				BroadcastMessage("ResetHoldingBall");
				ball.transform.position = _ballPosition;
				ball.rigidbody.velocity = Vector3.zero;
				ball.collider.enabled = true;
			}
		
	}
}

