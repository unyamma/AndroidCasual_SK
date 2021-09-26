using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI; I can use sprites instead of

[CreateAssetMenu(fileName = "MushroomObj", menuName = "MushroomScriptableObj", order = 51)]
public class MushroomObj : ScriptableObject
{
    public string Name = "Mushroom_Name";
    public bool edible = true;
    public float good_tempo = 500.0f;
    public float poison = 1.2f;
    public float satiety = 0.2f;
    //public float p_size_var = 12f;
    public GameObject prefab;
    public Sprite sprite;
    //public Image image; I can use sprites instead of
}
