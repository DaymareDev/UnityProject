using UnityEngine;
using System.Collections;

public class MasterServer : MonoBehaviour {
	
	private string _ip;
	private int _port;
	private string _serverName;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{
		GUI.Box(new Rect(10 ,10,500	,500), "Server Menu");
		GUI.Button(new Rect(200,100,150,50),"Connect to Server");
		GUI.TextField(new Rect(200,250,50,20),"Port");
		GUI.Button(new Rect(200,300,150,50),"Start Server");
		
	}
}
