using UnityEngine;
using System.Collections;

public class ServerAdmin : MonoBehaviour {
	
	public string ip;
	public int port;
	public string serverName = "Unity Test";
	public string gameTypeName = "MMTest123";
	
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
		
		if(GUI.Button(new Rect(200,300,150,50),"Start Server"))
		{
			Network.InitializeServer(10,25002, !Network.HavePublicAddress()); //// if we need NAT it will use it.
			MasterServer.RegisterHost (gameTypeName, serverName, "Test Unity Network");
		}
		
	}
}
