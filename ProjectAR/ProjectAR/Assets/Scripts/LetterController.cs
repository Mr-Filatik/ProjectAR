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
        "Здравствуйте, Сергей Иванович! На днях", // 1
        "получил Ваше письмо. Очень ему рад. До", // 2
        "этого ничего от Вас не получал и был", // 3
        "этим огорчён. Сам написать не мог т.к.", // 4
        "не знал точного адреса. Я был в Сарато-", // 5
        "ве в 1960 году весной, заходили к Кала-", // 6
        "шникову Виктору, вместе учились в аэро-", // 7
        "клубе, но он точного адреса  не знал,", // 8
        "а я хотел к Вам зайти. Зашёл к Мартья-", // 9
        "нову, но его уже там не было, летом в ", // 10
        "Куйбышеве. Походил по городу, зашёл к", // 11
        "себе в техникум и уехал. Весной, в годо-", // 12
        "вщину полёта хотел быть в Саратове, но ", // 13
        "это сделать не удалось т.к. всё празд-", // 14
        "нование проходило в Москве. Думаю в бу-", // 15
        "дущем году побывать в Саратове обяза-", // 16
        "тельно. Там, очевидно, встретимся. Ра-", // 17
        "боты сейчас много, к тому же учёба в", // 18
        "академии. Здоровье хорошее. В семье ", // 19
        "всё нормально. А как у Вас дела? До ", // 20
        "свидания. Большой привет всему Вашему ", // 21
        "семейству.", // 22
        "", // 23
        "                          С приветом Юрий.", // 24
        "                                    28.11.62 г.", // 25
        "", // 26
        "           Мой адрес: Московская обл.,", // 27
        "                            пос. Чкаловская,", // 28
        "                           ул. Циолковского,", // 29
        "                                дом 4, кв. 57.", // 30
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
