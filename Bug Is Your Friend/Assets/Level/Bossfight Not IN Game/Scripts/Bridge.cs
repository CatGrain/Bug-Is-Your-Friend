using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public float destroyTime;
    public BridgeStone[] bridgeStones;
    
    public bool test;

    private void Start()
    {
        bridgeStones = GetBridgeStones();
    }

    private void Update()
    {
        if (test)
            DestroyBridge();
            test = false;

    }

    BridgeStone[] GetBridgeStones()
    {
        int childCount = transform.childCount;
        BridgeStone[] bridgeStones = new BridgeStone[childCount];

        for (int i = 0; i < childCount; i++)
        {
            bridgeStones[i] = transform.GetChild(i).GetComponent<BridgeStone>();
        }

        return bridgeStones;
    }

    public void DestroyBridge()
    {
        if (bridgeStones != null)
        {
            float time = destroyTime;
            foreach (var item in bridgeStones)
            {
                item.DestroyStone(time);
                time += 1;
            }
        }
    }

}
