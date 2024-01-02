using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Animator ani;
    private Rigidbody rbody;
    private int RoadNum=2;//��ʼ�ڵڶ���·
    private float velocity=20;//��ʼ�ٶ�
    bool IsJumpZone;
    public GameObject GameOverUI;
    private bool IsSlope=false;//�Ƿ�����
    public bool highJump ;//�Ƿ�����
    void Start()
    {
        ani = GetComponent<Animator>();//��ȡ���������
        rbody = GetComponent<Rigidbody>();//��ȡ�������
    }
    void Update()
    {
        if (!IsSlope)
        {
            transform.position -= Vector3.forward * velocity * Time.deltaTime;
        }else
        {
            transform.position-=Vector3.forward*20*Time.deltaTime;
        }
        velocity += 0.2f * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.W) && !ani.GetCurrentAnimatorStateInfo(0).IsName("Unarmed-Jump")&&!ani.GetCurrentAnimatorStateInfo(0).IsName("Unarmed-Fall"))
        {
            ani.SetTrigger("Jump");
            if (IsJumpZone)
            {
                highJump = true;
                rbody.AddForce(Vector3.up * 3200);
            }
            else
            {
                rbody.AddForce(Vector3.up *400);
            }        
        }
        if (Input.GetKeyDown(KeyCode.S) && !ani.GetCurrentAnimatorStateInfo(0).IsName("Unarmed-DiveRoll-Forward1"))
        {
            ani.SetTrigger("DiveRoll");
            rbody.AddForce(Vector3.down * 2000);
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (RoadNum > 1)
                {
                    RoadNum--;
                }
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                if (RoadNum < 3)
                {
                    RoadNum++;
                }
            }
        }
        switch (RoadNum)
        {
            case 1:
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(4.6f, transform.position.y, transform.position.z), 50 * Time.deltaTime);
                break;
            case 2:
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(-0.387f, transform.position.y, transform.position.z), 50* Time.deltaTime);
                break;
            case 3:
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(-5.16f, transform.position.y, transform.position.z), 50 * Time.deltaTime);
                break;
        }
    }
    public void FootL()
    {

    }
    public void FootR()
    {

    }
    private void OnCollisionEnter(Collision collision)//��ɫ��ײ�¼�
    {
        if (collision.collider.tag == "Land")//����Ƿ��ڵ���
        {
            ani.SetBool("IsGround", true);
            highJump = false;
        }
       if(collision.collider.tag=="Obstacle")//����Ƿ���ײ���ϰ���
        {
            Time.timeScale = 0;
            GameOverUI.SetActive(true);
        }
    }
    private void OnCollisionStay(Collision collision)//��������ײ��
    {
        if (collision.collider.tag == "Land")//�Ƿ�����ڵ���
        {
            ani.SetBool("IsGround", true);
        }
    }
    private void OnCollisionExit(Collision collision)//�˳���ײ�¼�
    {
        if (collision.collider.tag == "Land")//�뿪����
        {
            ani.SetBool("IsGround", false);
        }
    }
    private void OnTriggerEnter(Collider other)//��ɫ�����¼�
    {
        if (other.tag == "JumpZone")//������������
        {
            IsJumpZone = true;
        }
        else if (other.tag == "Slope")
        {
            IsSlope = !IsSlope;
        }
        else if (other.tag == "TowerEnd")
        {
            highJump = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
       
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag=="JumpZone")
        {
            IsJumpZone = false;
        }
    }


}
