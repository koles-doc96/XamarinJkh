using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LibraryJkh
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrForm : ContentPage
    {
        public RegistrForm()
        {
            InitializeComponent();
            var forgetPassword_tap = new TapGestureRecognizer();
            forgetPassword_tap.Tapped += async (s, e) => { await Navigation.PopModalAsync(); };
            BackStackLayout.GestureRecognizers.Add(forgetPassword_tap);
        }

        private void NextReg(object sender, EventArgs e)
        {
            StepsImage.Source = ImageSource.FromFile("ic_steps_two");
            RegistrationFrameStep1.IsVisible = false;
            RegistrationFrameStep2.IsVisible = true;
            LabelSteps.Text = "Шаг 2";
        }

        private void NextTwoReg(object sender, EventArgs e)
        {
            StepsImage.Source = ImageSource.FromFile("ic_steps_three");
            RegistrationFrameStep2.IsVisible = false;
            RegistrationFrameStep3.IsVisible = true;
            LabelSteps.Text = "Шаг 3";
        }
    }
}