using DryIoc.ImTools;
using PMS.Client.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Client.OrderModule.ViewModels.DialogModels
{
    class ImagePreviewViewModel : DialogViewModelBase
    {
        public DelegateCommand<string> FlipCommand { get; set; }

        private List<string> _imgList;
        private int _index = 0;
        private string _currentImage;
        public string CurrentImage 
        {
            get {  return _currentImage; }
            set { SetProperty<string>(ref _currentImage, value); }
        }

        public ImagePreviewViewModel()
        {
            FlipCommand = new DelegateCommand<string>(DoFlip);
        }

        private void DoFlip(string flag)
        {
            if(flag == "L")
            {
                _index--;
                if(_index < 0) _index = _imgList.Count - 1;
            }else if(flag == "R")
            {
                _index++;
                if (_index >= _imgList.Count) _index = 0;
            }
            CurrentImage = _imgList[_index];
        }

        public override void OnDialogOpened(IDialogParameters parameters)
        {
            base.OnDialogOpened(parameters);
            _imgList = parameters.GetValue<List<string>>("imgList");
            string img = parameters.GetValue<string>("img");

            if (_imgList != null)
            {
                _index = _imgList.IndexOf(img);
            }
            CurrentImage = img;
        }
    }
}
