using SM4.Encrypt;
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

namespace SM4
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_jiami_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tb_key.Text))
            {

                MessageBox.Show("Key不能为空");
                return;
            }
            if (string.IsNullOrEmpty(tb_mingwen.Text))
            {

                MessageBox.Show("明文不能为空");
                return;
            }
            var item = cb_type.SelectedItem as ComboBoxItem;
            if (item.Tag.ToString() == "cbc")
            {
                if (string.IsNullOrEmpty(tb_iv.Text))
                {
                    MessageBox.Show("IV不能为空");
                    return;
                }


                this.tb_miwen.Text = Sm4Crypto.EncryptCBC(new Sm4Crypto
                {
                    Key = this.tb_key.Text,
                    Iv = this.tb_iv.Text,
                    Data = this.tb_mingwen.Text,
                    CryptoMode = Sm4Crypto.Sm4CryptoEnum.CBC
                });
            }
            else
            {
                string cipherText = Sm4Crypto.EncryptECB(new Sm4Crypto
                {
                    Key = this.tb_key.Text,
                    Data = this.tb_mingwen.Text,
                    CryptoMode = Sm4Crypto.Sm4CryptoEnum.ECB
                });
                this.tb_miwen.Text = cipherText;
            }

        }

        private void btn_jiemi_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tb_key.Text))
            {

                MessageBox.Show("Key不能为空");
                return;
            }
            if (string.IsNullOrEmpty(tb_miwen.Text))
            {

                MessageBox.Show("密文不能为空");
                return;
            }
            var item = cb_type.SelectedItem as ComboBoxItem;
            if (item.Tag.ToString() == "cbc")
            {
                if (string.IsNullOrEmpty(tb_iv.Text))
                {

                    MessageBox.Show("IV不能为空");
                    return;
                }

                string cipherText = Sm4Crypto.DecryptCBC(new Sm4Crypto()
                {
                    Key = this.tb_key.Text,
                    Iv = this.tb_iv.Text,
                    Data = this.tb_miwen.Text,
                    CryptoMode = Sm4Crypto.Sm4CryptoEnum.CBC

                });
                this.tb_mingwen.Text = cipherText;
            }
            else
            {

                string cipherText = Sm4Crypto.DecryptECB(new Sm4Crypto()
                {
                    Key = this.tb_key.Text,
                    Data = this.tb_miwen.Text,
                    CryptoMode = Sm4Crypto.Sm4CryptoEnum.ECB
                });
                this.tb_mingwen.Text = cipherText;
            }
        }
    }
}
