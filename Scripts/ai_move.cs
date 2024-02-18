using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ai_move : MonoBehaviour
{

    NavMeshAgent agent;

    [SerializeField] LayerMask groundLayer;
    [SerializeField] List<GameObject> gameObjects;
    [SerializeField] Transform gary_pos;
    [SerializeField] List<GameObject> power_ups_money;
    [SerializeField] List<GameObject> power_ups_vis;


    public GameObject loserMenu;

    [SerializeField] int pow_rad;
    [SerializeField] int obj_rad;
    //random

    Vector3 destPnt;
    bool walkpoint;
    [SerializeField] float walkrange;
    [SerializeField] NavMeshAgent speed;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        Walk();

        int i = 0;
        int list_len = power_ups_money.Count;
        while (i < list_len)
        {

            if ((Mathf.Abs(power_ups_money[i].transform.position.x - gary_pos.position.x) < pow_rad) && (Mathf.Abs(power_ups_money[i].transform.position.z - gary_pos.position.z) < pow_rad))
            {
                if ((Mathf.Abs(power_ups_money[i].transform.position.x - gary_pos.position.x) < 1) && (Mathf.Abs(power_ups_money[i].transform.position.z - gary_pos.position.z) < 1))
                {
                    speed.speed = 2 * speed.speed;
                    GameObject x = power_ups_money[i];
                    power_ups_money.RemoveAt(i);
                    Searchdest();
                    Destroy(x);
                    break;
                }
                else
                {


                    walkpoint = true;
                    agent.SetDestination(new Vector3(power_ups_money[i].transform.position.x, power_ups_money[i].transform.position.y, power_ups_money[i].transform.position.z));
                    break;
                }
            }
            else
            {
                i++;
            }
        }

         

        i = 0;
        list_len = power_ups_vis.Count;
        while (i < list_len)
        {

            if ((Mathf.Abs(power_ups_vis[i].transform.position.x - gary_pos.position.x) < pow_rad) && (Mathf.Abs(power_ups_vis[i].transform.position.z - gary_pos.position.z) < pow_rad))
            {
                if ((Mathf.Abs(power_ups_vis[i].transform.position.x - gary_pos.position.x) < 1) && (Mathf.Abs(power_ups_vis[i].transform.position.z - gary_pos.position.z) < 1))
                {
                    obj_rad = obj_rad *2;
                    GameObject x = power_ups_vis[i];
                    power_ups_vis.RemoveAt(i);
                    Searchdest();
                    Destroy(x);
                    break;
                }
                else
                {


                    walkpoint = true;
                    agent.SetDestination(new Vector3(power_ups_vis[i].transform.position.x, power_ups_vis[i].transform.position.y, power_ups_vis[i].transform.position.z));
                    break;
                }
            }
            else
            {
                i++;
            }
        }

        i = 0;
        list_len = gameObjects.Count;
        while (i < list_len)
        {

            if ((Mathf.Abs(gameObjects[i].transform.position.x - gary_pos.position.x) < obj_rad) && (Mathf.Abs(gameObjects[i].transform.position.z - gary_pos.position.z) < obj_rad))
            {
                if ((Mathf.Abs(gameObjects[i].transform.position.x - gary_pos.position.x) < 1) && (Mathf.Abs(gameObjects[i].transform.position.z - gary_pos.position.z) < 1))
                {
                    loserMenu.SetActive(true);
                    break;
                }

                walkpoint = true;
                agent.SetDestination(new Vector3(gameObjects[i].transform.position.x, gameObjects[i].transform.position.y, gameObjects[i].transform.position.z));
                break;
            }
            else
            {
                i++;
            }
        }

    }

    void Walk()
    {
        if (!walkpoint) Searchdest();
        if (walkpoint) agent.SetDestination(destPnt);
        if (Vector3.Distance(transform.position, destPnt) < 10) walkpoint = false;

    }

    void Searchdest()
    {
        float y = Random.Range(-walkrange, walkrange);
        float x = Random.Range(-walkrange, walkrange);

        destPnt = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + y);

        if (Physics.Raycast(destPnt, Vector3.down, groundLayer))
        {
            walkpoint = true;
        }



    }

}
