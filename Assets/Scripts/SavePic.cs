using UnityEngine;
using System;
using System.IO;
using System.Collections;
using UnityEngine.UI;

public class SavePic : MonoBehaviour {
    
    public GameObject tempTexture;
	public GameController gameController;
	public Text text;

	// Use this for initialization
	void Start () {
		text.text = GameController.Instance.RoomUser.title;
	}
	
	// Update is called once per frame
	void Update () {

	}

    

    public void onClick(){
        Texture2D tex = tempTexture.transform.GetComponent<GUITexture>().texture as Texture2D;
        byte [] pngData = tex.EncodeToPNG();   // pngのバイト情報を取得.

		//Base64で文字列に変換
		string base64String;
		base64String = System.Convert.ToBase64String(pngData);

        // pngファイル保存.
        File.WriteAllBytes("./tmp.png", pngData);

        // シーン遷移
        Application.LoadLevel("result");
    }
   
}
