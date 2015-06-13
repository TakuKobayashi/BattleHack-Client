using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using LitJson;

public class UserModel
{
    static readonly string ResourcePath = "user";
    public int id;
	public string name;
    public string authToken;

	public static void Login(Action<UserModel> onSuccess)
	{
		Dictionary<string, string> param = new Dictionary<string, string> ();
		param.Add ("authToken", PlayerPrefs.GetString("authToken"));
		HTTP.Instance.Request(HTTP.rootUrl + ResourcePath + "/create", HTTP.Method.GET, param,(string response) => {
			Debug.Log ("success");
			UserModel user = JsonMapper.ToObject<UserModel>(response);
			if(onSuccess != null) onSuccess(user);			
		});
	}
}
