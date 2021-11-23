using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpinEffect : MonoBehaviour
{
    public float WindSpeedLow = 8.0f;
    public float WindSpeedHigh = 10.0f;
    public float WindRangeLow = 1.5f;
    public float WindRangeHigh = 2.5f;
    public bool isGrass = false;
    bool isShake = false;
    bool isShakeExit = true;
    bool GrassDirisRight = true;
    float WindSpeed,WindRange;
    float cnt,shake;
    GameObject TouchObj;

    // Start is called before the first frame update
    void Start()
    {
        cnt = Random.Range(0 ,360);
        WindSpeed = Random.Range( WindSpeedLow , WindSpeedHigh );
        WindRange = Random.Range( WindRangeLow , WindRangeHigh );
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrass && isShake){
            if(GrassDirisRight){transform.Rotate( new Vector3(0, 0, shake * (Time.deltaTime * 60.0f) ) );}
            else{transform.Rotate( new Vector3(0, 0, shake * (Time.deltaTime * 60.0f) ) );}
        }
        else{transform.rotation = Quaternion.Euler(0, 0, ((Mathf.Sin(cnt * WindSpeed)) * WindRange) - WindRange );}

        if(isShake){
            if(GrassDirisRight){
                shake += Time.deltaTime * 50.0f;
                if(shake > 10){isShake = false;}
            }
            else{
                shake -= Time.deltaTime * 50.0f;
                if(shake < -10){isShake = false;}
            }
        }
        if(!isShake && !isShakeExit){
            if( Vector3.Distance(transform.position , TouchObj.transform.position) > 2 ){
                isShakeExit = true;
            }
        }

        if(isGrass){cnt += 0.5f * Time.deltaTime;}
        else {cnt += 0.1f * Time.deltaTime;}
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Player" && isShakeExit){
            TouchObj = collision.gameObject;
            isShake = true;
            isShakeExit = false;
            if(transform.position.x > TouchObj.transform.position.x){
                shake = -10;
                GrassDirisRight = true;
            }
            else{
                shake = 10;
                GrassDirisRight = false;
            }
        }
    }
}
