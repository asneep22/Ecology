using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;

public class hight_upgrade : MonoBehaviour, IPointerClickHandler
{
    public List<Object> upgrades_array = new List<Object>();
    private GameObject random_upgrade;

    void Start()
    {
        reload_upgrade();
    }

    public void reload_upgrade()
    {
        if (random_upgrade != null)
        {
            Destroy(random_upgrade);
        }

        upgrades_array = Resources.LoadAll("hight_upgrade").ToList();
        random_upgrade = Instantiate((GameObject)upgrades_array[Random.Range(0, upgrades_array.Count)], transform);
        Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 5);
        random_upgrade.transform.position = position;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        buy_upgrade.upgrades_cell = transform;
    }
}
