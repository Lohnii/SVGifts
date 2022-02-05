using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UniversalOpinionsSO", menuName = "StardewValleyGiftsUnity/UniversalOpinionsSO")]
public class UniversalOpinionsSO : ScriptableObject {

    public GiftType giftType;
    public List<Items> items;
}