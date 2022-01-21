using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using @interface;

public partial class HomePage : UserControl
{
    public HomePage()
    {
        InitializeComponent();
        // Это якори для растяжки размеров экрана.
        Anchor = AnchorStyles.Right & AnchorStyles.Left & AnchorStyles.Top;

    }

    // Функция для получения того, что выбрал пользователь.
    public InputData GetData()
    {
        InputData res = null;

        // Если в последней строчке не число, вернет null.
        if (int.TryParse(textBox1.Text, out int count))
        {
            res = new InputData(comboBox1.Text, comboBox2.Text, comboBox3.Text, count);
        }

        return res;
    }
}

