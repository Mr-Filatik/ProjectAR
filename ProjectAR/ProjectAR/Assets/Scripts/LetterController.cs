using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterController : MonoBehaviour
{
    #region Serialize Variables

    [SerializeField] private CanvasController canvas = null;
    [SerializeField] private Text textBack = null;
    //[SerializeField] private TextMesh textBackTMP = null;
    [SerializeField] private Text textFront = null;
    //[SerializeField] private TextMesh textFrontTMP = null;
    [SerializeField] private Image imageFront = null;
    [SerializeField] private SoundController soundController = null;

    #endregion

    #region Private Variables

    private byte soundAndRestart = 2; //0 rest, 1 on, 2 off
    private bool isWork = false;
    private float currentTime = 0f;
    private int number = 0;
    private string[] letter = new string[] {
        "Здравствуйте, Сергей Иванович!",
        "На днях получил Ваше письмо. Очень ему",
        "рад. До этого ничего от Вас не получал и",
        "был этим огорчён. Сам написать не мог",
        "т.к. не знал точного адреса. Я был в Сара-",
        "тове в 1960 году весной, заходили к Кала-",
        "шникову Виктору, вместе учились в аэро-",
        "клубе, но он точного адреса  не знал,",
        "а я хотел к Вам зайти. Зашёл к Мартья-",
        "нову, но его уже там не было, летом в ",
        "Куйбышеве. Походил по городу, зашёл к",
        "себе в техникум и уехал.",
        "Весной, в годовщину полёта хотел быть в",
        "Саратове, но это сделать не удалось т.к.",
        "всё празднование проходило в Москве.",
        "Думаю в будущем году побывать в Сара-",
        "тове обязательно. Там, очевидно, встре-",
        "тимся.Работы сейчас много, к тому же",
        "учёба в академии. Здоровье хорошее. В",
        "семье всё нормально. А как у Вас дела?",
        "До свидания. Большой привет всему Ва-",
        "шему семейству.",
        "       С приветом Юрий.",
        "            28.11.62 г.",
        "",
        "           Мой адрес: Московская обл.,",
        "                            пос. Чкаловская,",
        "                           ул. Циолковского,",
        "                                дом 4, кв. 57.",
        ""};

    #endregion

    #region Public Methods

    public void Active(bool input)
    {
        if (input)
        {
            canvas.ActiveRestart(true);
            if (number != letter.GetLength(0) - 1)
            {
                if (soundAndRestart == 1)
                {
                    canvas.SetSpriteOff(); //
                    soundController.SoundOff();
                }
                if (soundAndRestart == 2)
                {
                    canvas.SetSpriteOn(); //
                    soundController.SoundOn();
                }
                //canvas.ActiveRestart(false);
                isWork = true;
                soundController.ContinueSound();
            }
            else
            {
                canvas.SetSpriteRestart();
                //canvas.ActiveRestart(true);
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
        bool flag = true;
        if (soundAndRestart == 1 && flag)
        {
            canvas.SetSpriteOn(); //
            soundController.SoundOn();
            soundAndRestart = 2;
            flag = false;
        }
        if (soundAndRestart == 2 && flag)
        {
            canvas.SetSpriteOff(); //
            soundController.SoundOff();
            soundAndRestart = 1;
            flag = false;
        }
        if (soundAndRestart == 0)
        {
            textBack.text = "";
            textFront.text = "";
            number = 0;
            currentTime = 0f;
            isWork = true;
            soundController.StartSound();
            soundAndRestart = 2; 
            canvas.SetSpriteOn(); //
        }
    }

    #endregion

    #region Private Methods

    private void Awake()
    {
        textBack.text = "";
        textFront.text = "";
        number = 0;
        soundAndRestart = 2;
    }

    private void Update()
    {
        if (isWork)
        {
            if (textBack.text == "" && textFront.text == "")
            {
                //canvas.ActiveRestart(false);
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
                    if (number == letter.GetLength(0) - 2)
                    {
                        textBack.text = "";
                        textFront.text += letter[number] + "\n";
                        number++;
                    }
                    //canvas.ActiveRestart(true);
                    soundAndRestart = 0;
                    canvas.SetSpriteRestart();
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
