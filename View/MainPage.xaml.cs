using lplplp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace lplplp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        //void SignInProcedure(object sender,  EventArgs e)
        //{
        //    User user = new User(Entry_Username.Text, Entry_Password.Password);
        //    if (user.CheckInformation())
        //    {
        //        MessageDialog("Login", "Login Sucess", "Derp");
        //    }
        //    else
        //    {
        //        DisplayAlert("Login", "Login Not Correct, empty username or password.", "derp");
        //    }
        //}
        private async void PopUpMethod()
        {
            ContentDialog dialogue = new ContentDialog()
            {
                Title = "Log in",
                Content = "Signed in successfully",
                CloseButtonText = "Ok",
            };

            await dialogue.ShowAsync();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PopUpMethod();
        }
    }
}
