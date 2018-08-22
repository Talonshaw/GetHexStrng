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
using Talon;

namespace floattobyte
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


        private void TextBox_Float_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (((TextBox)sender).IsFocused == false) return;
            if (TextBox_Float.Text == "" || TextBox_Float.Text == null)
            {
                TextBox_Output.Text = "";
                return;
            }
            try
            {
                float value = Convert.ToSingle(TextBox_Float.Text);
                TextBox_Output.Text = DataTypeTransfer.toHexString(value);
            }
            catch (Exception)
            {

                return;
            }
        }

        private void TextBox_Double_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (((TextBox)sender).IsFocused == false) return;
            if (TextBox_Double.Text == "" || TextBox_Double.Text == null)
            {
                TextBox_Output1.Text = "";
                return;
            }
            try
            {
                double value = Convert.ToDouble(TextBox_Double.Text);
                TextBox_Output1.Text = DataTypeTransfer.toHexString(value);

            }
            catch (Exception)
            {

                return;
            }
        }

        private void TextBox_Int_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (((TextBox)sender).IsFocused == false) return;
            if (TextBox_Int.Text == "" || TextBox_Int.Text == null)
            {
                TextBox_Output2.Text = "";
                return;
            }
            try
            {
                int value = Convert.ToInt32(TextBox_Int.Text);
                TextBox_Output2.Text = DataTypeTransfer.toHexString(value);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void TextBox_Uint_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (((TextBox)sender).IsFocused == false) return;
            if (TextBox_Uint.Text == "" || TextBox_Uint.Text == null)
            {
                TextBox_Output3.Text = "";
                return;
            }
            try
            {
                uint value = Convert.ToUInt32(TextBox_Uint.Text);
                TextBox_Output3.Text = DataTypeTransfer.toHexString(value);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void TextBox_String_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (((TextBox)sender).IsFocused == false) return;
            if (TextBox_String.Text == "" || TextBox_String.Text == null)
            {
                TextBox_Output4.Text = "";
                return;
            }
            try
            {
                TextBox_Output4.Text = DataTypeTransfer.toHexString(TextBox_String.Text);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void TextBox_Output_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (((TextBox)sender).IsFocused == false) return;
            if (TextBox_Output.Text == "" || TextBox_Output.Text == null)
            {
                TextBox_Float.Text = "";
                return;
            }
            TextBox_Float.Text = HexStringtoOther(((TextBox)sender).Text, "float");
        }

        private void TextBox_Output1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (((TextBox)sender).IsFocused == false) return;
            if (((TextBox)sender).Text == "" || ((TextBox)sender).Text == null)
            {
                TextBox_Double.Text = "";
                return;
            }
            TextBox_Double.Text = HexStringtoOther(((TextBox)sender).Text, "double");
        }

        private void TextBox_Output2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (((TextBox)sender).IsFocused == false) return;
            if (((TextBox)sender).Text == "" || ((TextBox)sender).Text == null)
            {
                TextBox_Int.Text = "";
                return;
            }
            TextBox_Int.Text = HexStringtoOther(((TextBox)sender).Text,"int");

        }

        

        private void TextBox_Output3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (((TextBox)sender).IsFocused == false) return;
            if (((TextBox)sender).Text == "" || ((TextBox)sender).Text == null)
            {
                TextBox_Uint.Text = "";
                return;
            }
            TextBox_Uint.Text = HexStringtoOther(((TextBox)sender).Text, "uint");
        }

        private void TextBox_Output4_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (((TextBox)sender).IsFocused == false) return;
            if (((TextBox)sender).Text == "" || ((TextBox)sender).Text == null)
            {
                TextBox_String.Text = "";
                return;
            }
            TextBox_String.Text = HexStringtoOther(((TextBox)sender).Text, "string");
        }




        public string HexStringtoOther(string hexStr, string type)
        {
            try
            {
                switch (type)
                {
                    case "float":
                        return DataTypeTransfer.GetFloat(hexStr).ToString();
                    case "double":
                        return DataTypeTransfer.GetDouble(hexStr).ToString();
                    case "int":
                        return DataTypeTransfer.GetInt(hexStr).ToString();
                    case "uint":
                        return DataTypeTransfer.GetUint(hexStr).ToString();
                    case "string":
                        return DataTypeTransfer.GetString(hexStr).ToString();
                    default:
                        break;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }

        }

        
    }
}
