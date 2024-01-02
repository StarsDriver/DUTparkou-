using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesControl : MonoBehaviour
{
    private int PosCount;
    private float length;
    private float time;
  //  float[] RoadChoice = { 5.75f, 0.57f, -4.28f };//�˴���Ҫ���Mapȷ��
    float[] RoadChoice = { 5.46f, 0.51f, -4.5f };
    public GameObject[] SmallObstacles;
    public GameObject[] BigObstacles;
    public GameObject Map1;
    // Start is called before the first frame update
    void Start()
    {
        //CreateObstacles(Map1,false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CreateObstacles(GameObject map,bool IsSpecialMap)//�����ͼ
    {
        List<int> ObstaclesPoint = new List<int>();//��¼�ϰ���λ�����  
        length = -map.transform.Find("MapEnd").localPosition.z;//��ͼ���ܳ���
        GameObject obstacle;
        PosCount = (int)length / 30;//�ϰ�����30������һ�ε�ͼ�м�������ϰ���
        if (IsSpecialMap)//�ж��Ƿ��������ͼ����б�£�
        {
            for (int i = 0; i < 3; i++)//����·
            {
                ObstaclesPoint.Clear();//���
                for (; ObstaclesPoint.Count <= PosCount/2-2;)//ÿһ·���ɶ���֮һ
                {
                    int num = Random.Range(2, PosCount);//����ϰ������ɵ�
                    if (!ObstaclesPoint.Contains(num))//�Ƿ��Ѱ�����Ϊ�����ɻ�����ͬ�������
                    {
                        ObstaclesPoint.Add(num);
                        obstacle = Instantiate(SmallObstacles[(int)Random.Range(0, 8)], new Vector3(map.transform.position.x + RoadChoice[i], map.transform.position.y+ 10.30859f, map.transform.position.z - num * 30), transform.rotation);
                        //�ڳ鵽��λ������ϰ���ʵ����
                        obstacle.transform.SetParent(map.transform, true);
                        //���ɵ��ϰ�����Ϊ��ͼ�������壬�������ͼһ��ɾ��
                    }
                }
            }
            ObstaclesPoint.Clear();
            PosCount = (int)length / 35;
            for (; ObstaclesPoint.Count <= PosCount / 2;)
            {
                int num = Random.Range(2, PosCount);
                if (!ObstaclesPoint.Contains(num))
                {
                    ObstaclesPoint.Add(num);
                    obstacle = Instantiate(BigObstacles[(int)Random.Range(0, 8)], new Vector3(map.transform.position.x + RoadChoice[Random.Range(0, 3)], map.transform.position.y+ 10.30859f, map.transform.position.z - num * 35), transform.rotation);
                    obstacle.transform.SetParent(map.transform, true);
                }
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                ObstaclesPoint.Clear();
                for (; ObstaclesPoint.Count <= PosCount / 2;)//ÿһ·���ɶ���֮һ
                {
                    int num = Random.Range(1, PosCount);
                    if (!ObstaclesPoint.Contains(num))
                    {
                        ObstaclesPoint.Add(num);
                        obstacle = Instantiate(SmallObstacles[(int)Random.Range(0, 8)], new Vector3(map.transform.position.x + RoadChoice[i], map.transform.position.y, map.transform.position.z - num * 30), transform.rotation);
                        obstacle.transform.SetParent(map.transform, true);
                    }
                }
            }
            ObstaclesPoint.Clear();
            PosCount = (int)length / 35;
            for (; ObstaclesPoint.Count <= PosCount / 2;)
            {
                int num = Random.Range(1, PosCount);
                if (!ObstaclesPoint.Contains(num))
                {
                    ObstaclesPoint.Add(num);
                    obstacle = Instantiate(BigObstacles[(int)Random.Range(0, 8)], new Vector3(map.transform.position.x + RoadChoice[Random.Range(0, 3)], map.transform.position.y, map.transform.position.z - num * 35), transform.rotation);
                    obstacle.transform.SetParent(map.transform, true);
                }
            }
        }
    }
}
