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
        //���� RigidBody ��������
        myRigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //���� y�� ���� �ӵ��� 0�϶�

         if(Input.GetMouseButton(0))
         {
                AddJump += 10 * Time.deltaTime;
                
         }

        //�� ���� ������  
         if (Input.GetMouseButtonUp(0) && myRigid.velocity.y == 0)
         {
                RandomDraw(AddJump);
                AddJump = 0;
         }

            //�� ȸ�� ��Ű��
         if (transform.position.y >= 1.0f)
         {
                Cuberotate();
         }

        //���� �������� x���� �����ͼ� �ո����� �޸����� �Ǻ�
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

        //���� �α׷� ���
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
