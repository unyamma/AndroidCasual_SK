using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public Inventory inventory;
    public GameObject itemButton;
    public Mushroom mushm_db;
    public Fuel fuel_db;
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    GameObject Instance = Instantiate(itemButton, inventory.slots[i].transform, false);
                    if (mushm_db != null)
                    {
                        Instance.GetComponent<Mushroom>().randomize = false;
                        Instance.GetComponent<Mushroom>().friedon = mushm_db.friedon;
                        Instance.GetComponent<Mushroom>().tempo_need = mushm_db.tempo_need;
                        Instance.GetComponent<Mushroom>().poison = mushm_db.poison;
                        Instance.GetComponent<Mushroom>().satiety = mushm_db.satiety;
                        Instance.GetComponent<Mushroom>().reference = mushm_db.reference;
                    }
                    if (fuel_db != null)
                    {
                        Instance.GetComponent<Fuel>().randomize = false;
                        Instance.GetComponent<Fuel>().seconds = fuel_db.seconds;
                    }
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
