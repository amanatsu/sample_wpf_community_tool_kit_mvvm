using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
//using Microsoft.Toolkit.Mvvm.ComponentModel; // 名前空間が変わります
//using Microsoft.Toolkit.Mvvm.Input;
using System.Windows.Input; // ICommand を使うために必要です

namespace sample_wpf_community_tool_kit_mvvm.ViewModels
{
    //public partial class MainViewModel : ObservableObject
    public class MainViewModel : ObservableObject
    {
        private readonly ScreenAViewModel screenAViewModel;
        private readonly ScreenBViewModel screenBViewModel;
        private readonly ScreenCViewModel screenCViewModel;

        private ObservableObject _currentScreen;
        public ObservableObject CurrentScreen
        {
            get => _currentScreen;
            // SetProperty が変更通知(RaisePropertyChanged)を自動で行います
            set => SetProperty(ref _currentScreen, value);
        }

        public ICommand ShowScreenACommand { get; }
        public ICommand ShowScreenBCommand { get; }
        public ICommand ShowScreenCCommand { get; }

        public MainViewModel()
        {
            screenAViewModel = new ScreenAViewModel();
            screenBViewModel = new ScreenBViewModel();
            screenCViewModel = new ScreenCViewModel();

            // 初期値のセット
            CurrentScreen = screenAViewModel;

            // 【変更点3】コマンドの初期化
            // メソッドとコマンドをここで紐づけます
            ShowScreenACommand = new RelayCommand(ShowScreenA);
            ShowScreenBCommand = new RelayCommand(ShowScreenB);
            ShowScreenCCommand = new RelayCommand(ShowScreenC);
        }

        // コマンドから呼ばれるメソッド（属性は不要です）
        private void ShowScreenA()
        {
            CurrentScreen = screenAViewModel;
        }

        private void ShowScreenB()
        {
            CurrentScreen = screenBViewModel;
        }

        private void ShowScreenC()
        {
            CurrentScreen = screenCViewModel;
        }
    }
}
