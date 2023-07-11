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
    public partial class AffineViewModel : ObservableObject
    {
        [ObservableProperty]
        private string encrypt = "";
        [ObservableProperty]
        private string decrypt = "";
        [ObservableProperty]
        private string shift = "1";
        [ObservableProperty]
        private string a = "1";
        [ObservableProperty]
        private string b = "1";
        [ObservableProperty]
        private string encrypted;
        [ObservableProperty]
        private string decrypted;

        [RelayCommand]
        private void EncryptString()
        {
            int i,A,B;
            if (!int.TryParse(shift, out i))
            {
                MessageBox.Show("Please enter an valid number for shift");
                return;
            }
            if (!int.TryParse(a, out A))
            {
                MessageBox.Show("Please enter an valid number for a");
                return;
            }
            if (!int.TryParse(b, out B))
            {
                MessageBox.Show("Please enter an valid number for b");
                return;
            }
            var temp = Algorithm.ShiftCipher.Encrypt(Encrypt, i);

            Encrypted = Algorithm.AffineCipher.Encrypt(temp, A, B);
        }
        [RelayCommand]
        private void DecryptString()
        {
            int i, A, B;
            if (!int.TryParse(shift, out i))
            {
                MessageBox.Show("Please enter an valid number for shift");
                return;
            }
            if (!int.TryParse(a, out A))
            {
                MessageBox.Show("Please enter an valid number for a");
                return;
            }
            if (!int.TryParse(b, out B))
            {
                MessageBox.Show("Please enter an valid number for b");
                return;
            }
            var temp = Algorithm.AffineCipher.Decrypt(Decrypt, A, B);
            Decrypted = Algorithm.ShiftCipher.Decrypt(temp, i); 
        }
    }
}
