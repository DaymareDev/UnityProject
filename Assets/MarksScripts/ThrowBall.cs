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
				networkView.RPC("HoldBall",RPCMode.All );	
			}
		}
		
		[RPC]
		void HoldBall()
		{
			
			
			Debug.Log ("I am holding the ball");
			ball.rigidbody.velocity = Vector3.zero;
			ball.collider.enabled = false;
			ball.rigidbody.useGravity = false;
			ball.transform.parent = this.transform;
			ball.transform.localPosition = new Vector3(1,1,1);
			
			_holdingBall = true;
			
		}
		
		void Update()
		{
			if(_holdingBall)
				if(Input.GetMouseButtonDown(0))
				{
					networkView.RPC("ThrowMyBall",RPCMode.All);
				}
			
			if(Input.GetKeyDown(KeyCode.R))
			{
				ResetBall();
			}
		}
		
		[RPC]
		void ThrowMyBall()
		{
			Vector3 throwDirection = this.transform.forward;
			ball.transform.parent = null;
			ball.collider.enabled = true;
			ball.rigidbody.useGravity = true;
			ball.rigidbody.AddForce(throwDirection * 1000);
			_holdingBall = false;
		}
		
		void ResetHoldingBall()
		{
			ball.transform.parent = null;
			_holdingBall = false;
			Debug.Log ("The reset has been pressed!!!!!!!!!!!!!");
		}
			
			void ResetBall()
			{
				ball.collider.enabled = true;
				ball.rigidbody.useGravity = true;
				BroadcastMessage("ResetHoldingBall");
				ball.transform.position = _ballPosition;
				ball.rigidbody.velocity = Vector3.zero;
			}
		
	}
}

