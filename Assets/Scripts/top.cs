﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class top : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onClick(){
		UserModel.Login ((UserModel user) => {
			GameController.Instance.User = user;
			RoomUserModel.Join((RoomUserModel roomUser) =>{
				//TODO devide Scene
				GameController.Instance.RoomUser = roomUser;
				Debug.LogError("id:"+roomUser.id);
				Debug.LogError("answerFlag:"+(roomUser.answerFlag));
				Debug.LogError("count:"+roomUser.drawingCount);
				if(roomUser.answerFlag){
					Application.LoadLevel("answor");
				}else{
					Application.LoadLevel("paint");
				}
			});
		});
	}

}
