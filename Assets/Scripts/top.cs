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
				if(roomUser.answerFlag){
					Application.LoadLevel("paint");
				}else{
					Application.LoadLevel("answor");
				}
			});
		});
	}

}
