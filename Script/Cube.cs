using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //UIの動きテストくん
        /*
        追加
        不必要
        if(Input.GetKeyDown(KeyCode.Space)){
            GameObject UICanvas = GameObject.FindGameObjectWithTag("UICanvas");
            GameManager nanikore = UICanvas.GetComponent<GameManager>();
            nanikore.AFKBarEffect(1);
        }
        if(Input.GetKeyDown(KeyCode.Return)){
            GameObject UICanvas = GameObject.FindGameObjectWithTag("UICanvas");
            GameManager nanikore = UICanvas.GetComponent<GameManager>();
            nanikore.AFKBarEffect(2);
        }*/
    }
}
