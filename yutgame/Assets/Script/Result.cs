using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
    public int result = 0;
    Rigidbody myRigid;
    // Start is called before the first frame update

    float AddJump;
    void Start()
    {
        //윷의 RigidBody 가져오기
        myRigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //윷의 y축 방향 속도가 0일때

         if(Input.GetMouseButton(0))
         {
                AddJump += 10 * Time.deltaTime;
                
         }

        //윷 위로 던지기  
         if (Input.GetMouseButtonUp(0) && myRigid.velocity.y == 0)
         {
                RandomDraw(AddJump);
                AddJump = 0;
         }

            //윷 회전 시키기
         if (transform.position.y >= 1.0f)
         {
                Cuberotate();
         }

        //윷의 로테이턴 x값을 가져와서 앞면인지 뒷면인지 판별
        float turn = transform.rotation.x;
        int Iturn = (int)turn;
        float absturn = Mathf.Abs(Iturn);

        if((absturn/90)%2 == 0)
        {
            result = 0;
        }
        else
        {
            result = 1;
        }

        //값을 로그로 출력
        Debug.Log(result);
    }

    void RandomDraw(float force)
    {
        if (force <= 6) { force = 6; }
        if (force >= 15) { force = 15; }
        myRigid.AddForce(0, 100 * force, 0 * Time.deltaTime);
        // myRigid.velocity = new Vector3(0, Random.Range(5000f, 4000f) * Time.deltaTime);

        Debug.Log(force);
    }

    void Cuberotate()
    {
        Vector3 dir = new Vector3(5f, 0f, 5f);
        transform.Rotate(dir * 20f * Time.deltaTime);

    }
}
