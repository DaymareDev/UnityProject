using UnityEngine;
using System.Collections;

namespace UnityProject{
	
	public class ThrowBall : MonoBehaviour {
	
		private bool _holdingBall = false;
		public GameObject ball;
		private Vector3 _ballPosition;
		public float ballForce;
		private SphereCollider ballDetecter;
		private float ballTimer = 0;
		
		void Start()
		{
			ballDetecter = (SphereCollider) GetComponentInChildren<SphereCollider>();
			ball = GameObject.Find("Ball");	
			_ballPosition = ball.transform.position;
		}
		
		void OnControllerColliderHit(ControllerColliderHit obj)  
		{
			CheckWhatsHit(obj.gameObject);
		}
		
		public void CheckWhatsHit(GameObject obj)
		{
			if(ballTimer <= 0 && obj.name == "Ball" && !_holdingBall)
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
			
			ballTimer -= Time.deltaTime;
			
			if(_holdingBall)
				if(Input.GetMouseButtonDown(0))
				{
					Debug.Log("i am throwing the ball");
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
			ballTimer = 0.5f;
			ball.GetComponent<SphereCollider>().enabled = true;
			Vector3 throwDirection = this.transform.forward;
			ball.transform.parent = null;
			ball.collider.enabled = true;
			ball.rigidbody.useGravity = true;
			
			ball.rigidbody.AddForce(throwDirection * ballForce,ForceMode.Impulse);
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

