using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using QLLuatApp.Model;
using System.IO;

namespace QLLuatApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LawEntryPage : ContentPage
    {
        public LawEntryPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                var law = new List<Luat>();
                var files = Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "*.laws.txt");
                foreach (string file in files)
                {
                    law.Add(new Luat()
                    {
                        FileName = file,
                        LawName = File.ReadAllText(file),
                        Text = File.ReadAllText(file),
                        Year = File.ReadAllText(file),
                        Date = File.GetCreationTime(file)
                    });
                }
                listView.ItemsSource = law.OrderBy(d => d.Date).ToList();
            }
            catch (Exception ex) { }
        }

        async void OnLawAddedClick(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new MainPage
            {
                BindingContext = new Luat()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new MainPage
                {

                    BindingContext = e.SelectedItem as Luat
                });
            }
        }
    }
}