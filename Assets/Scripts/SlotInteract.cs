using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotInteract : MonoBehaviour
{
    public Inventory inventory;
    public int i;
    public Transform parent;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Update()
    {
        if (parent.childCount == 0)
        {
            inventory.isFull[i] = false;
        }
    }
    public void DropItem()
    {

        foreach (Transform child in parent)
        {
            //GameObject mushroom = child;
            GameObject p = Instantiate<GameObject>(child.GetComponent<Mushroom>().reference.prefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 3), child.GetComponent<Mushroom>().reference.prefab.transform.rotation);
            p.GetComponent<Mushroom>().reference = child.GetComponent<Mushroom>().reference;
            p.GetComponent<Mushroom>().poison = child.GetComponent<Mushroom>().poison;
            p.GetComponent<Mushroom>().friedon = child.GetComponent<Mushroom>().friedon;
            p.GetComponent<Mushroom>().tempo_need = child.GetComponent<Mushroom>().tempo_need;
            p.GetComponent<Mushroom>().satiety = child.GetComponent<Mushroom>().satiety;
            Destroy(child.gameObject);
        }
    }

    public void DropItem(bool clone)
    {

        foreach (Transform child in parent)
        {
            //GameObject mushroom = child;
            if (clone && child.gameObject.GetComponent<Mushroom>())
            {
                GameObject p = Instantiate<GameObject>(child.GetComponent<Mushroom>().reference.prefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 3), child.GetComponent<Mushroom>().reference.prefab.transform.rotation);
                p.GetComponent<Mushroom>().reference = child.GetComponent<Mushroom>().reference;
                p.GetComponent<Mushroom>().poison = child.GetComponent<Mushroom>().poison;
                p.GetComponent<Mushroom>().friedon = child.GetComponent<Mushroom>().friedon;
                p.GetComponent<Mushroom>().tempo_need = child.GetComponent<Mushroom>().tempo_need;
                p.GetComponent<Mushroom>().satiety = child.GetComponent<Mushroom>().satiety;
            }
            else if (clone && child.gameObject.GetComponent<Fuel>())
            {
                GameObject p = Instantiate<GameObject>(child.gameObject.GetComponent<Fuel>().prefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 3), child.GetComponent<Fuel>().prefab.gameObject.transform.rotation);
            }
            Destroy(child.gameObject);
        }
    }

    public void Feed()
    {
        if (parent.childCount == 0) { return; }
        if (parent.GetChild(0).gameObject.GetComponent<Mushroom>())
        {
            float dis_zone = Vector2.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, GameObject.FindGameObjectWithTag("KidsZone").transform.position);
            float dis_camp = Vector2.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, GameObject.FindGameObjectWithTag("CampZone").transform.position);
            if (dis_zone <= dis_camp && dis_zone < 4f)
            {
                //Debug.Log("Rected to kids zone");
                GameObject.FindGameObjectWithTag("KidsZone").GetComponent<Level>().feed(parent.GetChild(0).gameObject.GetComponent<Mushroom>());
                DropItem(false);

            }
            else if (dis_camp <= dis_zone && dis_camp < 4f)
            {
                if (GameObject.FindGameObjectWithTag("CampZone").GetComponent<Campfire>().check_mushm == true) { return; }
                GameObject.FindGameObjectWithTag("CampZone").GetComponent<Campfire>().fry(parent.GetChild(0).gameObject.GetComponent<Mushroom>());
                DropItem(false);
                //Debug.Log("Rected to campfire");
            }
            else
            {
                //Debug.Log("Interact ignored");
            }
        }
        else
        {
            float dis_camp = Vector2.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, GameObject.FindGameObjectWithTag("CampZone").transform.position);
            if (dis_camp <= 4f)
            {
                GameObject.FindGameObjectWithTag("CampZone").GetComponent<Campfire>().seconds += parent.GetChild(0).gameObject.GetComponent<Fuel>().seconds;
                DropItem(false);
            }
        }
    }
 
}
