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

namespace ManagementPlatform
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<carInfo> MyCars { get; set; }
        public List<gateInfo> gateList { get; set; }
        public myMessageBox myMessageBox;

        public MainWindow()
        {
            InitializeComponent();
            mainPageInfo.Visibility = Visibility.Visible;

            MyCars = new List<carInfo>();

            carInfo car1 = new carInfo();
            car1.currentTime = DateTime.Now.ToString(" MM/dd HH:mm:ss");
            car1.licensePlate = "MDF5256";
            car1.phone = "0987654321";
            car1.owner = "Jimmy Wuu";
            car1.other = "董事長";
            car1.direction = "進入";

            carInfo car2 = new carInfo();
            car2.currentTime = DateTime.Now.ToString(" MM/dd HH:mm:ss");
            car2.licensePlate = "ABC1234";
            car2.phone = "0987654321";
            car2.owner = "李四";
            car2.other = "董事";
            car2.direction = "離開";

            carInfo car3 = new carInfo();
            car3.currentTime = DateTime.Now.ToString(" MM/dd HH:mm:ss");
            car3.licensePlate = "ACC2345";
            car3.phone = "0987654321";
            car3.owner = "王五";
            car3.other = "董事長夫人";
            car3.direction = "離開";
            for (int i = 0; i < 10; i++)
            {
                MyCars.Add(car1);
                MyCars.Add(car2);
                MyCars.Add(car3);
            }



            gateList = new List<gateInfo>();
            gateInfo gate1 = new gateInfo();
            gate1.gateID = 1;
            gate1.gateName = "入口";

            gateInfo gate2 = new gateInfo();
            gate2.gateID = 2;
            gate2.gateName = "出口";

            gateList.Add(gate1);
            gateList.Add(gate2);

            DataContext = this;



        }

        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            myMessageBox = new myMessageBox();
            myMessageBox.ShowDialog();
        }

        private void GridBarraTitulo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void MainPage_Click(object sender, RoutedEventArgs e)
        {
            pageName.Text = "主頁";
            mainPageInfo.Visibility = Visibility.Visible;
            newPageInfo.Visibility = Visibility.Hidden;
            searchPageInfo.Visibility = Visibility.Hidden;
            connectPageInfo.Visibility = Visibility.Hidden;
            aboutPageInfo.Visibility = Visibility.Hidden;
        }

        private void NewPage_Click(object sender, RoutedEventArgs e)
        {
            pageName.Text = "新增";
            mainPageInfo.Visibility = Visibility.Hidden;
            newPageInfo.Visibility = Visibility.Visible;
            searchPageInfo.Visibility = Visibility.Hidden;
            connectPageInfo.Visibility = Visibility.Hidden;
            aboutPageInfo.Visibility = Visibility.Hidden;
        }

        private void SearchPage_Click(object sender, RoutedEventArgs e)
        {
            pageName.Text = "查詢";
            mainPageInfo.Visibility = Visibility.Hidden;
            newPageInfo.Visibility = Visibility.Hidden;
            searchPageInfo.Visibility = Visibility.Visible;
            connectPageInfo.Visibility = Visibility.Hidden;
            aboutPageInfo.Visibility = Visibility.Hidden;
        }

        private void ConnectPage_Click(object sender, RoutedEventArgs e)
        {
            pageName.Text = "周邊連動";
            mainPageInfo.Visibility = Visibility.Hidden;
            newPageInfo.Visibility = Visibility.Hidden;
            searchPageInfo.Visibility = Visibility.Hidden;
            connectPageInfo.Visibility = Visibility.Visible;
            aboutPageInfo.Visibility = Visibility.Hidden;
        }

        private void AboutPage_Click(object sender, RoutedEventArgs e)
        {
            pageName.Text = "關於我";
            mainPageInfo.Visibility = Visibility.Hidden;
            newPageInfo.Visibility = Visibility.Hidden;
            searchPageInfo.Visibility = Visibility.Hidden;
            connectPageInfo.Visibility = Visibility.Hidden;
            aboutPageInfo.Visibility = Visibility.Visible;
        }

        private void MiniMize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void CbOwner_Checked(object sender, RoutedEventArgs e)
        {
            carOwner.Width = 80;
        }

        private void CbOwner_Unchecked(object sender, RoutedEventArgs e)
        {
            carOwner.Width = 0;
        }

        private void CbPhone_Checked(object sender, RoutedEventArgs e)
        {
            carPhone.Width = 90;
        }

        private void CbPhone_Unchecked(object sender, RoutedEventArgs e)
        {
            carPhone.Width = 0;
        }

        private void CbOther_Checked(object sender, RoutedEventArgs e)
        {
            carOther.Width = 100;
        }

        private void CbOther_Unchecked(object sender, RoutedEventArgs e)
        {
            carOther.Width = 0;
        }

    }
}
