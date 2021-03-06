﻿using Fasetto.Word.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Fasetto.Word
{
    public class WindowViewModel : BaseViewModel
    {
        private Window _window;

        private int _outerMarginSize = 10;
        private int _windowsRadius = 10;

        public ICommand CloseCommand { get; set; }
        public ICommand MaximizeCommand { get; set; }
        public ICommand MenuCommand { get; set; }
        public ICommand MinimizeCommand { get; set; }

        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;

        public int InnerContentPaddingSize { get; set; } = 0;

        public Thickness InnerContentPadding { get { return new Thickness(InnerContentPaddingSize); } }

        public int ResizeBorder { get; set; } = 6;

        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize); } }

        public int OuterMarginSize
        {
            get
            {
                return _window.WindowState == WindowState.Maximized ? 0 : _outerMarginSize;
            }
            set
            {
                _outerMarginSize = value;
            }
        }

        public Thickness OuterMarginThickness { get { return new Thickness(OuterMarginSize); } }

        public int WindowRadius
        {
            get
            {
                return _window.WindowState == WindowState.Maximized ? 0 : _windowsRadius;
            }
            set
            {
                _windowsRadius = value;
            }
        }

        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

        public int TitleHeight { get; set; } = 42;

        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight + ResizeBorder); } }

        public WindowViewModel(Window window)
        {
            _window = window;// this is bollocks - we can't test the view model

            _window.StateChanged += (sender, e) =>
            {
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };

            CloseCommand = new RelayCommand(() => _window.Close());
            MinimizeCommand = new RelayCommand(() => _window.WindowState = WindowState.Minimized);
            MenuCommand = new RelayCommand(MenuAction);
            MaximizeCommand = new RelayCommand(() => _window.WindowState ^= WindowState.Maximized);
        }

        private void MenuAction()
        {
            Point relativePosition = Mouse.GetPosition(_window);
            Point mousePosition = _window.PointToScreen(relativePosition);
            SystemCommands.ShowSystemMenu(_window, mousePosition);
        }
    }
}
