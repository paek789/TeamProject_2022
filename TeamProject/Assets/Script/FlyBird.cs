using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBird : MonoBehaviour
{
 
        float upMax = 3.0f; //���� �̵������� (y)�ִ밪

        float downMax = -1.0f; //�Ʒ��� �̵������� (��)�ִ밪

        float currentPosition; //���� ��ġ(y) ����

        float direction = 5.0f; //�̵��ӵ�+����




        void Start()

        {

            currentPosition = transform.position.y;

        }




        void Update()

        {

            currentPosition += Time.deltaTime * direction;

            if (currentPosition >= upMax)

            {

                direction *= -1;

                currentPosition = upMax;

            }

            //���� ��ġ(x)�� ��� �̵������� (x)�ִ밪���� ũ�ų� ���ٸ�

            //�̵��ӵ�+���⿡ -1�� ���� ������ ���ְ� ������ġ�� ��� �̵������� (x)�ִ밪���� ����

            else if (currentPosition <= downMax)

            {

                direction *= -1;

                currentPosition = downMax;

            }

            //���� ��ġ(x)�� �·� �̵������� (x)�ִ밪���� ũ�ų� ���ٸ�

            //�̵��ӵ�+���⿡ -1�� ���� ������ ���ְ� ������ġ�� �·� �̵������� (x)�ִ밪���� ����

            transform.position = new Vector3(transform.position.x,currentPosition, transform.position.z);

            //"Stone"�� ��ġ�� ���� ������ġ�� ó��

        }
    }

