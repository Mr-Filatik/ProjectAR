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
    [SerializeField] private SoundController soundController = null;

    #endregion

    #region Private Variables

    private bool isWork = false;
    private float currentTime = 0f;
    private int number = 0;
    private string[] letter = new string[] {
        "������������, ������ ��������! �� ����", // 1
        "������� ���� ������. ����� ��� ���. ��", // 2
        "����� ������ �� ��� �� ������� � ���", // 3
        "���� �������. ��� �������� �� ��� �.�.", // 4
        "�� ���� ������� ������. � ��� � ������-", // 5
        "�� � 1960 ���� ������, �������� � ����-", // 6
        "������� �������, ������ ������� � ����-", // 7
        "�����, �� �� ������� ������  �� ����,", // 8
        "� � ����� � ��� �����. ����� � ������-", // 9
        "����, �� ��� ��� ��� �� ����, ����� � ", // 10
        "���������. ������� �� ������, ����� �", // 11
        "���� � �������� � �����. ������, � ����-", // 12
        "����� ����� ����� ���� � ��������, �� ", // 13
        "��� ������� �� ������� �.�. �� �����-", // 14
        "������� ��������� � ������. ����� � ��-", // 15
        "����� ���� �������� � �������� �����-", // 16
        "������. ���, ��������, ����������. ��-", // 17
        "���� ������ �����, � ���� �� ����� �", // 18
        "��������. �������� �������. � ����� ", // 19
        "�� ���������. � ��� � ��� ����? �� ", // 20
        "��������. ������� ������ ����� ������ ", // 21
        "���������.", // 22
        "", // 23
        "                          � �������� ����.", // 24
        "                                    28.11.62 �.", // 25
        "", // 26
        "           ��� �����: ���������� ���.,", // 27
        "                            ���. ����������,", // 28
        "                           ��. ������������,", // 29
        "                                ��� 4, ��. 57.", // 30
        ""};

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
                soundController.ContinueSound();
            }
            else
            {
                canvas.ActiveRestart(true);
                soundController.PauseSound();
            }
        }
        else
        {
            canvas.ActiveRestart(false);
            isWork = false;
            soundController.PauseSound();
        }
    }

    public void Restart()
    {
        textBack.text = "";
        textFront.text = "";
        number = 0;
        currentTime = 0f;
        isWork = true;
        soundController.StartSound();
    }

    #endregion

    #region Private Methods

    private void Awake()
    {
        textBack.text = "";
        textFront.text = "";
        number = 0;
    }

    private void Update()
    {
        if (isWork)
        {
            if (textBack.text == "")
            {
                canvas.ActiveRestart(false);
                textBack.text += letter[number];
            }
            if (currentTime > 2.5f)
            {
                currentTime = 0f;
                if (number < letter.GetLength(0) - 2)
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
                if (letter[number] == "")
                {
                    currentTime = 2.5f;
                }
                currentTime += Time.deltaTime;
                imageFront.color = new Color(imageFront.color.r, imageFront.color.g, imageFront.color.b, Mathf.Lerp(1, 0, currentTime / 2.5f));
            }
        }
    }

    #endregion
}
