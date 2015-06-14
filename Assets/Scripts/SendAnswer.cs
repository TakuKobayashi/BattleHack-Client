using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


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
		param.Add ("roomUserId", GameController.Instance.RoomUser.id.ToString());
		//回答
		string message = TextBox.GetComponent<InputField>().text;
		param.Add ("answer", message);
		HTTP.Instance.Request (HTTP.rootUrl + "room/answer", HTTP.Method.GET, param,(string response) => {
			Debug.Log ("success");
		});
        
        // シーン遷移
        Application.LoadLevel("result");
    }
	
	
}
