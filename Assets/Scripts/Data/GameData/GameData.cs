using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    public int ryba1Count;
    public int ryba2Count;
    public int ryba3Count;
    public int ryba4Count;
    public int ryba5Count;
    public int ryba6Count;
    public int ryba7Count;
    public int ryba8Count;
    public int ryba9Count;
    public int ryba10Count;
    public int ryba11Count;
    public int ryba12Count;
    public int ryba13Count;
    public int ryba14Count;
    public int ryba15Count;

    public bool ryba1;
    public bool ryba2;
    public bool ryba3;
    public bool ryba4;
    public bool ryba5;
    public bool ryba6;
    public bool ryba7;
    public bool ryba8;
    public bool ryba9;
    public bool ryba10;
    public bool ryba11;
    public bool ryba12;
    public bool ryba13;
    public bool ryba14;
    public bool ryba15;

    public bool World2Unlocked;
    public bool World3Unlocked;

    public GameData()
    {
        ryba1Count = 0; //Pozdeji bude pravdepodobne potreba zmenit hodnoty ryba1Count, ... v jejich scriptech
        ryba2Count = 0;
        ryba3Count = 0;
        ryba4Count = 0;
        ryba5Count = 0;
        ryba6Count = 0;
        ryba7Count = 0;
        ryba8Count = 0;
        ryba9Count = 0;
        ryba10Count = 0;
        ryba11Count = 0;
        ryba12Count = 0;
        ryba13Count = 0;
        ryba14Count = 0;
        ryba15Count = 0;

        ryba1 = false;
        ryba2 = false;
        ryba3 = false;
        ryba4 = false;
        ryba5 = false;
        ryba6 = false;
        ryba7 = false;
        ryba8 = false;
        ryba9 = false;
        ryba10 = false;
        ryba11 = false;
        ryba12 = false;
        ryba13 = false;
        ryba14 = false;
        ryba15 = false;

        World2Unlocked = false;
        World3Unlocked = false;
    }
}
