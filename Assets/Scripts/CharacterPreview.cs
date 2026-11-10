using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPreview : MonoBehaviour
{
    [Header("UI")]
    public Image characterImage;
    public TMP_Text characterName;

    [Header("Characters")]
    public CharacterData[] characters;

    public float frameTime = 0.15f;

    private int currentCharacter = 0;
    private int currentFrame = 0;
    private float timer = 0f;

    void Start()
    {
        ShowCharacter();
    }

    void Update()
    {
        if (characters.Length == 0)
            return;

        Sprite[] frames = characters[currentCharacter].idleFrames;

        if (frames.Length == 0)
            return;

        timer += Time.deltaTime;

        if (timer >= frameTime)
        {
            timer = 0f;

            currentFrame++;

            if (currentFrame >= frames.Length)
                currentFrame = 0;

            characterImage.sprite = frames[currentFrame];
        }
    }

    public void NextCharacter()
    {
        currentCharacter++;

        if (currentCharacter >= characters.Length)
            currentCharacter = 0;

        ShowCharacter();
    }

    public void PreviousCharacter()
    {
        currentCharacter--;

        if (currentCharacter < 0)
            currentCharacter = characters.Length - 1;

        ShowCharacter();
    }

    void ShowCharacter()
    {
        currentFrame = 0;
        timer = 0f;

        characterName.text = characters[currentCharacter].characterName;
        characterImage.sprite = characters[currentCharacter].idleFrames[0];
    }
}