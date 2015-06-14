using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class SendAnswer : MonoBehaviour {


public GameObject TextBox;
private string AnswerText;
	private string image;

	// Use this for initialization
	void Start () {
		Debug.LogError (GameController.Instance.RoomUser.prev.imagePath);
		image = GameController.Instance.RoomUser.prev.imagePath;
		byte [] bs = System.Convert.FromBase64String(image);
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
