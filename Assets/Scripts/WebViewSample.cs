using UnityEngine;
using System.Collections;

public class WebViewSample : MonoBehaviour {
  private string url = "https://www.google.co.jp/";
  WebViewObject webViewObject;
  
  // Use this for initialization
  void Start () {
      webViewObject = (new GameObject("WebViewObject")).AddComponent<WebViewObject>();
      webViewObject.Init((msg) => {
          Debug.Log(msg);
      });
      webViewObject.LoadURL(url);
      webViewObject.SetMargins(0, 0, 0, 0);
      webViewObject.SetVisibility(true);
  }
}
