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
            mushroom.friedon += tempo_pm / 60 * Time.deltaTime;
            text.text = mushroom.friedon + "/" + mushroom.reference.good_tempo;
        }
        else
        {
            text.text = "N/A";
        }
    }
}
