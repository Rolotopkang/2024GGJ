using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class BasePanel : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    private float alphaSpeed = 0.8f;

    public bool isShow = false;

    private UnityAction hideCallBack = null;

    protected virtual void Awake()
    {
        canvasGroup = this.GetComponent<CanvasGroup>();

        if (canvasGroup == null)
            canvasGroup = this.gameObject.AddComponent<CanvasGroup>();
    }

    protected virtual void Start()
    {
        Init();
    }
    /// <summary>
    /// 注册控件事件方法
    /// </summary>
    public abstract void Init();

    public virtual void ShowMe()
    {
        canvasGroup.alpha = 0;
        isShow = true;
    }

    public virtual void HideMe(UnityAction callBack)
    {
        canvasGroup.alpha = 1;
        isShow = false;
        hideCallBack = callBack;
    }

    private void Update()
    {
        if (isShow && canvasGroup.alpha != 1)
        {
            canvasGroup.alpha += alphaSpeed * Time.deltaTime;
            if (canvasGroup.alpha >= 1)
                canvasGroup.alpha = 1;
        }
        else if (!isShow && canvasGroup.alpha != 0)
        {
            canvasGroup.alpha -= alphaSpeed * Time.deltaTime;
            if (canvasGroup.alpha <= 0)
            {
                canvasGroup.alpha = 0;
                hideCallBack?.Invoke();
            }
        }
    }
}
