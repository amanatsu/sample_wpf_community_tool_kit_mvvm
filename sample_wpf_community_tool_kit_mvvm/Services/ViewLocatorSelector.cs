using System;
using System.Windows;
using System.Windows.Controls;

namespace sample_wpf_community_tool_kit_mvvm.Services // 任意の名前空間
{
    public class ViewLocatorSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item == null) return null;

            // 1. ViewModelの型を取得
            var viewModelType = item.GetType();
            var viewModelName = viewModelType.FullName;

            // 2. 命名規則に従ってViewの型名を推測
            // 例: "MyProject.ViewModels.ScreenAViewModel" -> "MyProject.Views.ScreenA"
            var viewName = viewModelName.Replace(".ViewModels.", ".Views.");
            if (viewName.EndsWith("ViewModel"))
            {
                viewName = viewName.Substring(0, viewName.Length - "ViewModel".Length);
            }

            // 3. Viewの型（クラス）が存在するか確認
            var viewType = Type.GetType(viewName);
            if (viewType == null)
            {
                // 見つからない場合はデフォルトの挙動（あるいはエラー表示用のTemplateを返す）
                return base.SelectTemplate(item, container);
            }

            // 4. 動的にDataTemplateを生成して返す
            var factory = new FrameworkElementFactory(viewType);
            var dt = new DataTemplate { VisualTree = factory };
            return dt;
        }
    }
}