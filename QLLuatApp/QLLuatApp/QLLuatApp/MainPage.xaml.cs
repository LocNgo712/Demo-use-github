using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;
using QLLuatApp.Model;

namespace QLLuatApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void SaveLaw(object sender, EventArgs e)
        {
            Luat law = (Luat)BindingContext;
            if (string.IsNullOrWhiteSpace(law.FileName))
            {
                law.FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"{Path.GetRandomFileName()}.laws.txt");
            }

            File.WriteAllText(law.FileName, law.LawName) ;
            File.WriteAllText(law.FileName, law.Text);
            File.WriteAllText(law.FileName, law.Year);

            await Navigation.PopAsync();
        }

        async void DeleteLaw(object sender, EventArgs e)
        {
            Luat law = (Luat)BindingContext;
            if (File.Exists(law.FileName))
            {
                File.Delete(law.FileName);
            }
            await Navigation.PopAsync();
        }
    }
}
