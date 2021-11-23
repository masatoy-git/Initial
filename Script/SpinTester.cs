using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinTester : MonoBehaviour
{
    public float WindSpeedLow = 8.0f;
    public float WindSpeedHigh = 10.0f;
    public float WindRangeLow = 1.5f;
    public float WindRangeHigh = 2.5f;
    public bool isGrass = false;
    float WindSpeed,WindRange;
    float cnt = 1;
    float a;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, cnt);
        cnt+= 15 * Time.deltaTime;
    }
}
