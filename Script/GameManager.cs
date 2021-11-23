using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //プレイヤー操作
    public GameObject inputUI;
    static public float Health, Level, Exp, Gold, Nex;

    public Text GoldText, LevelText, ExpNexText; //表示テキスト

    public GameObject ExpBar, Player, GoldBar;
    RectTransform ExpBarRec, GoldBarRec;

    // Start is called before the first frame update
    void Start()
    {
        Health = 20;
        Level = 1;
        Exp = 0;
        Gold = 13;
        Nex = 10;
        Player = GameObject.FindGameObjectWithTag("Player");
        ExpBarRec = ExpBar.GetComponent<RectTransform>();
        GoldBarRec = GoldBar.GetComponent<RectTransform>();
        ExpBarRec.anchoredPosition = new Vector2 (0, 393);
        GoldBarRec.anchoredPosition = new Vector2 (570, 0);
    }

    // Update is called once per frame
    void Update()
    {
        GoldText.text = string.Format("{0:}", Gold);
        LevelText.text = string.Format("{0:}", Level);
        ExpNexText.text = string.Format("{0:00}/{1:00}", Exp, Nex);
        //操作UI無効化
        //inputUI.SetActive(false);

        //ローカル座標基準値テスト(ゴミ)
        //ExpBar.transform.localPosition = new Vector2 (0,0);
        //ExpBar.GetComponent<RectTransform>().localPosition = new Vector2(0, -60.4f);
    }

    public void Jump(){
        PlayerController playerCnt = Player.GetComponent<PlayerController>();
        playerCnt.Jump();
    }

    public void AFKBarEffect(int mode){
        if(mode == 1){
            StartCoroutine( CorAFK() );
        }
        else{
            StartCoroutine( CorBack() );
        }
        IEnumerator CorAFK(){
            for(int i = 15; i > 0; i--){
                ExpBar.transform.Translate ( 0, -0.025f * i, 0);
                GoldBar.transform.Translate ( -0.035f * i, 0, 0);
                yield return new WaitForSeconds(0.02f);
            }
        }
        IEnumerator CorBack(){
            for(int i = 1; i < 15; i++){
                ExpBar.transform.Translate ( 0, 0.025f * i, 0);
                GoldBar.transform.Translate ( 0.035f * i, 0, 0);
                yield return new WaitForSeconds(0.02f);
            }
            ExpBarRec.anchoredPosition = new Vector2 (0, 393);
            GoldBarRec.anchoredPosition = new Vector2 (570, 0);
        }
    }
}