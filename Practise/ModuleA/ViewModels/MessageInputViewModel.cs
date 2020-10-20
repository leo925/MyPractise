using Prism.Mvvm;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Events;
using Core.Events;
using CommonServiceLocator;

namespace ModuleA.ViewModels
{
    public class MessageInputViewModel:BindableBase
    {

        private string _message="Message to send";

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message , value); }
        }

        public DelegateCommand SendMessageCommand { get; private set; }

       // private readonly IEventAggregator _eventAggreator;

        private IEventAggregator _eventAggreator;
    
        public IEventAggregator EventAggreator
        {
            get { return _eventAggreator; }
            set { _eventAggreator = value; }

        }


        public MessageInputViewModel()
        {
            SendMessageCommand = new DelegateCommand(SendMessage);
            EventAggreator = ServiceLocator.Current.GetInstance<IEventAggregator>();
        
        }

        //public MessageInputViewModel(IEventAggregator eventAggregator)
        //{
            
        //}

        private void SendMessage()
        {
            _eventAggreator.GetEvent<MessageSendEvent>().Publish(Message);
        }
    }
}
