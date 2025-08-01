using System;
using UnityEngine;

public class Blueprint: MonoBehaviour
{
    public string itemName;
    public string Req1;
    public string Req2;

    public int Req1Amount;
    public int Req2Amount;

    public int numOfRequirements;

    public Blueprint(string name, int reqNUM, string R1, int R1NUM, String R2, int R2NUM)
    {
        itemName = name;

        numOfRequirements = reqNUM;

        Req1 = R1;
        Req2 = R2;

        Req1Amount = R1NUM;
        Req2Amount = R2NUM;
    }
}
