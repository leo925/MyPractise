using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonServiceLocator;
using Core.Events;
using Prism.Events;
using Prism.Mvvm;
namespace ModuleB.ViewModels
{
    public  class MessagesViewModel:BindableBase
    {
        private ObservableCollection<string> _messages;

        public ObservableCollection<string> Messages
        {
            get { return _messages; }
            set { SetProperty(ref _messages, value); }
        }

        public MessagesViewModel()
        {
            Messages = new ObservableCollection<string>();
            ServiceLocator.Current.GetInstance<IEventAggregator>().GetEvent<MessageSendEvent>().Subscribe(OnMessageReceived);
        }

        //public MessagesViewModel(IEventAggregator eventAggregator)
        //{
        //    eventAggregator.GetEvent<MessageSendEvent>().Subscribe(OnMessageReceived);
        //}

        private void OnMessageReceived(string message)
        {
            Messages.Add(message);
        }
    }
}
