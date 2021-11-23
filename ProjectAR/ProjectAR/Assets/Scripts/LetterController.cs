using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterController : MonoBehaviour
{
    #region Serialize Variables

    [SerializeField] private CanvasController canvas = null;
    [SerializeField] private Text textBack = null;
    [SerializeField] private Text textFront = null;
    [SerializeField] private Image imageFront = null;

    #endregion

    #region Private Variables

    private bool isWork = false;
    private float currentTime = 0f;
    private int number = 0;
    private string[] letter = new string[] { 
        "������������, ������ ��������!", 
        "�� ���� ������� ���� ������.", 
        "����� ��� ���.�� ����� ������ ��", 
        "��� �� ������� � ��� ���� �������.", 
        "��� �������� �� ��� �.�.�� ����", 
        "������� ������.� ��� � ��������", 
        "� 1960 ���� ������, �������� � ����-", 
        "������� �������, ������ ������� �", 
        "���������, �� �� ������� ������  ��", 
        "����, � � ����� � ��� �����.", 
        "����� � ����������, �� ��� ���", 
        "��� �� ����, ����� � ���������.", 
        "������� �� ������, ����� � ���� �", 
        "�������� � �����.", 
        "������, � ��������� ����� �����", 
        "���� � ��������, �� ��� ������� ��", 
        "������� �.�.�� ������������ ���-", 
        "������ � ������.", 
        "����� � ������� ���� �������� � ����-", 
        "���� �����������. ���, ��������, �����-", 
        "�����.", 
        "������ ������ �����, � ���� ��", 
        "����� � ��������. �������� ����-", 
        "���.� ����� �� ���������.", 
        "� ��� � ��� ����?", 
        "�� ��������.������� ������", 
        "����� ������ ���������.", 
        "� ��������, ����.", 
        "28.11.62 �.", 
        "",
        "��� �����: ���������� ���.,", 
        "���.����������,", 
        "��.������������,", 
        "��� 4, ��. 57." };

    #endregion

    #region Public Methods

    public void Active(bool input)
    {
        if (input)
        {
            if (number != letter.GetLength(0) - 1)
            {
                canvas.ActiveRestart(false);
                isWork = true;
            }
            else
            {
                canvas.ActiveRestart(true);
                /*textBack.text = "";
                textFront.text = "";
                number = 0;
                currentTime = 0f;
                isWork = true;*/
            }
        }
        else
        {
            canvas.ActiveRestart(false);
            isWork = false;
        }
    }

    public void Restart()
    {
        textBack.text = "";
        textFront.text = "";
        number = 0;
        currentTime = 0f;
        isWork = true;
    }

    #endregion

    #region Private Methods

    private void Update()
    {
        if (isWork)
        {
            if (textBack.text == "")
            {
                canvas.ActiveRestart(false);
                textBack.text += letter[number];
            }
            if (currentTime > 1f)
            {
                currentTime = 0f;
                if (number < letter.GetLength(0) - 1)
                {
                    number++;
                    imageFront.color = new Color(imageFront.color.r, imageFront.color.g, imageFront.color.b, 1);
                    textBack.text = "";
                    for (int i = 0; i < number; i++)
                    {
                        textBack.text += "\n";
                    }
                    textBack.text += letter[number];
                    if (number > 0)
                    {
                        textFront.text += letter[number - 1] + "\n";
                    }
                }
                else
                {
                    textBack.text = "";
                    textFront.text += letter[number] + "\n";
                    canvas.ActiveRestart(true);
                    isWork = false;
                }
            }
            else
            {
                currentTime += Time.deltaTime;
                imageFront.color = new Color(imageFront.color.r, imageFront.color.g, imageFront.color.b, Mathf.Lerp(1, 0, currentTime));
            }
        }
    }

    #endregion
}
