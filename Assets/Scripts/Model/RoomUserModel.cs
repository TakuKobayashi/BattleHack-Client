using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using LitJson;

public class RoomUserModel
{
    static readonly string ResourcePath = "room";
	public int id;
	public string title;
	public int drawingCount;
	public bool answerFlag;
	public PrevResult prev;
	public int repeatNumber;

	public struct PrevResult{
		public string answerWord;
		public string imagePath;
	}

	public static void Join(Action<RoomUserModel> onSuccess)
	{
		Dictionary<string, string> param = new Dictionary<string, string> ();
		param.Add ("authToken", PlayerPrefs.GetString("authToken"));
		HTTP.Instance.Request(HTTP.rootUrl + ResourcePath + "/join", HTTP.Method.GET, param,(string response) => {
			RoomUserModel roomUser = JsonMapper.ToObject<RoomUserModel>(response);
			if(onSuccess != null) onSuccess(roomUser);			
		});
	}
}
