using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public float satiety = 1f;
    public MushroomObj reference;//Mushroom reference from mushroom will be "copied"
    public float friedon = 0f;//Stores how much mush-m fried now
    public float tempo_need = 500.0f;//Temparature which need be got to fry mush-m
    public float poison = 0f;
    public bool randomize = true; // MUST be disabled on UI's
    //public bool edible = true;It's copy of reference so as well as name will n't stored in script
    // public float p_size_var;Useless

    void Start()
    {
        if (!randomize) { return; }
        tempo_need = reference.good_tempo + Random.Range(reference.good_tempo / 3 * -1, reference.good_tempo / 3);//Lil bt o'ran-m
        poison = reference.poison + Random.Range(reference.poison * -1, reference.poison / 3);
        satiety = reference.satiety + Random.Range(reference.satiety /2 *-1,  reference.satiety / 2);
        gameObject.GetComponent<SpriteRenderer>().sprite = reference.sprite;
        //edible = reference.edible; Useless
        //p_size_var = reference.p_size_var; USELESS
    }
}
