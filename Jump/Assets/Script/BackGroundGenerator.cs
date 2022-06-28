using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    private float height; // 배경의 가로 길이
    public GameObject[] BackGround;
    public GameObject platformPrefab;
    private GameObject[] platforms;
    public int floor = 3;
    Vector2 CloudRange;
    int Count = 0;

    void Start()
    {
        player = GameObject.Find("cat");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Count <= 10)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    RandomCreatCloud(j);
                }

                Count++;
            }
        }

        if (player.transform.position.y >= 5 && floor == 3)
        {
            GameObject Background = Instantiate(BackGround[floor]);
            Background.transform.Translate(new Vector2());
            Background.SetActive(true);

            for (int i = 0; i < 5; i++)
            {
                
                 RandomCreatCloud(floor);
            }
            CreatCloud(floor);

            floor++;
        }
        if (player.transform.position.y >= 11 && floor == 4)
        {
            GameObject plaform = Instantiate(BackGround[floor]);
            plaform.transform.Translate(new Vector2());
            plaform.SetActive(true);

            for (int i = 0; i < 5; i++)
            {
                
                RandomCreatCloud(floor);
            }
            CreatCloud(floor);

            floor++;
        }
        if (player.transform.position.y >= 21 && floor == 5)
        {
            GameObject plaform = Instantiate(BackGround[floor]);
            plaform.transform.Translate(new Vector2());
            plaform.SetActive(true);

            for (int i = 0; i < 4; i++)
            {
                
                RandomCreatCloud(floor);
            }
            CreatCloud(floor);

            floor++;
        }
        if (player.transform.position.y >= 31 && floor == 6)
        {
            GameObject plaform = Instantiate(BackGround[floor]);
            plaform.transform.Translate(new Vector2());
            plaform.SetActive(true);

            for (int i = 0; i < 3; i++)
            {
                 RandomCreatCloud(floor);
            }

            CreatCloud(floor);

            floor++;
        }
    }

    void RandomCreatCloud(int i)
    {
        BoxCollider2D BackGroundRange = BackGround[i].GetComponent<BoxCollider2D>();
        GameObject platform = Instantiate(platformPrefab);
        platform.transform.Translate(new Vector2(Random.Range(BackGround[i].transform.position.x - BackGroundRange.size.x / 3, 
        BackGround[i].transform.position.x + BackGroundRange.size.x / 3), 
        Random.Range(BackGround[i].transform.position.y - BackGroundRange.size.y / 4, 
        BackGround[i].transform.position.y + BackGroundRange.size.y)));

        if(platform.transform.position.y >= 60 || platform.transform.position.y <= -12)
        {
            platform.SetActive(false);
        }
    }

    void CreatCloud(int i)
    {

        BoxCollider2D BackGroundRange = BackGround[i].GetComponent<BoxCollider2D>();
        float Lectleft = BackGround[i].transform.position.x - BackGroundRange.size.x / 3;
        float Lectdown = BackGround[i].transform.position.y - BackGroundRange.size.y / 2;
        float left = 0;
        float down = 0;
        for (int j = 0; j < 14; j+=2)
        {
            
            GameObject platform = Instantiate(platformPrefab);

            if(j < 10)
            {
                left = Lectleft + j;
                down = Lectdown + j - 1;
            }
            else
            {
                left = Lectleft + 16 - j;
                down = Lectdown + j- 2.5f;
            }

            platform.transform.Translate(new Vector2(left, down));
        }

    }

}


