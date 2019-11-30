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
using System.Windows.Shapes;

namespace ManagementPlatform
{
    /// <summary>
    /// myMessageBox.xaml 的互動邏輯
    /// </summary>
    public partial class myMessageBox : Window
    {
        private string passwd = "24249115";
        public myMessageBox()
        {
            InitializeComponent();
        }


        private void GridBarraTitulo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void BtCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtConfirm_Click(object sender, RoutedEventArgs e)
        {

            if (tbPasswd.Password.Equals(passwd))
            {
                Application.Current.Shutdown();
            }
            else if (tbPasswd.Password.Equals(""))
            {
                tbEmptyPasswd.Visibility = Visibility.Visible;
                tbErrorPasswd.Visibility = Visibility.Hidden;
            }
            else if ((!tbPasswd.Password.Equals("")) && (!tbPasswd.Password.Equals(passwd)))
            {
                tbErrorPasswd.Visibility = Visibility.Visible;
                tbEmptyPasswd.Visibility = Visibility.Hidden;
            }

        }

        private int pwChanges = 0;

        private void TbPasswd_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ++pwChanges;
        }

        private void TbPasswd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                BtConfirm_Click(null, null);
            }
        }
    }
}
