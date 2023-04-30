using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "dialouge_", menuName = "Dialouges/Cluster", order = 1)]
public class DialougeCluster : ScriptableObject
{
    public string dialougeName;
    public DialougePair[] dialougePairs;
}