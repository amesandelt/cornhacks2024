using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{

    [SerializeField] List<GameObject> objects;
    public GameObject loserMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int size = objects.Count;
        int i = 0;
        while (i < size)
        {
            if (objects[i].transform.position.y < -2) 
            {

                loserMenu.SetActive(true); 
                break;
            

            } 
            i++;
        }
       
    }
}
