using Microsoft.AspNetCore.SignalR.Client;
using MyMessager.ViewModels;
using MyMessager.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MyMessager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            HubConnection _hubConnection = new HubConnectionBuilder().WithUrl("https://localhost:7041/chat").Build(); //TODO проверить на ошибки
            MainWindow window = new MainWindow
            {
                DataContext = MainViewModel.CreateMainViewModel(new Services.ChatService(_hubConnection))
            };
            window.Show();
        }
    }
}
