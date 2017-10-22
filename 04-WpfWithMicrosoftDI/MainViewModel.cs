using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDITestbed
{
    public class MainViewModel : BaseViewModel
    {
        private ITextService _textService;

        public MainViewModel(ITextService textService)
        {
            _textService = textService;
        }

        public string SomeText { get { return _textService.GetSome(); } }
    }
}
