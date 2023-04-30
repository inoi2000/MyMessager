using MyMessager.Services;
using MyMessager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyMessager.Infrastructure.Commands
{
    public class SendMessageCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly MainViewModel _viewModel;
        private readonly ChatService _chatService;

        public SendMessageCommand(MainViewModel viewModel, ChatService chatService)
        {
            _viewModel = viewModel;
            _chatService = chatService;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            await _chatService.SendMessage(new Models.Message
            {
                DateOfSend = DateTime.Now,
                Text = _viewModel.MessageToSend,
                User = new Models.User() { Name = _viewModel.UserName },
            });
        }
    }
}
