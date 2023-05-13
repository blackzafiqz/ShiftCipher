using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShiftCipher.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private string encrypt = "";
        [ObservableProperty]
        private string decrypt = "";
        [ObservableProperty]
        private string shift = "1";
        [ObservableProperty]
        private string encrypted;
        [ObservableProperty]
        private string decrypted;

        [RelayCommand]
        private void EncryptString()
        {
            int i;
            if (!int.TryParse(shift, out i))
            {
                MessageBox.Show("Please enter an valid number for shift");
                return;
            }
            Encrypted = "";
            foreach (char c in encrypt)
            {
                if (c == ' ')
                    Encrypted += ' ';
                else
                {
                    var temp = (c + i - 65) % 26 + 65;
                    Encrypted += (char)temp;
                }
            }
        }
        [RelayCommand]
        private void DecryptString()
        {
            int i;
            if (!int.TryParse(shift, out i))
            {
                MessageBox.Show("Please enter an valid number for shift");
                return;
            }
            Decrypted = "";
            foreach (char c in Decrypt)
            {
                if (c == ' ')
                    Decrypted += ' ';
                else
                {
                    var temp = (c - i - 65 + 26) % 26 + 65;
                    Decrypted += (char)temp;
                }
            }
        }
    }
}