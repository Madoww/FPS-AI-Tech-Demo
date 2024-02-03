using System;
using UnityEngine;

namespace FPS.UI
{
    [RequireComponent(typeof(RectTransform))]
    public class UiObject : MonoBehaviour, IActivityTarget
    {
        public event Action OnShow;
        public event Action OnHide;

        [SerializeReference, ReferencePicker]
        private IActivityHandler activityHandler;

        private RectTransform rectTransform;

        public bool Shows => activityHandler?.Shows ?? false;
        public bool Hides => activityHandler?.Hides ?? false;
        public bool IsActivityChanging => Shows || Hides;
        public bool IsActive => gameObject.activeSelf;
        public RectTransform RectTransform
        {
            get
            {
                if (rectTransform == null)
                {
                    rectTransform = GetComponent<RectTransform>();
                }

                return rectTransform;
            }
        }

        protected virtual void OnDestroy()
        {
            ResetActivity();
        }

        public virtual bool CanShow()
        {
            return !IsActive || Hides;
        }

        public virtual bool CanHide()
        {
            return IsActive && !Hides;
        }

        public virtual void SetActive(bool value)
        {
            gameObject.SetActive(value);
            if (value)
            {
                OnShow?.Invoke();
            }
            else
            {
                OnHide?.Invoke();
            }
        }

        public virtual void Show()
        {
            Show(false);
        }

        public virtual void Show(bool immediately, Action onFinish = null)
        {
            OnStartShowing();
            if (activityHandler == null)
            {
                SetActive(true);
                OnFinishShowing();
                onFinish?.Invoke();
                return;
            }

            activityHandler.Show(this, immediately, () =>
            {
                OnFinishShowing();
                onFinish?.Invoke();
            });
        }

        public virtual void Hide()
        {
            Hide(false);
        }

        public virtual void Hide(bool immediately, Action onFinish = null)
        {
            OnStartHiding();
            if (activityHandler == null)
            {
                SetActive(false);
                OnFinishHiding();
                onFinish?.Invoke();
                return;
            }

            activityHandler.Hide(this, immediately, () =>
            {
                OnFinishHiding();
                onFinish?.Invoke();
            });
        }

        public void ResetActivity()
        {
            activityHandler?.Dispose();
        }

        protected virtual void OnStartShowing()
        { }

        protected virtual void OnFinishShowing()
        { }

        protected virtual void OnStartHiding()
        { }

        protected virtual void OnFinishHiding()
        { }
    }
}