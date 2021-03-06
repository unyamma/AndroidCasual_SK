using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Campfire : MonoBehaviour
{
    public float tempo_pm = 360f;
    public Mushroom mushroom = null;
    public bool check_mushm = false;
    public TextMeshProUGUI text;
    public float seconds = 0f;
    public void fry(Mushroom mushm)
    {
        //mushroom = mushm;
        mushroom.reference = mushm.reference;
        mushroom.poison = mushm.poison;
        mushroom.friedon = mushm.friedon;
        mushroom.tempo_need = mushm.tempo_need;
        mushroom.satiety = mushm.satiety;
        check_mushm = true;
    }

    public void takeoff()
    {
        if (!check_mushm) { return; }
        GameObject p = Instantiate<GameObject>(mushroom.reference.prefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 3), mushroom.reference.prefab.transform.rotation);
        p.GetComponent<Mushroom>().reference = mushroom.reference;
        p.GetComponent<Mushroom>().poison = mushroom.poison;
        p.GetComponent<Mushroom>().friedon = mushroom.friedon;
        p.GetComponent<Mushroom>().tempo_need = mushroom.tempo_need;
        p.GetComponent<Mushroom>().satiety = mushroom.satiety;
        //mushroom = null;
        check_mushm = false;
    }

    public void FixedUpdate()
    {
        if (check_mushm == true)
        {
            //
            if (seconds >= Time.deltaTime)
            {
                mushroom.friedon += tempo_pm / 60 * Time.deltaTime;
                seconds -= Time.deltaTime;
            }
            //double foD = (double)mushroom.friedon;
            //double gtD = (double)mushroom.reference.good_tempo;
            text.text = ((int)mushroom.friedon) + "/" + ((int)mushroom.reference.good_tempo);
            if (mushroom.friedon > mushroom.friedon + mushroom.friedon / 2)
            {
                check_mushm = false;
            }
        }
        else
        {
            text.text = "N/A";
        }
    }
}
