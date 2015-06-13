using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SendAnswer : MonoBehaviour {


public GameObject TextBox;
private string AnswerText;

	// Use this for initialization
	void Start () {
		
		
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	public void onClick(){
		Debug.Log ("click");
		Dictionary<string, string> param = new Dictionary<string, string> ();
		//TODO Settings
		param.Add ("roomUserId", "1");
		param.Add ("answer", "hogehoge");
		HTTP.Instance.Request (HTTP.rootUrl + "room/answer", HTTP.Method.GET, param,(string response) => {
			Debug.Log ("success");
		});
    }
	
	
}
