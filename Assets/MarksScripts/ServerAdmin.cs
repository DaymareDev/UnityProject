using UnityEngine;
using System.Collections;

namespace UnityProject {

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
		
			if(MasterServer.PollHostList().Length != 0)
			{
				HostData[] hostData = MasterServer.PollHostList();
				int i = 0;
				while (i < hostData.Length)
				{
					Debug.Log("Game Name: " + hostData[i].gameName);
					i++;
				}
				MasterServer.ClearHostList();
			}
		}
		
		void OnGUI()
		{
			GUI.Box(new Rect(10 ,10,500	,500), "Server Menu");
			
			if(GUI.Button(new Rect(200,100,150,50),"Connect to Server"))
			{
				MasterServer.ClearHostList();
				MasterServer.RequestHostList(gameTypeName);
			}
			
			if(GUI.Button(new Rect(200,300,150,50),"Start Server"))
			{
				Network.InitializeServer(10,25002, !Network.HavePublicAddress()); //// if we need NAT it will use it.
				MasterServer.RegisterHost (gameTypeName, serverName, "Test Unity Network");
			}
			
		}
		
	}
}
