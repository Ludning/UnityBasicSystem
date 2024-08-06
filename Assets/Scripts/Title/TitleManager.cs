using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class TitleManager : MonoBehaviour
{
    public Animation LogoAnim;
    public TextMeshProUGUI LogoTxt;

    public GameObject Title;
    public Slider LoadingSlider;
    public TextMeshProUGUI LoadingProgressTxt;

    private AsyncOperation m_AsyncOperation;

    private void Awake()
    {
        LogoAnim.gameObject.SetActive(true);
        Title.SetActive(false);
    }

    private void Start()
    {
        StartCoroutine(CoLoadGame());
    }

    private IEnumerator CoLoadGame()
    {
        Logger.Log($"{GetType()}::CoLoadGame");

        LogoAnim.Play();
        yield return new WaitForSeconds(LogoAnim.clip.length);
        
        LogoAnim.gameObject.SetActive(false);
        Title.SetActive(true);

        m_AsyncOperation = SceneLoader.Instance.LoadSceneAsync(SceneType.Lobby);
        if (m_AsyncOperation == null)
        {
            Logger.Log("비동기 로비씬 로딩 오류");
            yield break;
        }

        m_AsyncOperation.allowSceneActivation = false;

        LoadingSlider.value = 0.5f;
        LoadingProgressTxt.text = $"{((int)LoadingSlider.value * 100).ToString()}%";
        yield return new WaitForSeconds(0.5f);

        while (!m_AsyncOperation.isDone)
        {
            LoadingSlider.value = m_AsyncOperation.progress < 0.5f ? 0.5f : m_AsyncOperation.progress;
            LoadingProgressTxt.text = $"{((int)LoadingSlider.value * 100).ToString()}%";

            //AsyncOperation는 allowSceneActivation가 false일 때 90%일 때 로딩이 멈추게 설계되어있음
            if (m_AsyncOperation.progress >= 0.9f)
            {
                m_AsyncOperation.allowSceneActivation = true;
                yield break;
            }

            yield return null;
        }
    }
}
