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
    /// Logique d'interaction pour MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();

            tbxVisitorMatricule.Text = UserSession.Id;

            string request;
            CURS cs = new CURS(CURS.connectionString);

            request = $"SELECT * FROM rapport WHERE fk_cob_id = '{ tbxVisitorMatricule.Text }';";
            cs.ReqSelect(request);
            while(!cs.End())
            {
                dgdReports.Items.Add(new Report()
                {
                    IdVisitor = cs.Field("fk_cob_id").ToString(),
                    IdReport = cs.Field("rap_id").ToString(),
                    IdPractitioner = cs.Field("fk_pra_id").ToString(),
                    VisiteDate = cs.Field("rap_dateVisite").ToString()
                });
                cs.suivant();
            }
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void btnNewReport_Click(object sender, RoutedEventArgs e)
        {
            NewReport w = new NewReport();
            w.ShowDialog();
        }
    }
}
