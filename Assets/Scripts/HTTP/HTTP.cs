using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class HTTP : SingletonBehavior<HTTP> {
	public static readonly string rootUrl = "https://ancient-brushlands-8910.herokuapp.com/";

	public enum Method{
		GET,
		POST
	}

	public void Request(string url, HTTP.Method method, Dictionary<string, string> param, Action<string> callback = null){
		WWW www = null;
		switch (method) {
			case Method.GET:
				string query = "";
				int counter = 0;
				foreach (KeyValuePair<String,String> kv in param) {
					counter++;
					query += kv.Key + "=" + kv.Value;
					if(counter != param.Count){
						query += "&";
					}
				}
				string getUrl = url + "?" + query;
				www = new WWW(getUrl);
				break;
			case Method.POST:
				WWWForm form = new WWWForm();
				foreach (KeyValuePair<String,String> kv in param) {
					form.AddField(kv.Key, kv.Value);
				}
				form.AddField("sample", "hoge");
				www = new WWW(url, form);
				break;
		}
		if (www == null) return;
		StartCoroutine(WaitForRequest(www, callback));
	}

	IEnumerator WaitForRequest(WWW www, Action<string> callback) {
		yield return www;
		if (www.error == null) {
			Debug.Log("WWW Ok!: ");
			callback(www.text);
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}
	}
}
