using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Windows.Threading;
using MyMessager.Infrastructure.Commands;
using MyMessager.Models;
using MyMessager.Services;

namespace MyMessager.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string messageToSend;
        public string MessageToSend
        {
            get { return messageToSend; }
            set { messageToSend = value; OnPropertyChanged(); }
        }

        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Message> Messages { get; set; }

        public SendMessageCommand SendMessageCommand { get; set; }

        public MainViewModel(ChatService chatService)
        {
            Messages = new ObservableCollection<Message>();
            SendMessageCommand = new SendMessageCommand(this, chatService);
            chatService.MessageReceivedEvent += ChatService_MessageReceivedEvent;
        }

        public static MainViewModel CreateMainViewModel(ChatService chatService)
        {
            MainViewModel viewModel = new MainViewModel(chatService);
            chatService?.Connect();
            return viewModel;
        }


        SynchronizationContext uiContext = SynchronizationContext.Current!;
        private void ChatService_MessageReceivedEvent(Message obj)
        {
            uiContext.Send(_ => { Messages.Add(obj); }, null);
            //Messages.Add(obj);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
