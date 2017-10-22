namespace WpfDITestbed
{
    public class MainViewModel : BaseViewModel, IMainViewModel
    {
        private ITextService _textService;

        public MainViewModel(ITextService textService)
        {
            _textService = textService;
        }

        public string SomeText { get { return _textService.GetSome(); } }
    }
}
