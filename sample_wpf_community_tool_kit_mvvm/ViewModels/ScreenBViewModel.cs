using CommunityToolkit.Mvvm.ComponentModel;

namespace sample_wpf_community_tool_kit_mvvm.ViewModels
{
    public class ScreenBViewModel : ObservableObject
    {
        private string _greeting;
        public string Greeting
        {
            get => _greeting;
            // SetProperty ‚ª•ÏX’Ê’m(RaisePropertyChanged)‚ðŽ©“®‚Ås‚¢‚Ü‚·
            set => SetProperty(ref _greeting, value);
        }

        public ScreenBViewModel()
        {
            Greeting = "ScreenB";
        }
    }
}
