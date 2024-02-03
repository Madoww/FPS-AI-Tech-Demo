using System;
using System.Collections.Generic;
using UnityEngine;

namespace FPS.UI.Views
{
    public class UiViewsHandler : UiHandlerBehaviour, IUiViewsHandler
    {
        public event Action<UiView> OnShowView;
        public event Action<UiView> OnHideView;

        [SerializeField, ReorderableList]
        private List<ViewDefinition> definitions;

        private readonly Dictionary<Type, UiView> viewsByType = new Dictionary<Type, UiView>();

        public void Show<T>() where T : UiView
        {
            Show(typeof(T));
        }

        public void Show(Type type)
        {
            if (viewsByType.TryGetValue(type, out UiView view))
            {
                Show(view);
            }
        }

        public void Show(UiView view)
        {
            ShowInternally(view, false);
        }

        public void Hide<T>() where T : UiView
        {
            Hide(typeof(T));
        }

        public void Hide(Type type)
        {
            if (viewsByType.TryGetValue(type, out UiView view))
            {
                Hide(view);
            }
        }

        public void Hide(UiView view)
        {
            HideInternally(view, false);
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();
            InitializeViews();
        }

        protected override void OnDeinitialize()
        {
            DeinitializeViews();
            base.OnDeinitialize();
        }

        private void InitializeViews()
        {
            foreach (ViewDefinition definition in definitions)
            {
                InitializeView(definition);
            }
        }

        private void DeinitializeViews()
        {
            foreach (ViewDefinition definition in definitions)
            {
                DeinitializeView(definition);
            }
        }

        private void InitializeView(ViewDefinition definition)
        {
            var view = definition.view;
            if (view == null)
            {
                Debug.LogWarning($"[UI] Definition contains a null {nameof(UiView)}");
                return;
            }

            var type = view.GetType();
            if (viewsByType.ContainsKey(type))
            {
                Debug.Log($"[UI] {type.Name} is already cached");
                return;
            }

            viewsByType.Add(type, view);
            view.Initialize();
            view.OnShowView += OnShowViewCallback;
            view.OnHideView += OnHideViewCallback;

            var setImmediately = definition.showImmediately;
            if (definition.showOnInitialize)
            {
                if (!setImmediately)
                {
                    HideInternally(view, true, true);
                    ShowInternally(view, false, true);
                }
                else
                {
                    ShowInternally(view, true, true);
                }

                return;
            }

            HideInternally(view, setImmediately, true);
        }

        private void DeinitializeView(ViewDefinition definition)
        {
            var view = definition.view;
            if (view == null)
            {
                return;
            }

            view.Deinitialize();
            view.OnShowView -= OnShowViewCallback;
            view.OnHideView -= OnHideViewCallback;
        }

        private void ShowInternally(UiView view, bool immediately, bool force = false)
        {
            if (!CanShow(view) && !force)
            {
                return;
            }

            view.Show(immediately);
        }

        private void HideInternally(UiView view, bool immediately, bool force = false)
        {
            if (!CanHide(view) && !force)
            {
                return;
            }

            view.Hide(immediately);
        }

        private bool CanShow(UiView view)
        {
            return view != null && view.CanShow();
        }

        private bool CanHide(UiView view)
        {
            return view != null && !view.CanHide();
        }

        private void OnShowViewCallback(UiView view)
        {
            OnShowView?.Invoke(view);
        }

        private void OnHideViewCallback(UiView view)
        {
            OnHideView?.Invoke(view);
        }
    }
}