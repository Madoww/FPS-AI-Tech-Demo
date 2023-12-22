namespace FPS.Editor.Cutscenes
{
    //[CustomEditor(typeof(StateManager))]
    //public class StateManagerEditor : ToolboxEditor
    //{
    //    public override void DrawCustomInspector()
    //    {
    //        if (GUILayout.Button("Show State Machine", Style.miniButtonStyle))
    //        {
    //            StateManagerWindow.Init();
    //        }
    //
    //        EditorGUILayout.Space();
    //        var state = StateManager.CurrentState;
    //        using (new EditorGUILayout.HorizontalScope(Style.stateGroupStyle))
    //        {
    //            var stateName = state != null ? state.ToString() : "<none>";
    //            EditorGUILayout.LabelField($"<b>Current State:</b> {stateName}", Style.stateLabelStyle);
    //        }
    //    }
    //
    //    public override bool RequiresConstantRepaint()
    //    {
    //        return Application.isPlaying;
    //    }
    //
    //    private StateManager StateManager => target as StateManager;
    //
    //    private static class Style
    //    {
    //        internal static readonly GUIStyle stateGroupStyle = new GUIStyle(EditorStyles.helpBox);
    //        internal static readonly GUIStyle stateLabelStyle = new GUIStyle(EditorStyles.label)
    //        {
    //            richText = true
    //        };
    //        internal static readonly GUIStyle titleLabelStyle = new GUIStyle(EditorStyles.boldLabel)
    //        {
    //            alignment = TextAnchor.MiddleCenter
    //        };
    //        internal static readonly GUIStyle miniButtonStyle = new GUIStyle(EditorStyles.miniButton);
    //    }
    //}
}