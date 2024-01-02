using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControl : MonoBehaviour
{
    private Transform CreatePoint;//�µ�ͼ���ص�λ��
    private GameObject NewMap;//��Ҫ���ص��µ�ͼ
    private int MapCount;//��¼������ĵ�ͼ���
    private Queue<GameObject> Map=new Queue<GameObject>();//��ŵ�ǰ��ͼ
    public GameObject Map1;//��ʼ�ĵ�ͼ
    ObstaclesControl Obs;
    bool IsSpecialMap;
    void Start()
    {
        Map.Enqueue(Map1);
        Obs = GameObject.Find("ObstaclesControl").GetComponent<ObstaclesControl>();//��ȡ�����ϰ�������
        CreatePoint = Map1.transform.Find("MapEnd");//��ȡ��ʼ��ͼ���յ�
        for(int i=0;i<3;i++)
        {
            CreateMap(ref CreatePoint);
        }
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="MapEnd")
        {
            CreateMap(ref CreatePoint);
            Destroy(Map.Dequeue());
        }
    }
    private void CreateMap(ref Transform CreatPoint)//���ò���
    {
        MapCount =  Random.Range(1, 8);
        if(MapCount==2||MapCount==3)//�ж��Ƿ��������ͼ
        {
            IsSpecialMap = true;
        }else
        {
            IsSpecialMap = false;
        }
        NewMap = Instantiate(Resources.Load<GameObject>("Map" + MapCount), CreatePoint.position, CreatePoint.rotation);//ʵ�����µ�ͼ
        Map.Enqueue(NewMap);//�µ�ͼ���
        CreatePoint = NewMap.transform.Find("MapEnd");//��ȡ�µ�ͼ��ĩβ
        Obs.CreateObstacles(NewMap,IsSpecialMap);
       
    }
}
