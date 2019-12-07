using System.Windows;
using System.Windows.Input;

namespace ManagementPlatform
{
    /// <summary>
    /// myMessageBox.xaml 的互動邏輯
    /// </summary>
    public partial class myMessageBox : Window
    {
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
            string getPasswdCommand = "select config_para_data from parking_lot_platform_db.config where config_para_name='passwd';";
            string passwdAES = dbProcess.GetDataTable(getPasswdCommand).Rows[0]["config_para_data"].ToString();
            if (EncryptString.aesEncryptBase64(tbPasswd.Password).Equals(passwdAES))
            {
                Application.Current.Shutdown();
            }
            else if (tbPasswd.Password.Equals(""))
            {
                tbEmptyPasswd.Visibility = Visibility.Visible;
                tbErrorPasswd.Visibility = Visibility.Hidden;
            }
            else if ((!tbPasswd.Password.Equals("")) && (!tbPasswd.Password.Equals(passwdAES)))
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
