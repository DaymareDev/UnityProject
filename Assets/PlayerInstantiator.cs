using UnityEngine;
using System.Collections;

public class PlayerInstantiator : MonoBehaviour {

    public GameObject PlayerPrefab; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnConnectedToServer()
    {
        GameObject newPlayerCharacter = (GameObject) Network.Instantiate(PlayerPrefab, new Vector3(0,2,2), Quaternion.identity, 0);
        newPlayerCharacter.GetComponent<FPSInputController>().enabled = true;
        newPlayerCharacter.GetComponent<MouseLook>().enabled = true;
        GameObject.Find("Player Camera").GetComponent<SmoothFollow>().target = newPlayerCharacter.transform;

    }
}
