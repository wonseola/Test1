using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackColor : MonoBehaviour
{

    public GameObject[] Cube;
    public Material[] materials;
    public float movementSpeed;

    Material materi1;
    Material materi2;
    GameObject c11;
    GameObject c22;
    Material materi11;
    Material materi22;
    GameObject c111;

    private bool clicked;
    bool check;




    void Start()
    {



    }


    void Update()
    {




        if (materi1 == materi2)
        {
            CubeColorRandom();
        }
        if (materi1 != materi2)
        {

            ColorChange();



        }


        CameraMove();

        FlyingCube();

  



    }













    void CubeColorRandom() //색 랜덤~~~
    {

        materi1 = materials[Random.Range(0, materials.Length)];
        materi2 = materials[Random.Range(0, materials.Length)];



        Debug.Log(materi1);
        Debug.Log(materi2);

        int a = Random.Range(1, Cube.Length);



        for (int A = 0; A <= a; A++)
        {
            c11 = Cube[A];
            c11.gameObject.GetComponent<Renderer>().material = materi1;

        }


        for (int B = a; B < Cube.Length; B++)
        {

            c22 = Cube[B];
            c22.gameObject.GetComponent<Renderer>().material = materi2;

        }



    }



    void ColorChange()    //누르면 색 바뀌기
    {


        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //Debug.Log(Input.mousePosition);

            

            if (Physics.Raycast(ray, out hit))
            {

                if (hit.collider.tag == "Cube1")
                {



                    if (!clicked)
                    {
                        hit.collider.gameObject.GetComponent<Renderer>().material = materi1;
                        clicked = true;
                    }

                    else
                    {
                        hit.collider.gameObject.GetComponent<Renderer>().material = materi2;
                        clicked = false;
                    }



                    //if (!clicked)
                    //{
                    //    hit.collider.gameObject.GetComponent<Renderer>().material = materi1;
                    //    clicked = true;
                    //}

                    //else
                    //{
                    //    hit.collider.gameObject.GetComponent<Renderer>().material = materi2;
                    //    clicked = false;
                    //}



                }

                else
                {
                    Debug.Log("큐브아님");
                }

              

            }





        }






    }

    void CameraMove() //카메라 밖으로 안 가게
    {

        for (int i = 0; i < Cube.Length; i++)
        {
            Vector3 pos = Camera.main.WorldToViewportPoint(Cube[i].transform.position);

            if (pos.x < 0.1f) pos.x = 0.1f;
            if (pos.x > 0.9f) pos.x = 0.9f;
            if (pos.y < 0.1f) pos.y = 0.1f;
            if (pos.y > 0.9f) pos.y = 0.9f;

            Cube[i].transform.position = Camera.main.ViewportToWorldPoint(pos);
        }
    }



    void FlyingCube() //큐브 움직이게 막!!!!!!!!!!!!
    {

        float b = Random.Range(1f, 5f);

        float bbb = Random.Range(1f, 5f);

        for (int i = 0; i < Cube.Length; i++)
        {
            Cube[i].GetComponent<Rigidbody>().AddForce(b,0,0);



            Vector3 pos = Cube[i].transform.localPosition;

        

            if (pos.x<0)
            {
                Cube[i].GetComponent<Rigidbody>().AddForce(movementSpeed, bbb, 0);
                Cube[i].transform.Rotate(new Vector3(Random.Range(0f,10f), 10, 0) * Time.deltaTime);
                
            }

            if (pos.x>0)
            {
                Cube[i].GetComponent<Rigidbody>().AddForce(-movementSpeed, -bbb, 0);
                Cube[i].transform.Rotate(new Vector3(Random.Range(0f, 10f), 10, 10)*Time.deltaTime);

            }

           if (pos.y < 0)
            {
                Cube[i].GetComponent<Rigidbody>().AddForce(-bbb, movementSpeed, 0);
                Cube[i].transform.Rotate(new Vector3(0, Random.Range(0f, 10f), 10) * Time.deltaTime);

            }

            else
            {
                Cube[i].GetComponent<Rigidbody>().AddForce(-bbb, -movementSpeed, 0);
                Cube[i].transform.Rotate(new Vector3(10, 0, Random.Range(0f, 10f)) * Time.deltaTime);

            }

            //if (pos.y >0)
            //{
            //    Cube[i].GetComponent<Rigidbody>().AddForce(0, -movementSpeed, 0);
            //    Cube[i].transform.Rotate(new Vector3(10, 0, Random.Range(0f, 10f)) * Time.deltaTime);

            //}





            //Debug.Log("------"+i+"========="+Cube[i].transform.localPosition);



        }




    }











}





