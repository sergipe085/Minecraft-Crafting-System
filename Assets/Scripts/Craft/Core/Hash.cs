using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Hash
{
   public string hashString = "";
   public int notNullCounter = 0;

    public Hash() {
        hashString = "";
        notNullCounter = 0;
    }

    public static bool CompareHashes(Hash mainHash, Hash toCompareHash) {
            if (mainHash.hashString.Contains(toCompareHash.hashString) && mainHash.notNullCounter == toCompareHash.notNullCounter) {
                return true;
            }
            return false;
    }
}
