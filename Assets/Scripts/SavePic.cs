using UnityEngine;
using System;
using System.IO;
using System.Collections;

public class SavePic : MonoBehaviour {
    
    public GameObject tempTexture;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    

    public void onClick(){
        Texture2D tex = tempTexture.transform.GetComponent<GUITexture>().texture as Texture2D;
        byte [] pngData = tex.EncodeToPNG();   // pngのバイト情報を取得.

        // pngファイル保存.
        File.WriteAllBytes("./tmp.png", pngData);

        // シーン遷移
        Application.LoadLevel("result");
    }


    
}
