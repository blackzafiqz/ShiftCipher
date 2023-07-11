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
            Encrypted = Algorithm.ShiftCipher.Encrypt(Encrypt, i);
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
            Decrypted = Algorithm.ShiftCipher.Decrypt(Decrypt, i);
        }

        [RelayCommand]
        private void SpawnAffineWindow()
        {
            new AffineWindow().Show();
            
        }
    }
}