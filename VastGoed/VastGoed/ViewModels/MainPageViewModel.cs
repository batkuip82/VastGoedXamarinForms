using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VastGoed.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IModuleManager _moduleManager;

        string _title = "Main Page";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand LoadModuleACommand { get; set; }

        public MainPageViewModel(IModuleManager moduleManager)
        {
            _moduleManager = moduleManager;
            LoadModuleACommand = new DelegateCommand(LoadModuleA);
        }

        void LoadModuleA()
        {
            //_moduleManager.LoadModule("ModuleA");
        }
    }
}
