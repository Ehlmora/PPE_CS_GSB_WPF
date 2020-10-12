using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GSB_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            tbxLogin.Text = "Penteract";
            tbxPassword.Text = "azerty";
        }

        private void btnConnection_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string login = tbxLogin.Text;
                string password = tbxPassword.Text;

                string request = $"SELECT COUNT(cpt_login) FROM compte WHERE cpt_login = '{login}' AND cpt_pwd = MD5('{password}');";

                CURS cs = new CURS(CURS.connectionString);

                if (cs.Count(request) == "1")
                {
                    CURS csSelectContributor = new CURS(CURS.connectionString);

                    request = $"SELECT collaborateur.cob_id, statut.sta_libelle FROM compte " +
                        $"INNER JOIN collaborateur ON compte.fk_cob_id = collaborateur.cob_id " +
                        $"INNER JOIN statut ON collaborateur.fk_sta_id = statut.sta_id " +
                        $"WHERE cpt_login = '{ login }'";

                    csSelectContributor.ReqSelect(request);
                    
                    UserSession.Id = csSelectContributor.Field("cob_id").ToString();
                    UserSession.Statut = csSelectContributor.Field("sta_libelle").ToString();

                    MainMenu f = new MainMenu();
                    this.Hide();
                    f.Show();
                }
                else
                {
                    throw new Exception("Les identifiants sont incorrectes.");
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }
    }
}
