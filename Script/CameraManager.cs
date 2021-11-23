using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    //スクロールリミット
    public float leftLimit = 0.0f;
    public float rightLimit = 0.0f;
    public float topLimit = 0.0f;
    public float botLimit = 0.0f;

    //サブスクリーン
    public GameObject Back0;
    public GameObject Back1;
    public GameObject Back2;
    public GameObject Back3;
    public GameObject Back4;
    public GameObject Sky;

    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update(){

        //画面サイズ表示
        //Debug.Log("Screen Width : " + Screen.width);
        //Debug.Log("Screen Height : " + Screen.height);
        
        //Playerタグが付いたスプライトを探す
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if(player != null){
            //カメラの更新座標
            float x = player.transform.position.x;
            float y = player.transform.position.y;
            float z = transform.position.z;

            //移動制限
            if(x < leftLimit){x = leftLimit;}
            else if(x > rightLimit){x = rightLimit;}
            if(y < botLimit){y = botLimit;}
            else if(y > topLimit){y = topLimit;}

            //カメラの位置を設定
            transform.position = new Vector3(x,y,z);

            Back0.transform.position = new Vector3( (x/3.0f) - 0.3f, Back0.transform.position.y, z);
            Back1.transform.position = new Vector3(x/2.5f, Back1.transform.position.y, z);
            Back2.transform.position = new Vector3(x/1.8f, Back2.transform.position.y, z);
            Back3.transform.position = new Vector3(x/1.5f, Back3.transform.position.y, z);
            Back4.transform.position = new Vector3(x, Back4.transform.position.y, z);
            Sky.transform.position = new Vector3(x/1.1f, (y/1.1f) - 4.0f, z);
        }
    }
}
