using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GSB_WPF
{
    /// <summary>
    /// Logique d'interaction pour NewReport.xaml
    /// </summary>
    public partial class NewReport : Window
    {
        public NewReport()
        {
            InitializeComponent();

            tbxPractitionerRemplacement.IsEnabled = false;

            if(UserSession.Statut == "Visiteur")
            {
                tbxVisitorMatricule.IsEnabled = false;
                tbxVisitorMatricule.Text = UserSession.Id;
            }
        }

        private void cbxPractitionerIsAbsent_Checked(object sender, RoutedEventArgs e)
        {
            if(cbxPractitionerIsAbsent.IsChecked == true)
            {
                tbxPractitionerRemplacement.IsEnabled = true;
            }
            else if (cbxPractitionerIsAbsent.IsChecked == false)
            {
                tbxPractitionerRemplacement.IsEnabled = false;
            }
            
        }
    }
}
